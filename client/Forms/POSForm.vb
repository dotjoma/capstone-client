Public Class POSForm
    Private POSScreen As OrderForm
    Private Sub POSForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        InitializeToolStrip()
        ShowOrderForm()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Hide()
        MainMenuV2.Show()
        MainMenuV2.ActiveButton(0)
        MainMenuV2.ShowFormInPanel(New HomeForm())
    End Sub

    Public Sub ShowFormInPanel(ByVal childForm As Form)
        pnlMain.Controls.Clear()

        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill

        pnlMain.Controls.Add(childForm)
        childForm.Show()

        If TypeOf childForm Is OrderForm Then
            POSScreen = DirectCast(childForm, OrderForm)
        Else
            POSScreen = Nothing
        End If
    End Sub

    Private Sub InitializeToolStrip()
        Dim toolTip As New ToolTip()

        toolTip.InitialDelay = 100           ' Show tooltip faster (default is 500ms)
        toolTip.AutoPopDelay = 5000          ' How long tooltip remains visible (default is 5000ms)
        toolTip.ReshowDelay = 100            ' Delay before showing tooltip on next control (default is 100ms)
        toolTip.UseAnimation = True          ' Animate tooltip appearance
        toolTip.UseFading = True             ' Fade tooltip in/out
        toolTip.IsBalloon = True             ' Use standard tooltip style (or True for balloon style)

        toolTip.SetToolTip(btnBack, "Back to home")
    End Sub

    Private Sub btnOrder_Click(sender As Object, e As EventArgs) Handles btnOrder.Click
        ShowOrderForm()
    End Sub

    Private Sub btnProduct_Click(sender As Object, e As EventArgs) Handles btnProduct.Click
        ShowProductForm()
    End Sub

    Private Sub SetOrderActive()
        btnOrder.CustomBorderColor = Color.FromArgb(76, 45, 23)
        btnOrder.CustomBorderThickness = New Padding(5, 0, 0, 0)

        btnProduct.CustomBorderThickness = New Padding(0, 0, 0, 0)
    End Sub

    Private Sub SetProductActive()
        btnProduct.CustomBorderColor = Color.FromArgb(76, 45, 23)
        btnProduct.CustomBorderThickness = New Padding(5, 0, 0, 0)

        btnOrder.CustomBorderThickness = New Padding(0, 0, 0, 0)
    End Sub

    Private Sub ShowOrderForm()
        Dim orderfrm As New OrderForm()
        ShowFormInPanel(orderfrm)
        SetOrderActive()
    End Sub

    Private Sub ShowProductForm()
        Dim productfrm As New ProductForm()
        ShowFormInPanel(productfrm)
        SetProductActive()
    End Sub

End Class