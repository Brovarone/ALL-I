Imports System.Data.SqlClient
Imports System.Text
Imports System.Reflection.MethodBase

Module Cespiti
    Private Function ColumnIndexToColumnLetter(columnNumber As Integer) As String
        Dim dividend As Integer = columnNumber
        Dim columnName As String = String.Empty
        Dim modulo As Integer

        While dividend > 0
            modulo = (dividend - 1) Mod 26
            columnName = Convert.ToChar(65 + modulo).ToString() & columnName
            dividend = CInt((dividend - modulo) / 26)
        End While

        Return columnName
    End Function
    Public Function CespitiXLS(dts As DataSet, isFiscale As Boolean, Optional bConIntestazione As Boolean = False) As Boolean
        'Il file contiene il registro storico, per ogni riga controllo se esiste il cespite e lo creo
        'Poi scrivo i movimenti cespiti adeguati negli anni
        'QUANDO PASSO UN DOUBLE DEVO FARE ATTENZIONE
        'Cespiti - MA_FixedAssets
        'MA_FixAssetEntries
        'MA_FixedAssetsFiscal
        'MA_FixedAssetsBalance

        'Su fle di Pasquale il codice e' spezzato 29016 2 sul file di silvia e' unito 29016/2 
        Dim stopwatch As New System.Diagnostics.Stopwatch
        stopwatch.Start()
        EditTestoBarra("Creo Cespiti")
        FLogin.prgCopy.Value = 1
        Dim idAndNumber As StringBuilder = New StringBuilder()
        Dim loggingTxt As String = "Si"
        Dim errori As StringBuilder = New StringBuilder()  ' Ultimo =2
        Dim avvisi As StringBuilder = New StringBuilder()  ' Ultimo = 0  / 0
        Dim aggiornamenti As StringBuilder = New StringBuilder()
        Dim warnings As StringBuilder = New StringBuilder() ' Ultimo = 1
        Dim bulkMessage As StringBuilder = New StringBuilder()
        Dim okBulk As Boolean
        Dim someTrouble As Boolean

        Dim listOfNewCespiti As List(Of String) = New List(Of String)
        Dim lLunghi As List(Of String) = New List(Of String)
        Dim listofNewCategorie As List(Of String) = New List(Of String)

        'Inizializzo un datatable al file xls e un datarow con tutte le righe
        Dim irxls As Integer = 0
        Dim i As Integer = 0
        i = 1 ' aumento il contatore in quanto questo excel e' fatto cosi'
        If bConIntestazione Then i = 1 ' Se c'e' l'intestazione parto dalla seconda riga
        'Leggo dal foglio 2 -> tables 1 - > id 1
        Dim dtXLS As DataTable = dts.Tables(1)
        'Aggiungo colonna G in quanto assente
        If isFiscale Then
            dtXLS.Columns.Add("NEWG", GetType(String)).SetOrdinal(6)
            'Rinomino con numeri poi con lettera di colonna
            For Each dt As DataColumn In dtXLS.Columns
                dt.ColumnName = dt.Ordinal.ToString
            Next
            For Each dt As DataColumn In dtXLS.Columns
                dt.ColumnName = ColumnIndexToColumnLetter(dt.Ordinal + 1)
            Next
        End If

        Dim drXLS As DataRow() = dtXLS.Select()
        If drXLS.Length > 0 Then
            'Identificatore  Movimento Cespite
            Debug.Print("Estraggo ID")
            EditTestoBarra("Estraggo gli ID")
            Dim idMovCesp As Integer = LeggiID(IdType.MovCespite, loggingTxt)
            idAndNumber.AppendLine(loggingTxt)
            Dim idCespite As Integer = LeggiNrCespite(loggingTxt)
            idAndNumber.AppendLine(loggingTxt)
            Dim iRefNo As Integer = LeggiNonFiscalNumber(CodeType.MovCes, Year(Today))
            FLogin.prgCopy.Maximum = drXLS.Length
            FLogin.prgCopy.Step = 1
            Try
                'Creo Datatable con valori di DEFAULT nelle colonne
                EditTestoBarra("Carico Schema: Movimenti Cespiti")
                Using dtMovCes As DataTable = CaricaSchema("MA_FixAssetEntries")
                    EditTestoBarra("Carico Schema: Righe")
                    Using dtMovCesDet As DataTable = CaricaSchema("MA_FixAssetEntriesDetail")
                        'Dim dvDocDet As DataView = New DataView(dtMovAnaDet, "", "SaleDocId", DataViewRowState.CurrentRows)
                        EditTestoBarra("Carico Schema: Anagrafiche Cespiti")
                        Using dtCespiti As DataTable = CaricaSchema("MA_FixedAssets", True, True)
                            Dim dvcespitiACG As DataView = New DataView(dtCespiti, "", "ACGCode", DataViewRowState.CurrentRows)
                            EditTestoBarra("Carico Schema: Amm." & If(isFiscale, " Fiscale", " di Bilancio"))
                            Using dtSaldi As DataTable = If(isFiscale, CaricaSchema("MA_FixedAssetsFiscal", True, True), CaricaSchema("MA_FixedAssetsBalance", True, True))
                                Dim dvSaldi As DataView = New DataView(dtSaldi, "", "FiscalYear,CodeType,FixedAsset,Currency", DataViewRowState.CurrentRows)
                                'Creo un dataset con le anagrafiche Clienti
                                Using dtCategoria As DataTable = CaricaSchema("MA_FixAssetsCtg", True, True)
                                    Dim dvCat As DataView = New DataView(dtCategoria, "", "Category", DataViewRowState.CurrentRows)
                                    Dim isNewCespite As Boolean = False
                                    ' Ciclo le righe del file XLS
                                    'Posso chiamare le Colonne con la stessa logica di Excel A,B,C o con i Numeri

                                    EditTestoBarra("Caricamento tabelle di conversione")
                                    'Creo le dataview per l'anagrafica Fornitore 
                                    Using adpCF As SqlDataAdapter = New SqlDataAdapter("Select * FROM MA_CustSupp Where CustSuppType=" & CustSuppType.Fornitore, Connection)
                                        Dim dtCliFor As DataTable = New DataTable("CliFor")
                                        adpCF.Fill(dtCliFor)
                                        Dim dvCliFor As DataView = New DataView(dtCliFor, "", "CustSupp", DataViewRowState.CurrentRows)

                                        'Creo le dataview per l'aggiornameno anagrafico dei Cespiti ( solo bilancio) 
                                        Using adpCespiti As SqlDataAdapter = New SqlDataAdapter("SELECT CodeType, FixedAsset, ACGCode, BalanceCustomized, BalancePerc, DeprByDate, DepreciationEndingDate, Location, CostCenter, Qty  FROM MA_FixedAssets", Connection)
                                            Dim cbMar = New SqlCommandBuilder(adpCespiti)
                                            adpCespiti.UpdateCommand = cbMar.GetUpdateCommand(True)
                                            Dim dtUpdCespiti As DataTable = New DataTable("UpdCespiti")
                                            adpCespiti.Fill(dtUpdCespiti)
                                            Dim dvUpdCespiti As DataView = New DataView(dtUpdCespiti, "", "ACGCode", DataViewRowState.CurrentRows)

                                            EditTestoBarra("Scrittura Movimenti in corso...")
                                            Dim ACGCode As String = ""
                                            Dim wSaldo As MySaldoCespite = New MySaldoCespite

                                            For irxls = i To drXLS.Length - 1
                                                Dim drMov As DataRow
                                                Dim drMovDet As DataRow
                                                Dim drCesp As DataRow

                                                Dim codCespite As String = ""

                                                With drXLS(irxls)
                                                    Debug.Print("Riga " & (i + irxls).ToString & " Cespite: " & .Item("A").ToString)
                                                    'Resetto i boolean
                                                    'isNewCategoria = False
                                                    isNewCespite = False
                                                    codCespite = ""

                                                    'Controllo una colonna qualunque ( la "F" Categoria) 
                                                    If Not String.IsNullOrWhiteSpace(.Item("F").ToString) Then
                                                        '07/09/2021 deprecato. 
                                                        'Scrivo su nuovo campo CodiceACG in modo da averlo e non mi interessa la lunghezza
                                                        'controllo lunghezza codice
                                                        'If Len(.Item("A").ToString) > 10 Then
                                                        'If Not lLunghi.Contains(.Item("A").ToString & " = " & Len(.Item("A")).ToString) Then lLunghi.Add(.Item("A").ToString & " = " & Len(.Item("A")).ToString)
                                                        'errori.AppendLine("E1: Codice Cespite troppo lungo: " & .Item("A").ToString & " = " & Len(.Item("A")).ToString)
                                                        'Else
                                                        'Continue For

                                                        If Not String.Equals(ACGCode, .Item("A")) AndAlso irxls <> i Then
                                                            'Porto i saldi all'anno in corso
                                                            wSaldo.Anno = 2021
                                                            Dim xCau As MyCausale = New MyCausale
                                                            wSaldo.Causale = xCau
                                                            AggiornaSaldoCespite(wSaldo, dvSaldi, isFiscale)
                                                        End If

                                                        'Cerco la categoria
                                                        Dim catFound As Integer = dvCat.Find(.Item("F").ToString)
                                                        If catFound = -1 AndAlso Not listofNewCategorie.Contains(.Item("F".ToString)) Then listofNewCategorie.Add(.Item("F".ToString))

                                                        'Determino l'anno Fiscale
                                                        Dim dtaMov As Date = MagoFormatta(.Item("I").ToString, GetType(DateTime), True).DataTempo
                                                        Dim annoF As Short = CShort(Year(dtaMov))

                                                        'Determino la Causale , se e' doppia e il valore che
                                                        'a seconda della casuale si trova su colonne diverse
                                                        Dim myVal As Double = 0
                                                        Dim myValFondo As Double = 0
                                                        Dim myPerc As Double
                                                        If String.IsNullOrWhiteSpace(drXLS(irxls).Item("S").ToString) Then
                                                            myPerc = 0
                                                        Else
                                                            myPerc = CDbl(drXLS(irxls).Item("S").ToString)
                                                        End If
                                                        Dim mCau As MyCausale = New MyCausale
                                                        mCau = TrovaCausaleeValore(drXLS(irxls), isFiscale, myVal, myValFondo)

                                                        'Creo l'oggetto per l'aggiornamento saldi con i vari valori
                                                        wSaldo = New MySaldoCespite With {
                                                                                .Cespite = codCespite,
                                                                                .CodiceACG = drXLS(irxls).Item("A").ToString,
                                                                                .Tipo = If(drXLS(irxls).Item("C").ToString = "Materiale", 7012352, 7012353),
                                                                                .Anno = annoF,
                                                                                .Currency = "EUR",
                                                                                .Causale = mCau,
                                                                                .Categoria = drXLS(irxls).Item("F").ToString,
                                                                                .Valore = myVal,
                                                                                .ValoreFondo = myValFondo,
                                                                                .Percentuale = myPerc
                                                                                }
                                                        'Cerco il Cespite
                                                        Dim cespFndACG As Integer = dvcespitiACG.Find(.Item("A").ToString)
                                                        If cespFndACG = -1 Then
                                                            'CREO NUOVO CESPITE
                                                            isNewCespite = True
                                                            listOfNewCespiti.Add(.Item("A").ToString & ": " & .Item("B").ToString)
                                                            Debug.Print("Nuovo Cespite: " & .Item("A").ToString)
                                                            drCesp = dtCespiti.NewRow
                                                            idCespite += 1
                                                            codCespite = idCespite.ToString("000000")  'lungo 6
                                                            ACGCode = .Item("A").ToString
                                                            drCesp("FixedAsset") = codCespite
                                                            drCesp("ACGCode") = .Item("A").ToString
                                                            drCesp("Codetype") = If(.Item("C").ToString = "Materiale", 7012352, 7012353)
                                                            drCesp("Description") = .Item("B").ToString
                                                            drCesp("Category") = .Item("F").ToString
                                                            drCesp("Class") = ""
                                                            drCesp("DepreciationStart") = Year(MagoFormatta(.Item("D").ToString, GetType(DateTime), True).DataTempo)
                                                            drCesp("LastDepreciation") = 0 'CShort(Year(Today))
                                                            drCesp("PurchaseType") = 7208960 '7208960 (nuovo) / 7208961 ( Usato)
                                                            drCesp("PurchaseDate") = MagoFormatta(.Item("D").ToString, GetType(DateTime), True).DataTempo
                                                            drCesp("PurchaseYear") = Year(MagoFormatta(.Item("D").ToString, GetType(DateTime), True).DataTempo)
                                                            wSaldo.PurchaseYear = Year(MagoFormatta(.Item("D").ToString, GetType(DateTime), True).DataTempo)
                                                            drCesp("PurchaseCost") = myVal
                                                            If Not String.IsNullOrWhiteSpace(.Item("L")) Then
                                                                drCesp("PurchaseDocDate") = MagoFormatta(.Item("L").ToString, GetType(DateTime), True).DataTempo
                                                                wSaldo.PurchaseDocDate = MagoFormatta(.Item("L").ToString, GetType(DateTime), True).DataTempo
                                                            End If
                                                            drCesp("PurchaseDocNo") = .Item("K").ToString
                                                            drCesp("LogNo") = ""
                                                            drCesp("Supplier") = .Item("M").ToString
                                                            drCesp("DepreciationStartingDate") = MagoFormatta(.Item("E").ToString, GetType(DateTime), True).DataTempo
                                                            ''% ammortamento Fiscale personalizzata
                                                            'drCesp("FiscalCustomized") = "1"
                                                            'drCesp("FiscalPerc") = 0
                                                            ''% ammortamento Bilancio personalizzata
                                                            'drCesp("BalanceCustomized") = "1"
                                                            'drCesp("BalancePerc") = 0
                                                            If Not isFiscale Then
                                                                If Not String.IsNullOrWhiteSpace(.Item("AB").ToString) Then
                                                                    drCesp("DeprByDate") = "1"
                                                                    drCesp("DepreciationEndingDate") = MagoFormatta(.Item("AB").ToString, GetType(DateTime), True).DataTempo
                                                                End If
                                                                drCesp("Location") = .Item("Z").ToString
                                                                drCesp("CostCenter") = .Item("Z").ToString
                                                                drCesp("Qty") = CShort(.Item("AA"))
                                                            End If
                                                            drCesp("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                            drCesp("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                                            dtCespiti.Rows.Add(drCesp)
                                                            wSaldo.Cespite = drCesp("FixedAsset")
                                                            wSaldo.CodiceACG = .Item("A").ToString
                                                        Else
                                                            codCespite = dvcespitiACG(cespFndACG)("FixedAsset")
                                                            ACGCode = .Item("A").ToString
                                                            wSaldo.Cespite = codCespite
                                                            wSaldo.CodiceACG = dvcespitiACG(cespFndACG)("ACGCode")
                                                            If IsDeprecated AndAlso Not isFiscale Then
                                                                'Processo prima il file di Bilancio !
                                                                Dim idUpd As Integer = dvUpdCespiti.Find(ACGCode)
                                                                If Not String.IsNullOrWhiteSpace(.Item("AB").ToString) Then
                                                                    dvUpdCespiti(idUpd)("DeprByDate") = "1"
                                                                    dvUpdCespiti(idUpd)("DepreciationEndingDate") = MagoFormatta(.Item("AB").ToString, GetType(DateTime), True).DataTempo
                                                                End If
                                                                dvUpdCespiti(idUpd)("Location") = .Item("Z").ToString
                                                                dvUpdCespiti(idUpd)("CostCenter") = .Item("Z").ToString
                                                                dvUpdCespiti(idUpd)("Qty") = CShort(.Item("AA"))
                                                            End If
                                                        End If

                                                        'Cerco il Fornitore ( se necessario)
                                                        If Not String.IsNullOrWhiteSpace(.Item("M").ToString) Then
                                                            Dim forFound As Integer = dvCliFor.Find(.Item("M").ToString)
                                                            If forFound = -1 Then errori.AppendLine("E2: Fornitore non presente: " & .Item("M").ToString & " : " & .Item("N").ToString)
                                                        End If

                                                        'Controllo che la causale non sia doppia e
                                                        'Quindi creo 1 o 2 movimenti
                                                        Dim nrMov As Byte = 0
                                                        If mCau.isCausaleDoppia Then nrMov = 1
                                                        For x = 0 To nrMov
                                                            '''''''''''''''''''''''
                                                            ' Scrivo il movimento '
                                                            '''''''''''''''''''''''
                                                            drMov = dtMovCes.NewRow
                                                            idMovCesp += 1 ' Incremento Id
                                                            iRefNo += 1
                                                            ' Testa
                                                            drMov("FARsn") = If(x = 0, mCau.Codice, mCau.SecondaCausale.Codice)
                                                            drMov("PostingDate") = MagoFormatta(.Item("I").ToString, GetType(DateTime), True).DataTempo
                                                            If Not String.IsNullOrWhiteSpace(.Item("L")) Then
                                                                drMov("DocumentDate") = MagoFormatta(.Item("L").ToString, GetType(DateTime), True).DataTempo
                                                            End If
                                                            drMov("DocNo") = .Item("K").ToString()
                                                            'TODO: Nr Riferimento mov cespiti per Anno e non tutti 21/xxx
                                                            drMov("RefNo") = Right(Year(Today), 2) & "/" & iRefNo.ToString("00000")
                                                            drMov("LogNo") = ""
                                                            If Not String.IsNullOrWhiteSpace(.Item("M").ToString()) Then
                                                                drMov("CustSuppType") = CustSuppType.FornitoreIgnora
                                                                drMov("CustSupp") = .Item("M").ToString
                                                            End If

                                                            drMov("DepreciationEntry") = If((drMov("FARsn") = CauCes.AmmAnt.Codice.ToString) OrElse (drMov("FARsn") = CauCes.AmmBil.Codice.ToString) OrElse (drMov("FARsn") = CauCes.AmmFisc.Codice.ToString), 1, 0)
                                                            drMov("DisposalEntry") = If(drMov("FARsn") = CauCes.VendPF.Codice.ToString OrElse drMov("FARsn") = CauCes.VendPB.Codice.ToString, 1, 0)

                                                            drMov("EntryId") = idMovCesp
                                                            drMov("Currency") = "EUR"
                                                            drMov("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                            drMov("TBModifiedID") = My.Settings.mLOGINID 'ID utente

                                                            'Righe
                                                            drMovDet = dtMovCesDet.NewRow
                                                            drMovDet("EntryId") = idMovCesp
                                                            drMovDet("Line") = 1
                                                            drMovDet("Codetype") = If(.Item("C").ToString = "Materiale", 7012352, 7012353)
                                                            drMovDet("FixedAsset") = codCespite
                                                            drMovDet("PostingDate") = MagoFormatta(.Item("I").ToString, GetType(DateTime), True).DataTempo
                                                            'todo quantità
                                                            drMovDet("Qty") = 0
                                                            drMovDet("Perc") = myPerc

                                                            'Deprecata
                                                            If IsDeprecated AndAlso myPerc > 0 Then
                                                                'Aggiorna percentuale personalizzata / Si usa Percentuale di Categoria
                                                                Dim nCespF As Integer = dvcespitiACG.Find(.Item("A").ToString)
                                                                If isFiscale Then
                                                                    '% ammortamento Fiscale personalizzata
                                                                    dvcespitiACG(nCespF)("FiscalCustomized") = "1"
                                                                    dvcespitiACG(nCespF)("FiscalPerc") = If(myPerc > dvcespitiACG(nCespF)("FiscalPerc"), myPerc, dvcespitiACG(nCespF)("FiscalPerc"))
                                                                Else
                                                                    '% ammortamento Bilancio personalizzata
                                                                    Dim idUpd As Integer = dvUpdCespiti.Find(.Item("A").ToString)
                                                                    dvUpdCespiti(idUpd)("BalanceCustomized") = "1"
                                                                    dvUpdCespiti(idUpd)("BalancePerc") = If(myPerc > dvUpdCespiti(idUpd)("BalancePerc"), myPerc, dvUpdCespiti(idUpd)("BalancePerc"))
                                                                End If
                                                            End If
                                                            Dim dImporto As Double
                                                            'Sul Secondo movimento utilizzo il valore del fondo
                                                            If x = 0 Then
                                                                dImporto = If(myVal <> 0, myVal, myValFondo)
                                                            Else
                                                                dImporto = myValFondo 'If(myValFondo <> 0, myValFondo, myVal)
                                                            End If
                                                            'If dImporto.Equals(0) Then Continue For
                                                            drMovDet("Amount") = Math.Round(dImporto, 2)
                                                            If .Item("J").ToString.Length > 64 Then
                                                                warnings.AppendLine("W1:  Riga: " & (i + irxls).ToString & " Cespite: " & .Item("A").ToString & " descrizione movimento troppo lunga, verrà troncata!")
                                                                warnings.AppendLine(.Item("J").ToString)
                                                            End If
                                                            drMovDet("Notes") = Left(.Item("J").ToString, 64)
                                                            drMovDet("Currency") = "EUR"
                                                            drMovDet("AmountDocCurr") = 0
                                                            drMovDet("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                                            drMovDet("TBModifiedID") = My.Settings.mLOGINID 'ID utente

                                                            'Aggiungo le righe all'insieme Rows del Datatable
                                                            dtMovCes.Rows.Add(drMov)
                                                            dtMovCesDet.Rows.Add(drMovDet)

                                                            'Corrego le informazioni per l'aggiornamento saldo solo sul secondo movimento
                                                            If x <> 0 Then
                                                                wSaldo.Causale = wSaldo.Causale.SecondaCausale
                                                            End If
                                                            AggiornaSaldoCespite(wSaldo, dvSaldi, isFiscale)
                                                        Next
                                                        'Else
                                                        'Totale categoria
                                                        ' End If
                                                    End If


                                                End With
                                                'Fine Ciclo
                                                FLogin.prgCopy.PerformStep()
                                                FLogin.prgCopy.Update()
                                                Application.DoEvents()
                                            Next
                                            'Ultimo adeguamento al 2021
                                            wSaldo.Anno = 2021
                                            Dim tCau As MyCausale = New MyCausale
                                            wSaldo.Causale = tCau
                                            AggiornaSaldoCespite(wSaldo, dvSaldi, isFiscale)

                                            For l = 0 To lLunghi.Count - 1
                                                Debug.Print(lLunghi(l).ToString)
                                            Next

                                            Debug.Print("Inizio Bulk")
                                            Using cmdqry = New SqlCommand("DBCC TRACEON(610)", Connection)
                                                cmdqry.ExecuteNonQuery()
                                                Using bulkTrans = Connection.BeginTransaction
                                                    EditTestoBarra("Salvataggio: Anagrafica Cespiti")
                                                    okBulk = ScriviBulk("MA_FixedAssets", dtCespiti, bulkTrans, DataRowState.Added, loggingTxt)
                                                    If Not okBulk Then someTrouble = True
                                                    bulkMessage.AppendLine(loggingTxt)
                                                    'EditTestoBarra("Salvataggio: Anagrafica Categorie Cespiti")
                                                    'okBulk = ScriviBulk("MA_FixAssetsCtg", dtCategoria, bulkTrans, DataRowState.Added, loggingTxt)
                                                    'If Not okBulk Then someTrouble = True
                                                    'bulkMessage.AppendLine(loggingTxt)
                                                    EditTestoBarra("Salvataggio: Movimenti Cespiti")
                                                    okBulk = ScriviBulk("MA_FixAssetEntries", dtMovCes, bulkTrans, DataRowState.Unchanged, loggingTxt)
                                                    If Not okBulk Then someTrouble = True
                                                    bulkMessage.AppendLine(loggingTxt)
                                                    EditTestoBarra("Salvataggio: Righe")
                                                    okBulk = ScriviBulk("MA_FixAssetEntriesDetail", dtMovCesDet, bulkTrans, DataRowState.Unchanged, loggingTxt)
                                                    If Not okBulk Then someTrouble = True
                                                    bulkMessage.AppendLine(loggingTxt)
                                                    EditTestoBarra("Salvataggio: Saldi ")
                                                    okBulk = ScriviBulk(If(isFiscale, "MA_FixedAssetsFiscal", "MA_FixedAssetsBalance"), dtSaldi, bulkTrans, DataRowState.Unchanged, loggingTxt)
                                                    If Not okBulk Then someTrouble = True
                                                    bulkMessage.AppendLine(loggingTxt)


                                                    If someTrouble Then
                                                        FLogin.lstStatoConnessione.Items.Add("Riscontrati errori: annullamento operazione...")
                                                        bulkTrans.Rollback()
                                                    Else
                                                        bulkTrans.Commit()
                                                    End If
                                                    Debug.Print("Fine bulk")
                                                End Using
                                                If IsDeprecated AndAlso Not someTrouble AndAlso isFiscale Then
                                                    ' Non aggiorno piu' nulla, leggo tutto dal Bilancio
                                                    Dim irows As Integer
                                                    Using updTrans = Connection.BeginTransaction
                                                        EditTestoBarra("Aggiornamento Anagrafica Cespiti")
                                                        adpCespiti.UpdateCommand.Transaction = updTrans
                                                        irows = adpCespiti.Update(dtUpdCespiti)
                                                        If irows > 0 Then aggiornamenti.AppendLine("Aggiornamento Anagrafiche Cespiti: " & irows.ToString & " record")
                                                        Debug.Print("Aggiornamento Anagrafiche Cespiti: " & irows.ToString & " record")
                                                        updTrans.Commit()
                                                    End Using
                                                End If
                                                cmdqry.CommandText = "DBCC TRACEOFF(610)"
                                                cmdqry.ExecuteNonQuery()
                                                Debug.Print("Fine update")
                                            End Using
                                        End Using
                                    End Using
                                End Using
                            End Using
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Debug.Print(ex.Message)
                Dim mb As MessageBoxWithDetails = New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                mb.ShowDialog()
            End Try
            If Not someTrouble Then
                'Scrivi Gli ID ( faccio solo a fine elaborazione)
                AggiornaID(IdType.MovCespite, idMovCesp, loggingTxt)
                idAndNumber.AppendLine(loggingTxt)
                AggiornaNRCespite(idCespite, loggingTxt)
                idAndNumber.AppendLine(loggingTxt)
                AggiornaNonFiscalNumber(CodeType.MovCes, Year(Today), iRefNo)
                'idAndNumber.AppendLine(loggingTxt)
            End If
            'Scrivo i Log 
            My.Application.Log.DefaultFileLogWriter.WriteLine("Nuovi cespiti=" & listOfNewCespiti.Count.ToString)
            FLogin.lstStatoConnessione.Items.Add("Nuovi cespiti=" & listOfNewCespiti.Count.ToString)
            If bulkMessage.Length > 0 Then My.Application.Log.DefaultFileLogWriter.WriteLine(" --- Inserimento Dati ---" & vbCrLf & bulkMessage.ToString)
            If errori.Length > 0 Then My.Application.Log.DefaultFileLogWriter.WriteLine(" --- Errori ---" & vbCrLf & errori.ToString)
            Debug.Print(errori.ToString)

            If listofNewCategorie.Count > 0 Then
                My.Application.Log.DefaultFileLogWriter.WriteLine(" --- Nuove Categorie (Da creare su Mago) ---")
                For l = 0 To listofNewCategorie.Count - 1
                    My.Application.Log.DefaultFileLogWriter.WriteLine(listofNewCategorie(l).ToString)
                Next
                My.Application.Log.DefaultFileLogWriter.Write(vbLf)
            End If

            If warnings.Length > 0 Then My.Application.Log.DefaultFileLogWriter.WriteLine(" --- Warnings ---" & vbCrLf & " - La riga verrà troncata - " & vbCrLf & warnings.ToString)
            Debug.Print(warnings.ToString)


            If avvisi.Length > 0 Then My.Application.Log.DefaultFileLogWriter.WriteLine(" --- Avvisi ---" & vbCrLf & avvisi.ToString)
            Debug.Print(avvisi.ToString)
            '( solo se in debugging)
            If bIsDebugging AndAlso listOfNewCespiti.Count > 0 Then
                My.Application.Log.DefaultFileLogWriter.WriteLine(" --- Nuovi cespiti ---")
                For l = 0 To listOfNewCespiti.Count - 1
                    My.Application.Log.DefaultFileLogWriter.WriteLine(listOfNewCespiti(l).ToString)
                Next
                My.Application.Log.DefaultFileLogWriter.Write(vbLf)
            End If

            If aggiornamenti.Length > 0 Then My.Application.Log.DefaultFileLogWriter.WriteLine(" --- Aggiornamenti anagrafici (NUOVO VALORE ) [VECCHIO VALORE] ---" & vbCrLf & aggiornamenti.ToString)
                If idAndNumber.Length > 0 Then My.Application.Log.DefaultFileLogWriter.WriteLine(" --- Id e Numeratori ---" & vbCrLf & idAndNumber.ToString)
                Debug.Print(idAndNumber.ToString)

                Debug.Print("Gestione Cespiti" & " " & stopwatch.Elapsed.ToString)

            End If
            stopwatch.Stop()
        Return Not someTrouble

    End Function

    Private Function TrovaFiliale(Codice As String) As String
        Dim esito As String
        Dim s As String = Left(Codice, 1).ToUpper
        Select Case s
            Case "A"
                esito = "01"    'TORINO
            Case "B"
                esito = "02"    'MILANO
            Case "C"
                esito = "03"    'ASTI
            Case "D"
                esito = "04"    'AOSTA
            Case "E"
                esito = "05"    'NOVARA
            Case "F"
                esito = "06"    'BERGAMO
            Case "G"
                esito = "07"    'GENOVA
            Case "H"
                esito = "08"    'VERCELLI/BIELLA
            Case "I"
                esito = "09"    'VARESE
            Case "J"
                esito = "10"    'SEDE
            Case "K"
                esito = "11"    'CUNEO
            Case "L"
                esito = "12"    'ALESSANDRIA
            Case Else
                esito = s
        End Select
        Return esito
    End Function

    ''' <summary>
    ''' Passando la riga / colonna I restituisce la Causale corretta. Ritorna anche il valore sulla variabile val
    ''' </summary>
    ''' <returns></returns>
    Private Function TrovaCausaleeValore(row As DataRow, Fiscale As Boolean, ByRef val As Double, ByRef valFondo As Double) As MyCausale
        Dim esito As MyCausale
        Try
            Dim codice As String = row.Item("J").ToString
            Select Case codice
                Case "Valore originario"
                    esito = IIf(Fiscale, CauCes.RipTotAmF, CauCes.RipTotAmB)
                    val = If(String.IsNullOrWhiteSpace(row.Item("P")), 0, row.Item("P"))
                Case "Saldi ammortamenti"
                    esito = IIf(Fiscale, CauCes.RipFondoF, CauCes.RipFondoB)
                    val = If(String.IsNullOrWhiteSpace(row.Item("V")), 0, row.Item("V"))
                Case "Ammortamento ordinario"
                    esito = IIf(Fiscale, CauCes.AmmFisc, CauCes.AmmBil)
                    val = If(String.IsNullOrWhiteSpace(row.Item("T")), 0, row.Item("T"))
                Case "Ammortamento anticipato" ' Solo fiscale
                    esito = CauCes.AmmAnt
                    val = If(String.IsNullOrWhiteSpace(row.Item("T")), 0, row.Item("T"))
                Case "Acquisizione cespiti"
                    ' !! DOPPIA OPERAZIONE !! Ripresa Tot. ammortizzabile e Ripresa Fondo
                    esito = IIf(Fiscale, CauCes.AcquisizF, CauCes.AcquisizB)
                    esito.isCausaleDoppia = True
                    esito.SecondaCausale = (IIf(Fiscale, CauCes.RipFondoF, CauCes.RipFondoB))
                    val = If(String.IsNullOrWhiteSpace(row.Item("P")), 0, row.Item("P"))
                    valFondo = If(String.IsNullOrWhiteSpace(row.Item("U")), 0, row.Item("U"))
                Case "Incremento del costo originario"
                    'Come acquisto ad incremento della Allsystem 1
                    esito = IIf(Fiscale, CauCes.IncFisc, CauCes.IncBil)
                    val = If(String.IsNullOrWhiteSpace(row.Item("P")), 0, row.Item("P"))
                Case "Scorporo per vendita a La Vedetta", "Vendita parziale CON VAR FDO AMM MANUALE"
                    ' !! DOPPIA OPERAZIONE !! Storno Tot. ammortizzabile e Storno Fondo
                    esito = IIf(Fiscale, CauCes.VendPF, CauCes.VendPB)
                    esito.isCausaleDoppia = True
                    esito.SecondaCausale = (IIf(Fiscale, CauCes.StFondoF, CauCes.StFondoB))
                    val = If(String.IsNullOrWhiteSpace(row.Item("P")), 0, row.Item("P"))
                    valFondo = If(String.IsNullOrWhiteSpace(row.Item("U")), 0, row.Item("U"))
                Case Else ' "Not Defined"
                    esito = IIf(Fiscale, CauCes.AcqF, CauCes.AcqB)
                    val = If(String.IsNullOrWhiteSpace(row.Item("P")), 0, row.Item("P"))
            End Select
        Catch ex As Exception
            Debug.Print(ex.Message)
            Dim mb As MessageBoxWithDetails = New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
            mb.ShowDialog()

        End Try
        Return esito
    End Function

    ''' <summary>
    ''' Classe dedicata ai logs. I Warning contengono modfiche che NON vengono salvate
    ''' </summary>
    Private Class Mylogs
        Public Property Avvisi As StringBuilder
        Public Property Warning As StringBuilder
        Public Sub New()
            Avvisi = New StringBuilder
            Warning = New StringBuilder
        End Sub
    End Class
    Private NotInheritable Class MyCausale
        Public Property Codice As String
        Public Property Ammortamento As Boolean
        Public Property Anticipato As Boolean
        Public Property Dismissione As Boolean
        Public Property Acquisto As Boolean
        Public Property Ripresa As Boolean
        Public Property IsCausaleDoppia As Boolean
        Public Property SecondaCausale As MyCausale

        Public Sub New()
            Codice = ""
            Ammortamento = False
            Anticipato = False
            Dismissione = False
            Acquisto = False
            Ripresa = False
            isCausaleDoppia = False
        End Sub
    End Class

    Private NotInheritable Class CauCes
        'Max Lunghezza 8 Chr
        'Acquisto e ripresa non possono coesistere
        Public Shared AcqF As MyCausale = New MyCausale With {.Codice = "ACQFISC", .Acquisto = True}
        Public Shared AcqB As MyCausale = New MyCausale With {.Codice = "ACQBIL", .Acquisto = True}
        Public Shared AcquisizF As MyCausale = New MyCausale With {.Codice = "RIPTOTAM", .Ripresa = True}
        Public Shared AcquisizB As MyCausale = New MyCausale With {.Codice = "RIPTOAMB", .Ripresa = True}
        Public Shared AcquisizConFondofISC As MyCausale = New MyCausale With {.Codice = "RTACF", .Acquisto = True, .Ripresa = True, .Ammortamento = True} '( ripresa e ammortamneto contano 1)  ' CREARE
        Public Shared AmmAnt As MyCausale = New MyCausale With {.Codice = "AMMANT", .Ammortamento = True}
        Public Shared AmmFisc As MyCausale = New MyCausale With {.Codice = "AMMFISC", .Ammortamento = True}
        Public Shared AmmBil As MyCausale = New MyCausale With {.Codice = "AMMBIL", .Ammortamento = True}
        Public Shared IncFisc As MyCausale = New MyCausale With {.Codice = "ACQINCF", .Ripresa = True}
        Public Shared IncBil As MyCausale = New MyCausale With {.Codice = "ACQINCB", .Ripresa = True}
        Public Shared RipTotAmF As MyCausale = New MyCausale With {.Codice = "RIPTOTAM", .Ripresa = True}
        Public Shared RipTotAmB As MyCausale = New MyCausale With {.Codice = "RIPTOAMB", .Ripresa = True}
        'Public Shared RipFondoAnt As MyCausale = New MyCausale With {.Codice = "RIPFOANT", .Ripresa = True,.Ammortamento = True, .Anticipato = True}} 
        Public Shared RipFondoF As MyCausale = New MyCausale With {.Codice = "RIPFONDO", .Ripresa = True, .Ammortamento = True}
        Public Shared RipFondoB As MyCausale = New MyCausale With {.Codice = "RIPFOBIL", .Ripresa = True, .Ammortamento = True}
        'Public Shared StFonodoAnt As MyCausale = New MyCausale With {.Codice = "STFONANT", .Dismissione = True, .Ammortamento = True, .Anticipato = True}
        Public Shared StFondoF As MyCausale = New MyCausale With {.Codice = "STFONDO", .Dismissione = True, .Ammortamento = True}
        Public Shared StFondoB As MyCausale = New MyCausale With {.Codice = "STFONDOB", .Dismissione = True, .Ammortamento = True}
        Public Shared VendPF As MyCausale = New MyCausale With {.Codice = "VENDP", .Dismissione = True}
        Public Shared VendPB As MyCausale = New MyCausale With {.Codice = "VENDPBIL", .Dismissione = True}
    End Class
    Private Class MySaldoCespite
        Public Property Cespite As String
        Public Property CodiceACG As String
        Public Property Tipo As Integer
        Public Property Anno As Short
        Public Property Currency As String
        Public Property Causale As MyCausale
        Public Property Categoria As String
        Public Property Percentuale As Double
        Public Property Valore As Double
        Public Property ValoreFondo As Double
        Public Property Qta As Double
        Public Property PurchaseYear As Short
        Public Property PurchaseDocDate As String
        Public Sub New()
            Cespite = ""
            CodiceACG = ""
            Tipo = 7012352
            Anno = CShort(Year(Now))
            Currency = "EUR"
            Categoria = ""
            Percentuale = 0
            Valore = 0
            ValoreFondo = 0
            Qta = 0
            PurchaseYear = CShort(Year(Now))
            PurchaseDocDate = ""
        End Sub
    End Class
    Private Function LeggiNrCespite(Optional ByRef MyReturnString As String = "") As Integer
        Dim id As Integer

        Using cmd = New SqlCommand("SELECT LastFixedAsset FROM MA_FixAssetsParameters", Connection)
            cmd.Transaction = Trans
            Using reader As SqlDataReader = cmd.ExecuteReader
                While reader.Read()
                    id = reader.Item(0)
                End While

                reader.Close()
            End Using
        End Using

        If String.IsNullOrWhiteSpace(MyReturnString) Then
            My.Application.Log.WriteEntry("Ultimo Nr Cespite letto: " & id.ToString)
        Else
            MyReturnString = "Ultimo Nr Cespite letto: " & id.ToString
        End If
        Return id
    End Function
    Private Sub AggiornaNRCespite(ByVal value As Integer, Optional ByRef MyReturnString As String = "")
        Using cmd = New SqlCommand("UPDATE MA_FixAssetsParameters SET LastFixedAsset =" & value, Connection)
            cmd.Transaction = Trans
            Dim irows As Integer = cmd.ExecuteNonQuery()
            irows = cmd.ExecuteNonQuery()
        End Using
        If String.IsNullOrWhiteSpace(MyReturnString) Then
            My.Application.Log.WriteEntry("Ultimo Nr Cespite scritto: " & value.ToString)
        Else
            MyReturnString = "Ultimo Nr Cespite scritto: " & value.ToString
        End If
    End Sub
    Private Function AggiornaSaldoCespite(what As MySaldoCespite, vista As DataView, isFiscal As Boolean) As Boolean
        Dim result As Boolean = True
        '"Fiscalyear/BalanceYear,Tipo,Cespite,Currency"
        Dim found As Integer = vista.Find({what.Anno, what.Tipo, what.Cespite.ToString, what.Currency})
        'In base alla vista ci sono campi in piu'
        'MA_FixedAssetsFiscal o MA_FixedAssetsBalance
        'In base alla causale di sono colonne da valorizzare o no
        Try
            If found = -1 Then
                'Controllo se e' l'ultimo in ordine progressivo o se ci sono degli anni mancanti da creare
                Dim dummySort As String = vista.Sort
                vista.Sort = "CodeType,FixedAsset,Currency"
                Dim drw As DataRowView() = vista.FindRows({what.Tipo, what.Cespite.ToString, what.Currency})
                vista.Sort = "FiscalYear,CodeType,FixedAsset,Currency"
                If drw.Length > 0 Then
                    vista.RowFilter = "Codetype=" & what.Tipo & " AND FixedAsset='" & what.Cespite & "' AND Currency='" & what.Currency & "'"
                    Dim lastYear As Short = CShort(vista(vista.Count - 1).Item("Fiscalyear"))

                    For i = lastYear To what.Anno - 1
                        'Creo record intermedio
                        Dim rr As DataRow = vista.Table.NewRow
                        'Dim rr As DataRowView = vista.AddNew
                        With vista(vista.Count - 1)
                            rr.Item("FixedAsset") = what.Cespite.ToString
                            rr.Item("CodeType") = what.Tipo
                            rr.Item("FiscalYear") = i + 1
                            rr.Item("Currency") = what.Currency
                            rr.Item("Category") = what.Categoria
                            rr.Item("PurchaseYear") = what.PurchaseYear
                            If String.IsNullOrWhiteSpace(what.PurchaseDocDate) Then rr.Item("PurchaseDocDate") = what.PurchaseDocDate
                            'Forse devo usare sempre il finale !
                            rr.Item("InitialTotalDepreciable") = Math.Round(.Item("TotalDepreciable"), 2) ' = Finale dell'anno prima  .Item("InitialTotalDepreciable")
                            rr.Item("TotalDepreciable") = Math.Round(.Item("TotalDepreciable"), 2)
                            If isFiscal Then
                                rr.Item("InitialAcceleratedAccumDepr") = Math.Round(.Item("InitialAcceleratedAccumDepr") + .Item("AcceleratedAccumDepr"), 2)
                                rr.Item("AcceleratedAccumDepr") = Math.Round(.Item("AcceleratedAccumDepr"), 2)
                            End If
                            rr.Item("InitialAccumDepr") = Math.Round(.Item("InitialAccumDepr") + .Item("Depreciation"), 2)
                            rr.Item("AccumDepr") = Math.Round(.Item("AccumDepr"), 2)
                            rr.Item("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                            rr.Item("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                        End With
                        'rr.EndEdit()
                        vista.Table.Rows.Add(rr)
                        vista.Table.AcceptChanges()
                    Next
                    vista.RowFilter = ""

                Else

                    'creo il nuovo record
                    Dim r As DataRow = vista.Table.NewRow
                    'Dim r As DataRowView = vista.AddNew
                    r.Item("FixedAsset") = what.Cespite.ToString
                    r.Item("CodeType") = what.Tipo
                    r.Item("FiscalYear") = what.Anno
                    r.Item("Currency") = what.Currency
                    r.Item("Category") = what.Categoria
                    r.Item("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                    r.Item("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                    'r.EndEdit()
                    vista.Table.Rows.Add(r)
                    vista.Table.AcceptChanges()
                End If
                'Ripristino l'ordinamento
                vista.Sort = dummySort
            End If

            'Dopo averlo creato lo ricerco e modifico quello che serve
            found = vista.Find({what.Anno, what.Tipo, what.Cespite.ToString, what.Currency})
            If found = -1 Then
                MessageBox.Show("Errore che non dovrebbe succedere -  Cespite non trovato: " & what.Cespite & " " & what.Anno.ToString)
                Return False
                Exit Function
            End If
            With vista(found)
                'Inizio calcoli a seconda del tipo Causale
                .BeginEdit()
                If what.Causale.Acquisto Then
                    .Item("InitialTotalDepreciable") += Math.Round(what.Valore, 2)
                    .Item("TotalDepreciable") += Math.Round(what.Valore, 2)
                End If
                If what.Causale.Ripresa Then
                    'Questi non li sommo ! li sovrascrivo
                    If what.Causale.Ammortamento Then
                        If what.Causale.Anticipato Then
                            .Item("InitialAcceleratedAccumDepr") = Math.Round(what.Valore, 2)
                            .Item("AcceleratedAccumDepr") = Math.Round(what.Valore, 2)
                        Else
                            .Item("InitialAccumDepr") = Math.Round(what.Valore, 2)
                            .Item("AccumDepr") = Math.Round(what.Valore, 2)
                        End If
                    Else

                        .Item("InitialTotalDepreciable") = Math.Round(what.Valore, 2)
                        .Item("TotalDepreciable") = Math.Round(what.Valore, 2)
                    End If
                End If
                If what.Causale.Ammortamento AndAlso Not what.Causale.Ripresa AndAlso Not what.Causale.Dismissione Then
                    If what.Causale.Anticipato Then
                        .Item("AcceleratedDepr") += Math.Round(what.Valore, 2)
                        .Item("AcceleratedAccumDepr") += Math.Round(what.Valore, 2)
                        .Item("Perc") += what.Percentuale
                    Else
                        .Item("Depreciation") += Math.Round(what.Valore, 2)
                        .Item("AccumDepr") += Math.Round(what.Valore, 2)
                        .Item("Perc") += what.Percentuale
                    End If

                End If
                If what.Causale.Dismissione AndAlso Not what.Causale.Ammortamento Then
                    .Item("TotalDepreciable") -= Math.Round(what.Valore, 2)
                    .Item("Sales") += Math.Round(what.Valore, 2)
                End If

                .EndEdit()
            End With

        Catch ex As Exception
            Debug.Print(ex.Message)
            Dim mb As MessageBoxWithDetails = New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
            mb.ShowDialog()
            result = False
        End Try

        Return result
    End Function
End Module