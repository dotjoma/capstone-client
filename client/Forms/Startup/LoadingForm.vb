Imports System.Threading
Public Class LoadingForm
    Private count As Integer = 2

    Public Sub New()
        InitializeComponent()
        Timer1.Start()
    End Sub

    Private Sub StartUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblYear.Text = Now.Year
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If count > 0 Then
            count -= 1
            Thread.Sleep(1000)
        Else
            Timer1.Stop()
            Me.Hide()
            Call Form1.Show()
        End If
    End Sub
End Class