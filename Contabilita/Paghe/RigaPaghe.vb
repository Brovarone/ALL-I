Imports System.IO
Imports Microsoft.VisualBasic.FileIO
Public Class RigaPaghe
    'Miglioramenti aggiuntivi
    'Gestione degli errori
    'Validazione dati
    'Conversione dei tipi
    ' Filler0: 1 carattere di riempimento (non specificato il contenuto)
    Public Property Filler0 As String

    ' CdC: 2 caratteri, codice del centro di costo
    Public Property CdC As String

    ' Filler1: 21 caratteri di riempimento (non specificato il contenuto)
    Public Property Filler1 As String

    ' Prot: 6 caratteri, numero di protocollo
    Public Property Prot As String

    ' Imponibile: 13 caratteri, importo imponibile (ultimi 2 decimali)
    Public Property Imponibile As String

    ' CodIva: 2 caratteri, codice IVA
    Public Property CodIva As String

    ' Imposta: 11 caratteri, importo dell'imposta
    Public Property Imposta As String

    ' Filler2: 2 caratteri di riempimento (non specificato il contenuto)
    Public Property Filler2 As String

    ' Filler3: 13 caratteri di riempimento (non specificato il contenuto)
    Public Property Filler3 As String

    ' ContoDare: 12 caratteri, codice del conto Dare
    Public Property ContoDare As String

    ' ContoAvere: 12 caratteri, codice del conto Avere
    Public Property ContoAvere As String

    ' Filler4: 14 caratteri di riempimento (non specificato il contenuto)
    Public Property Filler4 As String

    ' Continua: 1 carattere, "C" per dettagli, " " per l'ultimo dettaglio
    Public Property Continua As String

    ' TotaleDoc: 13 caratteri, totale del documento (solo sull'ultima riga, somma degli imponibili)
    Public Property TotaleDoc As String

    ' Cdc1: 2 caratteri, un altro codice del centro di costo
    Public Property Cdc1 As String

    ' Filler5: 49 caratteri di riempimento (non specificato il contenuto)
    Public Property Filler5 As String

    ' Riferimento: 7 caratteri, riferimento (0000010 per testate PN causali 267, 0000020 per PN causali 216)
    Public Property Riferimento As String

    ' Filler6: 30 caratteri di riempimento (non specificato il contenuto)
    Public Property Filler6 As String

    ' Utente: 8 caratteri, identificativo dell'utente
    Public Property Utente As String

    ' DataReg: 6 caratteri, data di registrazione in formato AAMMGG
    Public Property DataReg As String

    ' NrRif: 6 caratteri, numero di riferimento
    Public Property NrRif As String

    ' NrSequenza: 2 caratteri, numero di sequenza
    Public Property NrSequenza As String

    ' CdCMago: 8 caratteri, codice del centro di costo di Mago (sistema gestionale), da valorizzare con una tabella di transcodifica
    Public Property CdCMago As String

    ' Funzione per parsare una riga di testo e creare un'istanza di RigaRecord
    Public Shared Function Parse(currentLine As String) As RigaPaghe
        Dim record As New RigaPaghe()
        Using strStream = New StringReader(currentLine)
            Using MyReader As New TextFieldParser(strStream)
                MyReader.TextFieldType = FieldType.FixedWidth
                MyReader.FieldWidths = {1, 2, 21, 6, 13, 2, 11, 2, 13, 12, 12, 14, 1, 13, 2, 49, 7, 30, 8, 6, 6, 2}
                Try
                    Dim fields As String() = MyReader.ReadFields()
                    If fields IsNot Nothing AndAlso fields.Length = 22 Then
                        record.Filler0 = fields(0)
                        record.CdC = fields(1)
                        record.Filler1 = fields(2)
                        record.Prot = fields(3)
                        record.Imponibile = fields(4)
                        record.CodIva = fields(5)
                        record.Imposta = fields(6)
                        record.Filler2 = fields(7)
                        record.Filler3 = fields(8)
                        record.ContoDare = fields(9)
                        record.ContoAvere = fields(10)
                        record.Filler4 = fields(11)
                        record.Continua = fields(12)
                        record.TotaleDoc = fields(13)
                        record.Cdc1 = fields(14)
                        record.Filler5 = fields(15)
                        record.Riferimento = fields(16)
                        record.Filler6 = fields(17)
                        record.Utente = fields(18)
                        record.DataReg = fields(19)
                        record.NrRif = fields(20)
                        record.NrSequenza = fields(21)
                    Else
                        Return Nothing
                    End If
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
                    Return Nothing
                End Try
            End Using
        End Using
        Return record
    End Function
End Class
