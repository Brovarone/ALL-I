Imports System.Reflection.MethodBase

Public Module Analitica
    Public Function AggiornaSaldoAnalitico(ByVal conto As String, centro As String, anno As Short, mese As Short, isDebit As Boolean, valore As Double, vista As DataView) As Boolean
        Dim result As Boolean
        Dim found As Integer = vista.Find({centro, conto})
        Try
            If found <> -1 Then
                With vista(found)
                    .BeginEdit()
                    If isDebit Then
                        .Item("ActualDebit") += valore
                    Else
                        .Item("ActualCredit") += valore
                    End If
                    .EndEdit()
                End With
            Else
                Dim r As DataRow = vista.Table.NewRow
                r.Item("CostCenter") = centro
                r.Item("Account") = conto
                r.Item("FiscalYear") = anno
                r.Item("BalanceYear") = anno
                r.Item("BalanceType") = 3145730
                r.Item("BalanceMonth") = mese
                If isDebit Then
                    r.Item("ActualDebit") = valore
                    r.Item("ActualCredit") = 0
                Else
                    r.Item("ActualDebit") = 0
                    r.Item("ActualCredit") = valore
                End If
                r.Item("BudgetDebitQty") = 0
                r.Item("ActualDebitQty") = 0
                r.Item("ForecastDebitQty") = 0
                r.Item("BudgetCreditQty") = 0
                r.Item("ActualCreditQty") = 0
                r.Item("ForecastCreditQty") = 0
                r.Item("BudgetDebit") = 0
                r.Item("ForecastDebit") = 0
                r.Item("BudgetCredit") = 0
                r.Item("ForecastCredit") = 0
                r.Item("TBCreatedID") = My.Settings.mLOGINID 'ID utente
                r.Item("TBModifiedID") = My.Settings.mLOGINID 'ID utente
                vista.Table.Rows.Add(r)
            End If
        Catch ex As Exception
            Debug.Print(ex.Message)
            Dim mb As New MessageBoxWithDetails(ex.Message, GetCurrentMethod.Name, ex.StackTrace)
            mb.ShowDialog()
        End Try

        Return result
    End Function

End Module

