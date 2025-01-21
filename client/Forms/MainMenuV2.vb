Public Class MainMenuV2
    Private MenuScreen As HomeForm
    Private Sub MainMenuV2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        InitializeToolStrip()
        ShowHomeForm()
    End Sub

    Private Sub InitializeToolStrip()
        Dim toolTip As New ToolTip()

        toolTip.InitialDelay = 100           ' Show tooltip faster (default is 500ms)
        toolTip.AutoPopDelay = 5000          ' How long tooltip remains visible (default is 5000ms)
        toolTip.ReshowDelay = 100            ' Delay before showing tooltip on next control (default is 100ms)
        toolTip.UseAnimation = True          ' Animate tooltip appearance
        toolTip.UseFading = True             ' Fade tooltip in/out
        toolTip.IsBalloon = True             ' Use standard tooltip style (or True for balloon style)

        toolTip.SetToolTip(btnHome, "Home page")
        toolTip.SetToolTip(btnPos, "Process sales and transactions")
        toolTip.SetToolTip(btnInventory, "Manage stocks")
    End Sub

    Private Sub btnPos_Click(sender As Object, e As EventArgs) Handles btnPos.Click
        Me.Hide()
        POSForm.Show()
        POSForm.LoadProducts()
        ActiveButton(1)
    End Sub

    Public Sub ActiveButton(index As Integer)
        Dim thickness As Integer = 3

        Select Case index
            Case 0
                btnHome.CustomBorderColor = Color.FromArgb(76, 45, 23)
                btnHome.CustomBorderThickness = New Padding(0, 0, 0, thickness)
                btnPos.CustomBorderThickness = New Padding(0, 0, 0, 0)
                btnInventory.CustomBorderThickness = New Padding(0, 0, 0, 0)
            Case 1
                btnPos.CustomBorderColor = Color.FromArgb(76, 45, 23)
                btnHome.CustomBorderThickness = New Padding(0, 0, 0, 0)
                btnPos.CustomBorderThickness = New Padding(0, 0, 0, thickness)
                btnInventory.CustomBorderThickness = New Padding(0, 0, 0, 0)
            Case 2
                btnInventory.CustomBorderColor = Color.FromArgb(76, 45, 23)
                btnHome.CustomBorderThickness = New Padding(0, 0, 0, 0)
                btnPos.CustomBorderThickness = New Padding(0, 0, 0, 0)
                btnInventory.CustomBorderThickness = New Padding(0, 0, 0, thickness)
        End Select
    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        ShowHomeForm()
    End Sub

    Private Sub btnInventory_Click(sender As Object, e As EventArgs) Handles btnInventory.Click
        ShowInventoryForm()
    End Sub

    Private Sub ShowHomeForm()
        Dim homefrm As New HomeForm()
        ShowFormInPanel(homefrm)
        ActiveButton(0)
    End Sub

    Private Sub ShowInventoryForm()
        Dim invfrm As New InventoryForm()
        ShowFormInPanel(invfrm)
        ActiveButton(2)
    End Sub

    Public Sub ShowFormInPanel(ByVal childForm As Form)
        pnlMain.Controls.Clear()

        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill

        pnlMain.Controls.Add(childForm)
        childForm.Show()

        If TypeOf childForm Is OrderForm Then
            MenuScreen = DirectCast(childForm, HomeForm)
        Else
            MenuScreen = Nothing
        End If
    End Sub

End Class