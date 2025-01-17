
Public Class Form1
    

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        Cursor = Cursors.WaitCursor
        Call ConnectToServer()
    End Sub

    Private Sub btnDisconnect_Click(sender As Object, e As EventArgs) Handles btnDisconnect.Click
        Call DisconnectToServer()
    End Sub

End Class
