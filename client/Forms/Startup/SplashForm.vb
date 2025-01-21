Imports System.Threading
Public Class SplashForm
    Private count As Integer = 3
    Private Sub StartUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblYear.Text = Now.Year
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        count -= 1
        If count <= 0 Then
            Timer1.Stop()
            Me.Hide()
            LoginForm.Show()
        End If
        Thread.Sleep(1000)
    End Sub
End Class