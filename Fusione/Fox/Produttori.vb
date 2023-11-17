Module Produttori
    Public Function TrovaAgente(ByVal codice As String, filiale As String) As String
        Dim esito As String
        Select Case filiale.ToUpper
            Case "01" ' Torino
                Select Case codice.ToUpper
                    Case "006"
                    Case "017"
                        esito = "UFFICIO"
                    Case "C01"
                    Case "C02"
                    Case "C09"
                    Case "C10"
                    Case "C11"
                    Case "C15"
                    Case "C22"
                    Case "C27"
                    Case "C39"
                    Case "C41"
                    Case "C42"
                        esito = "UFFICIO"
                    Case "C47"
                        esito = "AULETTA"
                    Case "C49"
                    Case "C50"
                    Case "C51"
                    Case "C53"
                    Case "C54"
                    Case "UDT"

                    Case Else
                        esito = "01TO_XXX"
                End Select
            Case "02" ' Milano
                Select Case codice.ToUpper
                    Case "01"
                    Case "012"
                    Case "03"
                        esito = "UFFICIO"
                    Case "A10"
                    Case "CSV"
                        esito = "AULETTA"
                    Case "D1"
                    Case "D2"
                    Case "D3"
                    Case "FIL"
                    Case "FIL."
                    Case "K10"
                        esito = "SECURGEST"
                    Case "K70"
                        esito = "SECURGEST"
                    Case "K80"
                        esito = "SECURGEST"
                    Case "K90"
                        esito = "SECURGEST"
                    Case "M55"
                        esito = "SECURGEST"
                    Case "M56"
                        esito = "SECURGEST"
                    Case "M58"
                        esito = "SECURGEST"
                    Case "M66"
                        esito = "FURLAN"
                    Case "M68"
                        esito = "SECURGEST"
                    Case "M75"
                        esito = "SECURGEST"
                    Case "M85"
                        esito = "SECURGEST"
                    Case "M90"
                        esito = "SECURGEST"
                    Case "N08"
                        esito = "PAGANOTT"
                    Case "S60"
                        esito = "SECURGEST"
                    Case "S65"
                        esito = "SECURGEST"
                    Case "S75"
                        esito = "SECURGEST"
                    Case "U35"
                        esito = "SECURGEST"
                    Case "U66"
                        esito = "SECURGEST"
                    Case "UFF"
                        esito = "VALLOSIO"

                    Case Else
                        esito = "02MI_XXX"
                End Select
            Case "03" 'Asti
                Select Case codice.ToUpper
                    Case "01"
                        esito = "AULETTA"
                    Case "017"
                        esito = "UFFICIO"
                    Case "10"
                        esito = "ZUNINO"
                    Case "2"
                        esito = "NAPOLI"
                    Case "4"
                        esito = "DABIZZI"
                    Case "6"
                        esito = "UUUUUU"
                    Case "S01"
                        esito = "RISPOLI"
                    Case "V01"
                        esito = "UUUUUU"
                    Case Else
                        esito = "03AT_XXX"
                End Select
            Case "04" 'Aosta
                Select Case codice.ToUpper
                    Case "001"
                        esito = "UFFICIO"
                    Case "010"
                        esito = "AULETTA"
                    Case "020"
                        esito = "COSTANTI"
                    Case "030"
                        esito = "LABATE"
                    Case "040"
                        esito = "UUUUUU"
                    Case "050"
                        esito = "UFFICIO"
                    Case "060"
                        esito = "COGES"
                    Case "070"
                        esito = "COGES"
                    Case "090"
                        esito = "MAGRO"
                    Case "110"
                        esito = "VENTURIN"
                    Case "120"
                        esito = "UFFICIO"
                    Case "150"
                        esito = "UFFICIO"
                    Case Else
                        esito = "04AO_XXX"
                End Select
            Case "05" ' Novara
                Select Case codice.ToUpper
                    Case "017"
                        esito = "UFFICIO"
                    Case "C41"
                    Case "C42"
                        esito = "SECURGEST"
                    Case "C44"
                        esito = "BOZZA P"
                    Case "C47"
                    Case "C50"
                    Case "C52"
                    Case "C53"
                        esito = "AULETTA"
                    Case "N08"
                        esito = "PAGANOTT"

                    Case Else
                        esito = "05NO_XXX"
                End Select
            Case "08" 'Biella / Vigliano
                Select Case codice.ToUpper
                    Case "017"
                        esito = "UFFICIO"
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
                        esito = "UFFICIO"
                    Case "030"
                        esito = "AULETTA"
                    Case "M66"
                        esito = "SECURGES"
                    Case "M95"
                        esito = "SECURGES"
                    Case "N08"
                        esito = "PAGANOTT"
                    Case "S65"
                        esito = "SECURGES"
                    Case "U30"
                        esito = "DABIZZI"
                    Case Else
                        esito = "09VA_XXX"
                End Select
            Case "10" ' Sede
                Select Case codice.ToUpper
                    Case "017"
                        esito = "UUUUUU"
                    Case Else
                        esito = "10_XXX"
                End Select
            Case "11" ' Cuneo
                Select Case codice.ToUpper
                    Case "001"
                    Case "002"
                    Case "003"
                    Case "004"
                    Case "005"
                        esito = "UFFICIO"
                    Case "006"
                    Case "008"
                    Case "009"
                    Case "010"
                    Case "012"
                    Case "014"
                    Case "016"
                    Case "017"
                    Case "018"
                    Case "019"
                    Case "020"
                        esito = "AULETTA"
                    Case "021"
                    Case "022"
                    Case "023"
                    Case "030"
                    Case "031"
                    Case "032"
                        esito = "AULETTA"
                    Case "1"
                    Case "3"
                        esito = "AULETTA"
                    Case "4"
                    Case "7"
                    Case "8"
                    Case "900"
                    Case "N02"
                    Case "N10"


                    Case Else
                        esito = "11CN_XXX"
                End Select
            Case "12" ' Alessandria
                Select Case codice.ToUpper
                    Case "01"
                        esito = "AULETTA"
                    Case "017"
                        esito = "UFFICIO"
                    Case "02"
                        esito = "GIORDANE"
                    Case "11"
                        esito = "DALINO"
                    Case "15"
                        esito = "BOZZA P"
                    Case "17"
                        esito = "LAROCCA"
                    Case "18"
                        esito = "MORGANA"
                    Case "357"
                        esito = "ZUNINO"
                    Case "4"
                        esito = "SECURGES"
                    Case "9"
                        esito = "VALLOSIO"
                    Case "966"
                        esito = "UNION DE"
                    Case "N07"
                        esito = "GIORDANO"
                    Case "S01"
                        esito = "RISPOLI"
                    Case Else
                        esito = "11AL_XXX"
                End Select
            Case Else
                esito = "XYZ"
        End Select

        Return esito
    End Function
End Module
