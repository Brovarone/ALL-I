Module TipoServizio
    Public Function TranscodificaServizio(ByVal codice As String) As String
        Dim esito As String
        Select Case codice.ToUpper
            Case "AC"
                esito = "APECHIU"
            Case "B1"
            Case "C1"
            Case "CA"
            Case "CC"
                esito = "TENUTA CHIAVI"
            Case "CO"
                esito = "COLL ALLARME"
            Case "CT"
                esito = "COLL COMBINAT"
            Case "CTKG"
                esito = "GPRS"
            Case "CV"
            Case "IV"
            Case "KA"
            Case "KG"
            Case "KN"
            Case "KP"
            Case "L1"
            Case "MA"
            Case "NO"
                esito = ""
            Case "O1"
            Case "P1"
                esito = "PRONTO IN.TERZI"
            Case "PA"
            Case "PD"
            Case "PI"
                esito = "PRONTO INTERVEN"
            Case "PR"
                esito = "COLL RADIO"
            Case "R1"

            Case "RE"
                esito = "RONDA ELE"
            Case "RB"
                esito = "ISPEZIONI"
            Case "RO"
                esito = "BOLLATURA"
            Case "RS"
            Case "SN"
            Case "TD"
                esito = "TELEFONIA DEDIC"
            Case "TS"
                esito = "TELESOCCORSO"
            Case "VV"
                esito = "VIDEOISPEZIONI"
            Case "VX"
            Case "YA"

            Case Else
                esito = "XXXXX"

        End Select
        Return esito
    End Function

End Module
