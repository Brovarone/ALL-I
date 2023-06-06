Imports System.Reflection.MethodBase
Imports ALLSystemTools

Public Module Analitica
    ''' <summary>
    ''' Uguale a quella in Fatture
    ''' </summary>
    Public Class MySaldoAnalitico
        Public Property Conto As String
        Public Property Centro As String
        Public Property Anno As Short
        Public Property Mese As Short
        Public Property BalanceType As Integer

        Public Sub New()
            Conto = ""
            Centro = ""
            Anno = CShort(Year(Now))
            Mese = CShort(Month(Now))
            BalanceType = 3145730 'Standard
        End Sub
    End Class
    Public Function AggiornaSaldoAnalitico(filtri As MySaldoAnalitico, isDebit As Boolean, valore As Double, vista As DataView) As Boolean
        Dim result As Boolean
        vista.Sort = "CostCenter,Account,BalanceYear,BalanceMonth,BalanceType"
        ' vista.RowFilter = "BalanceType=3145730"
        Dim found As Integer = vista.Find({filtri.Centro, filtri.Conto, filtri.Anno, filtri.Mese, 3145730})
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
                r.Item("CostCenter") = filtri.Centro
                r.Item("Account") = filtri.Conto
                r.Item("FiscalYear") = filtri.Anno
                r.Item("BalanceYear") = filtri.Anno
                r.Item("BalanceType") = 3145730
                r.Item("BalanceMonth") = filtri.Mese
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
        vista.RowFilter = ""
        Return result
    End Function

End Module

