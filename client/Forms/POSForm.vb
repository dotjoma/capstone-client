Imports System.Threading
Imports System.ComponentModel
Public Class POSForm
    Private POSScreen As OrderForm
    Private Skeleton As OrderSkeleton
    Public isLoading As Boolean
    Private LoadingCount As Integer = 0

    Private Sub POSForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        tLoading.Start()
        InitializeToolStrip()
        SetOrderActive()
    End Sub

    Public Sub LoadProducts()
        isLoading = True
        pnlHeaderWindow.Visible = True
        pnlHeader.Height = 1000

        bgWorker.WorkerReportsProgress = True
        bgWorker.WorkerSupportsCancellation = True
        bgWorker.RunWorkerAsync()

        'bgLoadingWorker.RunWorkerAsync()
    End Sub

    'Private Sub bgLoadingWorker_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgLoadingWorker.DoWork
    'ShowSkeletonInPanel(New OrderSkeleton()) ' Cause of ui freeze/hang.
    ' End Sub

    Private Sub bgWorker_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgWorker.DoWork
        ShowOrderForm()
        Thread.Sleep(500)
    End Sub

    'Private Sub bgLoadingWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgLoadingWorker.RunWorkerCompleted
    '  GC.Collect()
    ' End Sub

    Private Sub bgWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgWorker.RunWorkerCompleted
        pnlHeader.Height = 52
        pnlHeaderWindow.Visible = False
        isLoading = False
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If isLoading Then Return
        Me.Hide()
        MainMenuV2.Show()
        MainMenuV2.ActiveButton(0)
        MainMenuV2.ShowFormInPanel(New HomeForm())
    End Sub

    Public Sub ShowFormInPanel(ByVal childForm As Form)
        If pnlMainWindow.InvokeRequired Then
            pnlMainWindow.Invoke(New Action(Of Form)(AddressOf ShowFormInPanel), childForm)
        Else
            pnlMainWindow.Controls.Clear()
            childForm.TopLevel = False
            childForm.FormBorderStyle = FormBorderStyle.None
            childForm.Dock = DockStyle.Fill
            pnlMainWindow.Controls.Add(childForm)
            childForm.Show()
            POSScreen = If(TypeOf childForm Is OrderForm, DirectCast(childForm, OrderForm), Nothing)
        End If
    End Sub

    Public Sub ShowSkeletonInPanel(ByVal childForm As Form)
        If pnlHeaderWindow.InvokeRequired Then
            pnlHeaderWindow.Invoke(New Action(Of Form)(AddressOf ShowSkeletonInPanel), childForm)
            Return
        End If
        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        pnlHeaderWindow.Controls.Add(childForm)
        childForm.Show()
        Skeleton = If(TypeOf childForm Is OrderSkeleton, DirectCast(childForm, OrderSkeleton), Nothing)
    End Sub

    Private Sub btnOrder_Click(sender As Object, e As EventArgs) Handles btnOrder.Click
        If isLoading Then Return
        StartSetOrderActiveWorkerAsync()
    End Sub

    Public Async Sub StartSetOrderActiveWorkerAsync()
        isLoading = True
        Await Task.Run(Sub() SetOrderActive())
        LoadProducts()
    End Sub

    Private Sub btnProduct_Click(sender As Object, e As EventArgs) Handles btnProduct.Click
        If isLoading Then Return
        ShowProductForm()
    End Sub

    Public Sub SetOrderActive()
        btnOrder.CustomBorderColor = Color.FromArgb(76, 45, 23)
        btnOrder.CustomBorderThickness = New Padding(5, 0, 0, 0)
        btnProduct.CustomBorderThickness = New Padding(0, 0, 0, 0)
    End Sub

    Public Sub SetProductActive()
        btnProduct.CustomBorderColor = Color.FromArgb(76, 45, 23)
        btnProduct.CustomBorderThickness = New Padding(5, 0, 0, 0)
        btnOrder.CustomBorderThickness = New Padding(0, 0, 0, 0)
    End Sub

    Private Sub ShowOrderForm()
        Dim orderfrm As New OrderForm()
        SetOrderActive()
        ShowFormInPanel(orderfrm)
    End Sub

    Private Sub ShowProductForm()
        Dim productfrm As New ProductForm()
        SetProductActive()
        ShowFormInPanel(productfrm)
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
    End Sub ' ToolStrip

    Private Sub tLoading_Tick(sender As Object, e As EventArgs) Handles tLoading.Tick
        LoadingCount += 1
        Select Case LoadingCount
            Case 1
                lblLoading.Text = "Loading."
            Case 2
                lblLoading.Text = "Loading.."
            Case 3
                lblLoading.Text = "Loading..."
            Case Else
                LoadingCount = 0
        End Select
    End Sub
End Class