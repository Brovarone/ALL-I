Module Produttori
    Public Function TrovaAgente(ByVal codice As String, filiale As String) As String
        Dim esito As String
        Select Case filiale.ToUpper
            Case "01" ' Torino
                Select Case codice.ToUpper
                    Case "017"
                        esito = "UUUUUU"    'UFFICIO
                    Case Else
                        esito = "01TO_XXX"
                End Select
            Case "02" ' Milano
                Select Case codice.ToUpper
                    Case "017"
                        esito = "UUUUUU"    'UFFICIO
                    Case Else
                        esito = "02MI_XXX"
                End Select
            Case "03" 'Asti
                Select Case codice.ToUpper
                    Case "017"
                        esito = "UUUUUU"    'UFFICIO
                    Case Else
                        esito = "03AT_XXX"
                End Select
            Case "04" 'Aosta
                Select Case codice.ToUpper
                    Case "017"
                        esito = "UUUUUU"    'UFFICIO
                    Case Else
                        esito = "04AO_XXX"
                End Select
            Case "05" ' Novara
                Select Case codice.ToUpper
                    Case "017"
                        esito = "UUUUUU"    'UFFICIO
                    Case Else
                        esito = "05NO_XXX"
                End Select
            Case "08" 'Biella / Vigliano
                Select Case codice.ToUpper
                    Case "017"
                        esito = "UFFICIO"    'UFFICIO
                    Case "018"
                        esito = "BURATTI"    'BURATTI PAOLO
                    Case "019"
                        esito = "AULETTA"    'AULETTA ANDREA
                    Case "020"
                        esito = "CARDAMON"    'CARDAMONE UPPOLITO
                    Case "021"
                        esito = "GIULIANI"    'GIULIANI
                    Case "022"
                        esito = "LUPA"    'LUPA
                    Case "023"
                        esito = "BOZZA P"    'BOZZA PIERO
                    Case "024"
                        esito = "BONO"    'BONO ROBERTO
                    Case "025"
                        esito = "SILVESTR"    'SILVESTRI
                    Case "026"
                        esito = "NEGRO"    'NEGRO DANIELE
                    Case "N01"
                        esito = "BERTUCCI"
                    Case "N02"
                        esito = "AUDISIO"
                    Case "N03"
                        esito = "NICOTRA"
                    Case "N04"
                        esito = "GIANNI"
                    Case "N05"
                        esito = "GILETTI"
                    Case "N06"
                        esito = "GUERRIERO"
                    Case "N07"
                        esito = "GIORDANO"
                    Case "N08"
                        esito = "PAGANOTT"
                    Case "N09"
                        esito = "ARCHE"
                    Case "N10"
                        esito = "VSYSTEM"
                    Case "N11"
                        esito = "MORARDO"
                    Case Else
                        esito = "08BI_XXX"
                End Select
            Case "09" ' Varese
                Select Case codice.ToUpper
                    Case "017"
                        esito = "UFFICIO"    'UFFICIO
                    Case "030"
                        esito = "AULETTA"
                    Case "M66"
                        esito = "SECURGES"    'UFFICIO
                    Case "M95"
                        esito = "SECURGES"    'UFFICIO
                    Case "N08"
                        esito = "PAGANOTT"
                    Case "S65"
                        esito = "SECURGES"    'UFFICIO
                    Case "U30"
                        esito = "DABIZZI"    'UFFICIO
                    Case Else
                        esito = "09VA_XXX"
                End Select
            Case "10" ' Sede
                Select Case codice.ToUpper
                    Case "017"
                        esito = "UUUUUU"    'UFFICIO
                    Case Else
                        esito = "10_XXX"
                End Select
            Case "11" ' Cuneo
                Select Case codice.ToUpper
                    Case "017"
                        esito = "UUUUUU"    'UFFICIO
                    Case Else
                        esito = "11CN_XXX"
                End Select
            Case "12" ' Alessandria
                Select Case codice.ToUpper
                    Case "017"
                        esito = "UUUUUU"    'UFFICIO
                    Case Else
                        esito = "11AL_XXX"
                End Select
            Case Else
                esito = "XYZ"
        End Select

        Return esito
    End Function
End Module
