''                                                                                      
''  Name:                                                                               
''                                                                                      
''      CustomProgress                                                                  
''                                                                                      
''  Description:                                                                        
''                                                                                      
''      ProgressBar that allows display of custom text or percentage progress.          
''                                                                                      
''  Custom Properties:                                                                  
''                                                                                      
''      Text:     String    If Null then % progress is calculated and displayed, else   
''                the value of the string is displayed.                                 
''                                                                                      
''  Audit:                                                                              
''                                                                                      
''      2019-04-18  rj  Original Code                                                   
''                                                                                      
Public Class CustomProgress
        Inherits ProgressBar
        Public Overrides Property Text As String
        Private Const WmPaint = 15
        'WndProc receives all messages directed to the current window. In order to
        'avoid overwriting your text, make sure the default code executes first,
        'then call the custom routine to display the overlid text.
        Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
            MyBase.WndProc(m)
            If m.Msg = WmPaint Then PaintText()
        End Sub
    Private Sub PaintText()
        Dim s As String = Text
        'Display either a percentage or custom text
        If s = "" Then
            Dim percent = CInt((Value - Minimum) * 100 / (Maximum - Minimum))
            s = percent.ToString & "%"
        End If
        'Get the graphics object and calculate drawing parameters based on the current Font specs
        Using g = Me.CreateGraphics()
            Dim textSize = g.MeasureString(s, Me.Font)
            Using b = New SolidBrush(ForeColor)
                g.DrawString(s, Me.Font, Brushes.Black, Me.Width / 2 - textSize.Width / 2, Me.Height / 2 - textSize.Height / 2)
            End Using
        End Using
    End Sub

End Class