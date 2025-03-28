Imports System.IO
Imports Microsoft.VisualBasic.FileIO
Public Class TestaPaghe
    'Miglioramenti aggiuntivi
    'Gestione degli errori
    'Validazione dati
    'Conversione dei tipi

    ' Filler0: 6 caratteri di riempimento (non specificato il contenuto)
    Public Property Filler0 As String

    ' DataDoc: 6 caratteri, formato AAMMGG (Anno, Mese, Giorno) della data del documento
    Public Property DataDoc As String

    ' Filler1: 16 caratteri di riempimento (non specificato il contenuto)
    Public Property Filler1 As String

    ' Causale: 3 caratteri, codice della causale del documento
    Public Property Causale As String

    ' Filler2: 12 caratteri di riempimento (non specificato il contenuto)
    Public Property Filler2 As String

    ' Giorni: 2 caratteri, numero di giorni (probabilmente per termini di pagamento o simili)
    Public Property Giorni As String

    ' Filler3: 33 caratteri di riempimento (non specificato il contenuto)
    Public Property Filler3 As String

    ' Prot: 6 caratteri, numero di protocollo del documento
    Public Property Prot As String

    ' Filler4: 39 caratteri di riempimento (non specificato il contenuto)
    Public Property Filler4 As String

    ' CdC: 2 caratteri, codice del centro di costo
    Public Property CdC As String

    ' Filler5: 49 caratteri di riempimento (non specificato il contenuto)
    Public Property Filler5 As String

    ' Riferimento: 7 caratteri, riferimento del documento (0000010 per testate PN causali 267, 0000020 per PN causali 216)
    Public Property Riferimento As String

    ' Filler6: 30 caratteri di riempimento (non specificato il contenuto)
    Public Property Filler6 As String

    ' Utente: 8 caratteri, identificativo dell'utente che ha creato il record
    Public Property Utente As String

    ' DataReg: 6 caratteri, formato AAMMGG (Anno, Mese, Giorno) della data di registrazione
    Public Property DataReg As String

    ' NrRif: 6 caratteri, numero di riferimento
    Public Property NrRif As String

    ' NrSequenza: 2 caratteri, numero di sequenza
    Public Property NrSequenza As String

    ' CdCMago: 8 caratteri, codice del centro di costo di Mago (sistema gestionale), da valorizzare con una tabella di transcodifica
    Public Property CdCMago As String

    ' Funzione per parsare una riga di testo e creare un'istanza di TestataRecord
    Public Shared Function Parse(currentLine As String) As TestaPaghe
        Dim record As New TestaPaghe()
        Using strStream = New StringReader(currentLine)
            Using MyReader As New TextFieldParser(strStream)
                MyReader.TextFieldType = FieldType.FixedWidth
                MyReader.FieldWidths = {6, 6, 16, 3, 12, 2, 33, 6, 39, 2, 49, 7, 30, 8, 6, 6, 2}
                Try
                    Dim fields As String() = MyReader.ReadFields()
                    If fields IsNot Nothing AndAlso fields.Length = 17 Then
                        record.Filler0 = fields(0)
                        record.DataDoc = fields(1)
                        record.Filler1 = fields(2)
                        record.Causale = fields(3)
                        record.Filler2 = fields(4)
                        record.Giorni = fields(5)
                        record.Filler3 = fields(6)
                        record.Prot = fields(7)
                        record.Filler4 = fields(8)
                        record.CdC = fields(9)
                        record.Filler5 = fields(10)
                        record.Riferimento = fields(11)
                        record.Filler6 = fields(12)
                        record.Utente = fields(13)
                        record.DataReg = fields(14)
                        record.NrRif = fields(15)
                        record.NrSequenza = fields(16)
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
