Imports System.Text
Imports System.Reflection.MethodBase
Imports System.Linq
Imports ALLSystemTools.SqlTools.Bulk
'Studiare questo
'https://github.com/CollaboratingPlatypus/PetaPoco
'Valori default con linQ
'https://weblogs.asp.net/stefansedich/handling-default-values-with-linq-to-sql
'bulk insert 
'https://stackoverflow.com/questions/9220901/bulk-insert-with-linq-to-sql
Module Unused

    Private Function ABBOZZOScriviDatiAggiuntiviSicuritalia(ByRef dt As DataTable, id As Integer, row As DataRow, line As Integer, subLine As Integer) As Boolean
        Dim writeSomething As Boolean = False
        Dim dr As DataRow
        Dim newline As Integer = line
        Dim bOrdFound As Boolean
        '"IE" = "HG" + un numero loro che non mi viene passato
        If Not String.IsNullOrWhiteSpace(row.Item("IE").ToString) Then
            writeSomething = True
            '2.1.2 Dati ordine Acquisto  -  Codice NSO 
            'Colonna IE (ODA) Oda + nr Posizione 2.1.2.2
            'Colonna BA (NRRGH) Numero Riga 2.1.2.1
            'Colonna W ( RFCLH) Riferimento Cliente - Numero Ordine d'acquisto, unico per tutte le righe della fattura ==> Obbligatorio se si specificano CIG e/o CUP

            'Controllo che non esistano già  sulla stessa "Line"
            'potrebbe averlo scritto Un altra procedura ( tolgo filtro da Line)
            Dim key As Object() = {id, 0, 0, "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiOrdineAcquisto.IdDocumento"}
            dt.DefaultView.Sort = "DocId, DocSubID, SubLine, FieldName "
            Dim drv As DataRowView() = dt.DefaultView.FindRows(key)
            If drv.Length > 0 Then
                'nel caso di piu' righe mi prendo la prima e pace.
                'possibile incongruenza ma iniziamo cosi'
                newline = drv(0).Item("Line")
                bOrdFound = True
            Else
                'Ho già l'incremento
                newline = line
                '2.1.2.2 <IdDocumento> 
                dr = dt.NewRow
                dr("DocID") = id
                dr("DocSubID") = 0
                dr("Line") = newline
                dr("SubLine") = 0
                dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiOrdineAcquisto.IdDocumento"
                dr("FieldValue") = row.Item("IE").ToString
                dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                dt.Rows.Add(dr)
            End If

            '2.1.2.1 <RiferimentoNumeroLinea>
            dr = dt.NewRow
            dr("DocID") = id
            dr("DocSubID") = 0
            dr("Line") = newline
            dr("SubLine") = subLine
            dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiOrdineAcquisto.RiferimentoNumeroLinea"
            dr("FieldValue") = row.Item("BA").ToString
            dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
            dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
            dt.Rows.Add(dr)


            ''2.1.2.3 <Data>
            'If Not String.IsNullOrWhiteSpace(row.Item("AK").ToString) Then
            '    dr = dt.NewRow
            '    dr("DocID") = id
            '    dr("DocSubID") = 0
            '    dr("Line") = newline
            '    dr("SubLine") = 0
            '    dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiOrdineAcquisto.Data"
            '    dr("FieldValue") = row.Item("AK").ToString
            '    dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
            '    dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
            '    dt.Rows.Add(dr)
            'End If

            '2.1.2.4 <NumItem> 
            'In teoria il dato non ce l'ho, metto nr riga fattura
            'Se ho già una riga conl'idDocumento aggiungo
            dr = dt.NewRow
            dr("DocID") = id
            dr("DocSubID") = 0
            dr("Line") = newline
            dr("SubLine") = 0
            dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiOrdineAcquisto.NumItem"
            dr("FieldValue") = row.Item("BA").ToString
            dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
            dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
            dt.Rows.Add(dr)

            ''2.1.2.5 <CodiceCommessaConvenzione>
            'If Not String.IsNullOrWhiteSpace(row.Item("HG").ToString) Then
            '    dr = dt.NewRow
            '    dr("DocID") = id
            '    dr("DocSubID") = 0
            '    dr("Line") = line
            '    dr("SubLine") = 0
            '    dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiOrdineAcquisto.CodiceCommessaConvenzione"
            '    dr("FieldValue") = row.Item("HG").ToString
            '    dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
            '    dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
            '    dt.Rows.Add(dr)
            'End If
            ''2.1.2.6 <CUP>
            'If Not String.IsNullOrWhiteSpace(row.Item("Y").ToString) AndAlso row.Item("Y").ToString <> "." Then
            '    isCigOrCup = True
            '    dr = dt.NewRow
            '    dr("DocID") = id
            '    dr("DocSubID") = 0
            '    dr("Line") = line
            '    dr("SubLine") = 0
            '    dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiOrdineAcquisto.CodiceCUP"
            '    dr("FieldValue") = row.Item("Y").ToString
            '    dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
            '    dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
            '    dt.Rows.Add(dr)
            'End If
            ''2.1.2.7 <CIG>
            'If Not String.IsNullOrWhiteSpace(row.Item("X").ToString) AndAlso row.Item("X").ToString <> "." Then
            '    isCigOrCup = True
            '    dr = dt.NewRow
            '    dr("DocID") = id
            '    dr("DocSubID") = 0
            '    dr("Line") = line
            '    dr("SubLine") = 0
            '    dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiOrdineAcquisto.CodiceCIG"
            '    dr("FieldValue") = row.Item("X").ToString
            '    dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
            '    dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
            '    dt.Rows.Add(dr)
            'End If
        End If

        If Not String.IsNullOrWhiteSpace(row.Item("ID").ToString) Then
            writeSomething = True
            Dim newlineDDT As Integer
            'Id documento 2.1.8 DatiDDT
            Dim key As Object() = {id, 0, 0, "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiDDT.NumeroDDT"}
            dt.DefaultView.Sort = "DocId, DocSubID, SubLine, FieldName "
            Dim drv As DataRowView() = dt.DefaultView.FindRows(key)
            If drv.Length > 0 Then
                'nel caso di piu' righe mi prendo la prima e pace.
                'possibile incongruenza ma iniziamo cosi'
                newlineDDT = drv(0).Item("Line")
            Else
                newlineDDT = 1
            End If

            '2.1.8.1 <NumeroDDT>
            dr = dt.NewRow
            dr("DocID") = id
            dr("DocSubID") = 0
            dr("Line") = newlineDDT
            dr("SubLine") = 0
            dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiDDT.NumeroDDT"
            dr("FieldValue") = "xxx" '"nrDDT"
            dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
            dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
            dt.Rows.Add(dr)

            '2.1.8.2 <DataDDT>
            dr = dt.NewRow
            dr("DocID") = id
            dr("DocSubID") = 0
            dr("Line") = newlineDDT
            dr("SubLine") = 0
            dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiDDT.DataDDT"
            dr("FieldValue") = MagoFormatta(row.Item("ID").ToString, GetType(DateTime)).sDataSlash
            dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
            dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
            dt.Rows.Add(dr)

            '2.1.8.3 <RiferimentoNumeroLinea>
            dr = dt.NewRow
            dr("DocID") = id
            dr("DocSubID") = 0
            dr("Line") = newlineDDT
            dr("SubLine") = subLine
            dr("FieldName") = "FatturaElettronica.FatturaElettronicaBody.DatiGenerali.DatiDDT.RiferimentoNumeroLinea"
            dr("FieldValue") = row.Item("BA").ToString
            dr("TBCreatedID") = My.Settings.mLOGINID 'ID utente
            dr("TBModifiedID") = My.Settings.mLOGINID 'ID utente
            dt.Rows.Add(dr)

        End If
        Return writeSomething
    End Function

    Public Function FattureT(ByVal dts As DataSet, Optional ByVal bConIntestazione As Boolean = False) As Boolean
        'QUESTO CSV HA I VALORI MONETARI SENZA PUNTI O VIRGOLE, IL DATO E' AI 2 DECIMALI
        'ESEMPIO 7377 = 73,77 € ( COLONNE T,U, V,W, X)
        'Documenti di vendita - MA_SaleDoc
        'Lo uso solo per leggere dei valori che sono assenti dal file FTP300
        'non lo uso leggo tutto dal FTPA300
        Dim stopwatch As New System.Diagnostics.Stopwatch
        Dim okBulk As Boolean
        stopwatch.Start()
        EditTestoBarra("Creo Fatture")
        FLogin.prgCopy.Value = 1
        'Inizializzo un datatable al file xls e un datarow con tutte le righe
        Dim dtXLS As DataTable = dts.Tables("Foglio1")
        Dim drXLS As DataRow() = dtXLS.Select()
        If drXLS.Length > 0 Then
            'Identificatore  Documento
            Debug.Print("Estraggo ID")
            EditTestoBarra("Estraggo gli ID")
            Dim idDoc As Integer = LeggiID(IdType.DocVend)
            FLogin.prgCopy.Maximum = drXLS.Length
            FLogin.prgCopy.Step = 1
            Try
                'Creo Datatable con valori di DEFAULT nelle colonne
                EditTestoBarra("Carico Schema: Fatture")
                Using dtDoc As DataTable = CaricaSchema("MA_SaleDoc")
                    EditTestoBarra("Carico Schema: Righe")
                    Using dtDocDet As DataTable = CaricaSchema("MA_SaleDocDetail")
                        EditTestoBarra("Scrittura documenti")
                        ' Ciclo le righe del file XLS
                        'Posso chiamare le Colonne con la stessa logica di Excel A,B,C o con i Numeri
                        Dim irxls As Integer = 0
                        Dim i As Integer = 0
                        If bConIntestazione Then i = 1 ' Se c'e' l'intestazione parto dalla seconda riga

                        'La tabella xls e' strutturata diversamente controllo i TIREH
                        'TIREH Colonna G = 1=Testata 3=Riga Fattura 6=Riga descrittiva 9=Riepilogo fattura
                        'SEQUH Colonna I = contatore righe ma forse non serve

                        For irxls = i To drXLS.Length - 1
                            'Inizializzo la nuova riga
                            Dim drDoc As DataRow = dtDoc.NewRow
                            Dim drDocDet As DataRow = dtDocDet.NewRow
                            ' accorcio per comodità di scrittura
                            With drXLS(irxls)
                                'TIREH Colonna G = 1=Testata 3=Riga Fattura 6=Riga descrittiva 9=Riepilogo fattura
                                Select Case .Item("G").ToString
                                    Case "1" 'Testata ovvero nuova Fattura
                                        idDoc += 1 ' Incremento Id
                                        'TP01H Colonna M = fattura o nota di credito
                                        'Controllare meglio con nuovo formato Ade altrimenti creare un nuovo tipo dati e gestire
                                        drDoc("DocumentType") = If(.Item("U").ToString = "F", 3407874, If(.Item("U").ToString = "A", 3407875, 3407876))
                                        Debug.Print("riga " & .Item("I").ToString & " fatt: " & .Item("O").ToString)
                                        drDoc("DocNo") = .Item("O").ToString()
                                        drDoc("DocumentDate") = MagoFormatta(.Item("Q").ToString, GetType(DateTime)).DataTempo
                                        'drDoc( "AccTpl", "FE") ' FE o NE
                                        drDoc("TaxJournal") = .Item("N").ToString
                                        drDoc("CustSupptype") = CustSuppType.Cliente ' 3211264 = Cliente
                                        drDoc("CustSupp") = .Item("AA").ToString
                                        'drDoc("Payment")=.Item("W").ToString
                                        drDoc("InstallmStartDate") = MagoFormatta(.Item("Q").ToString, GetType(DateTime)).DataTempo
                                        drDoc("PostingDate") = MagoFormatta(.Item("Q").ToString, GetType(DateTime)).DataTempo
                                        'drDoc("CustomerBank") = .Item("W").ToString
                                        'drDoc("CompanyBank") = .Item("W").ToString
                                        'drDoc("SendDocumentTo") = IF(.Item("AA").ToString = .Item(""), "", .Item("AA")
                                        drDoc("InvoiceFollows") = "0"
                                        drDoc("Currency") = If(.Item("R").ToString = "EUR", "EUR", .Item("O").ToString)
                                        drDoc("YourReference") = .Item("H").ToString
                                        drDoc("ContractCode") = .Item("X").ToString 'CIG
                                        drDoc("ProjectCode") = .Item("Y").ToString 'CUP
                                        'drDoc("Area") = .Item("H").ToString
                                        'drDoc("AreaManager") = .Item("H").ToString
                                        'drDoc("SalePerson") = .Item("X").ToString
                                        drDoc("AccrualPercAtInvoiceDate") = 100
                                        drDoc("Issued") = "1" 'Emessa?
                                        drDoc("SaleDocId") = idDoc
                                        drDoc("DeliveryTerms") = 5963782
                                        drDoc("CountryOfDestination") = "IT"
                                        drDoc("DepartureDate") = MagoFormatta(.Item("Q").ToString, GetType(DateTime)).DataTempo
                                        'drDoc( "CompanyCA")= .Item("H").ToString
                                        drDoc("Presentation") = 1376260
                                        drDoc("ValueDate") = MagoFormatta(.Item("Q").ToString, GetType(DateTime)).DataTempo
                                        'drDoc( "LastSubId")= .Item("H").ToString ( lo ottengo dopo)
                                        drDoc("IntrastatAccrualDate") = MagoFormatta(.Item("Q").ToString, GetType(DateTime)).DataTempo
                                        drDoc("SalespersonCommAuto") = "0"
                                        drDoc("AreaManagerCommAuto") = "0"
                                        drDoc("SalespersonCommPercAuto") = "0"
                                        drDoc("AreaManagerCommPercAuto") = "0"
                                        drDoc("IntrastatBis") = "1"
                                        'drDoc("WorkerIDIssue") = 1 'ID utente
                                        drDoc("CountryOfPayment") = "IT"
                                        drDoc("ActionOnLifoFifo") = 26411008
                                        drDoc("ModifyOriginalPymtSched") = "0"
                                        drDoc("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                        drDoc("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                                        'Aggiungo la riga all'insieme Rows del Datatable
                                        dtDoc.Rows.Add(drDoc)
                                    Case "3", "6"
                                        ''''''''''''''''''''''
                                        'Righe MA_SaleDocDetail
                                        ''''''''''''''''''''''
                                        drDocDet("SaleDocId") = idDoc
                                        drDocDet("Line") = CInt(.Item("BA").ToString)
                                        'Merce o servizio???
                                        drDocDet("LineType") = If(.Item("G").ToString = "3", LineType.Merce, LineType.Nota)
                                        drDocDet("Item") = .Item("BG").ToString
                                        drDocDet("Description") = .Item("BH").ToString
                                        drDocDet("UoM") = .Item("BI").ToString
                                        'drDocDEt( "Qty")= .Item("BJ").ToString
                                        drDocDet("Qty") = 1
                                        drDocDet("UnitValue") = MagoFormatta(.Item("BM").ToString, GetType(Double)).STRinga
                                        drDocDet("TaxableAmount") = MagoFormatta(.Item("BN").ToString, GetType(Double)).STRinga
                                        'Convertire valore in quello corretto di Mago
                                        drDocDet("TaxCode") = .Item("CQ").ToString
                                        drDocDet("TotalAmount") = MagoFormatta((.Item("BM") * .Item("CR")).ToString, GetType(Double)).STRinga
                                        'drDocDEt( "SendDocumentsTo")= .Item("CT").ToString 'DEFINIRE MEGLIO 
                                        drDocDet("IncludedInTurnover") = "1"
                                        drDocDet("DocumentDate") = MagoFormatta(.Item("Q").ToString, GetType(DateTime)).DataTempo
                                        drDocDet("CustSupptype") = CustSuppType.Cliente ' 3211264 = Cliente
                                        drDocDet("CustSupp") = .Item("AA").ToString
                                        'drDocDEt( "SubId")= 0 ' gestire
                                        'drDocDEt( "InvoiceId")= 0 'Solo su Note di Credito
                                        'drDocDEt( "InvoiceSubId")= 0 'Solo su Note di Credito
                                        'drDocDEt( "DocIdToBeUnloaded")= 0 'Solo su Note di Credito
                                        drDocDet("DepartureDate") = MagoFormatta(.Item("Q").ToString, GetType(DateTime)).DataTempo
                                        drDocDet("ReferenceDocType") = If(.Item("U").ToString = "F", 3407874, If(.Item("U").ToString = "A", 3407875, 3407876))
                                        'drDocDEt( "CRRefType")= 0 'Solo su Note di Credito
                                        'drDocDEt( "CRRefID")= 0 'Solo su Note di Credito
                                        'drDocDEt( "CRRefSubID")= 0 'Solo su Note di Credito
                                        'drDocDEt( "NetPrice")= .Item("BM").ToString
                                        drDocDet("InEI") = "1"
                                        drDocDet("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                                        drDocDet("TBModifiedID") = My.Settings.mLOGINID 'ID utente

                                        'Aggiungo la riga all'insieme Rows del Datatable
                                        dtDocDet.Rows.Add(drDocDet)
                                    Case "9"
                                        'magari li posso leggere dall'anagrafica
                                        'Riga di totale, mi servono solo alcuni dati, i totali li calcola mago
                                        'Dim sUpdate As String = "UPDATE MA_SaleDoc SET "

                                        'AddFUpdate(Of String)(cmd, sUpdate, "Payment", .Item("FI").ToString)
                                        'Dim sbanca As String = (.Item("FJ").ToString & "-" & .Item("FK").ToString)
                                        'AddFUpdate(Of String)(cmd, sUpdate, "CustomerBank", IF(sbanca = "-", "", sbanca))

                                End Select
                            End With
                            'Debug.Print("Fatt: " & iNrRighe.ToString() & " " & stopwatch2.Elapsed.ToString())
                            AvanzaBarra()
                        Next
                        EditTestoBarra("Salvataggio: Fatture")
                        Using bulkTrans = Connection.BeginTransaction
                            okBulk = ScriviBulk("MA_SaleDoc", dtDoc, bulkTrans, Connection)
                            EditTestoBarra("Salvataggio: Righe")
                            okBulk = ScriviBulk("MA_SaleDocDetail", dtDocDet, bulkTrans, Connection)
                            EditTestoBarra("Commit in corso")
                            bulkTrans.Commit()
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Debug.Print(ex.Message)
                Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
                mb.ShowDialog()
            End Try
            'Scrivi Gli ID ( faccio solo a fine elaborazione)
            AggiornaID(IdType.DocVend, idDoc)

            Debug.Print("Gestione MA_SaleDoc" & " " & stopwatch.Elapsed.ToString)

        End If
        stopwatch.Stop()
        Return okBulk

    End Function
End Module

Module LINQ_UNUSED
    ''https://newbedev.com/how-to-convert-datatable-to-Class-object
    'Public Shared connectionString As String = ConfigurationManager.ConnectionStrings("YourWebConfigConnection").ConnectionString

    'Function CreateListFromTable(Of T As New)(ByVal tbl As DataTable) As List(Of T)
    '    Dim lst As List(Of T) = New List(Of T)()

    '    For Each r As DataRow In tbl.Rows
    '        lst.Add(CreateItemFromRow(Of T)(r))
    '    Next

    '    Return lst
    'End Function

    'Function CreateItemFromRow(Of T As New)(ByVal row As DataRow) As T
    '    Dim item As T = New T()
    '    SetItemFromRow(item, row)
    '    Return item
    'End Function

    'Sub SetItemFromRow(Of T As New)(ByVal item As T, ByVal row As DataRow)
    '    For Each c As DataColumn In row.Table.Columns
    '        Dim p As PropertyInfo = item.[GetType]().GetProperty(c.ColumnName)

    '        If p IsNot Nothing AndAlso row(c) <> DBNull.Value Then
    '            p.SetValue(item, row(c), Nothing)
    '        End If
    '    Next
    'End Sub

    'Function GetRecordWithExtendedTimeOut(ByVal SPName As String, ParamArray SqlPrms As SqlParameter()) As DataSet
    '    Dim ds As New DataSet()
    '    Dim cmd As New SqlCommand()
    '    Dim da As New SqlDataAdapter()
    '    Dim con As SqlConnection = New SqlConnection(connectionString)

    '    Try
    '        cmd = New SqlCommand(SPName, con)
    '        cmd.Parameters.AddRange(SqlPrms)
    '        cmd.CommandTimeout = 240
    '        cmd.CommandType = CommandType.StoredProcedure
    '        da.SelectCommand = cmd
    '        da.Fill(ds)
    '    Catch ex As Exception
    '        Return ex
    '    End Try

    '    Return ds
    'End Function
    'End Class


End Module