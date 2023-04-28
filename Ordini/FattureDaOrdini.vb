Imports System.Data.SqlClient
Imports System.Text
Imports System.Reflection.MethodBase

Module FattureDaOrdini

    ''' <summary>
    ''' Adegua le righe fatture con una query di Update
    ''' </summary>
    ''' <param name="filtri"></param>
    ''' <param name="MyReturnString"></param>
    ''' <returns></returns>
    Public Function AdeguaFattureDaOrdini(filtri As FiltroAnalitica, Optional ByRef MyReturnString As String = "") As Boolean
        'dati succhiati dal filtro
        Dim fromDate As Date = filtri.DataDA
        Dim todate As Date = filtri.DataA
        Dim nrFirst As String = filtri.NumberFirst
        Dim nrLast As String = filtri.NumberLast
        Dim allNumbers As Boolean = filtri.AllNumbers
        Dim sFromDate As String = fromDate.ToString("yyyyMMdd")
        Dim sToDate As String = todate.ToString("yyyyMMdd")

        Dim s As New StringBuilder()
        Dim sMsg As String
        Try
            s.Append("Update MA_SaleDocDetail SET ALL_CanoniDataI = Ord.ALL_CanoniDataI , ALL_CanoniDataF = Ord.ALL_CanoniDataF, ALL_NrCanoni = Ord.ALL_NrCanoni, TBModified = @DataMod , TBModifiedID = @User ")
            s.Append("From MA_SaleDoc Testa INNER JOIN MA_SaleDocDetail Doc ON Testa.SaleDocId = Doc.SaleDocId INNER Join MA_SaleOrdDetails Ord ON Ord.SaleOrdId = Doc.SaleOrdId And Ord.SubId = Doc.SaleOrdSubId ")
            s.Append("WHERE (Doc.LineType = " & LineType.Merce & " OR Doc.LineType = " & LineType.Servizio & ") ")
            s.Append("AND (Testa.DocumentType=" & DocumentType.Fattura & " Or Testa.DocumentType=" & DocumentType.FatturaAccompagnatoria & " Or Testa.DocumentType=" & DocumentType.NotaCredito & ") ")
            s.Append("AND (Testa.DocumentDate >=@FromDate  And Testa.DocumentDate <=@ToDate ) ")
            s.Append("AND (@AllNumbers = 1 Or (@AllNumbers = 0 And Testa.DocNo >=@NrFirst And Testa.DocNo <=@NrLast )) ")
            s.Append("AND Doc.ALL_CanoniDataI = '17991231' ")

            Using cmd = New SqlCommand(s.ToString, Connection)
                cmd.Transaction = Trans
                cmd.Parameters.AddWithValue("@FromDate", sFromDate)
                cmd.Parameters.AddWithValue("@ToDate", sToDate)
                cmd.Parameters.AddWithValue("@AllNumbers", allNumbers)
                cmd.Parameters.AddWithValue("@NrFirst", nrFirst)
                cmd.Parameters.AddWithValue("@NrLast", nrLast)
                cmd.Parameters.AddWithValue("@DataMod", Now.ToString("yyyyMMdd"))
                cmd.Parameters.AddWithValue("@User", My.Settings.mLOGINID)

                Dim irows As Integer = cmd.ExecuteNonQuery()
                If irows <= 0 Then
                    sMsg = "Nessun documento di vendita da aggiornare"
                Else
                    sMsg = "Adeguate " & irows.ToString & " righe."
                End If
            End Using

            If String.IsNullOrWhiteSpace(MyReturnString) Then
                My.Application.Log.WriteEntry(sMsg)
            Else
                MyReturnString = sMsg
            End If

        Catch ex As Exception
            Debug.Print(ex.Message)
            Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
            mb.ShowDialog()
            Return False
        End Try
        Return True
    End Function

End Module
