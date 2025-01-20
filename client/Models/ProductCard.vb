Imports Guna.UI2.WinForms
Public Class ProductCard
    Inherits UserControl

    Private lblProductName As Label
    Private lblDescription As Label
    Private lblPrice As Label
    Private btnAddToCart As Guna2Button
    Private picProductImage As PictureBox
    Private gunaPanel As Guna2Panel

    Public Sub New(product As Product)
        ' Initialize controls
        lblProductName = New Label()
        lblDescription = New Label()
        lblPrice = New Label()
        btnAddToCart = New Guna2Button()
        picProductImage = New PictureBox()
        gunaPanel = New Guna2Panel()

        ' Set properties for the GunaPanel
        gunaPanel.BackColor = Color.White
        gunaPanel.BorderColor = Color.Gray
        gunaPanel.BorderThickness = 1
        gunaPanel.BorderRadius = 5
        gunaPanel.Width = 200
        gunaPanel.Height = 300
        gunaPanel.Padding = New Padding(10)

        ' Set properties for the PictureBox
        picProductImage.Image = Image.FromFile(product.ImagePath)
        picProductImage.SizeMode = PictureBoxSizeMode.StretchImage
        picProductImage.Width = gunaPanel.Width - 20
        picProductImage.Height = 120
        picProductImage.Location = New Point(10, 10)

        ' Set properties for the labels
        lblProductName.Text = product.Name
        lblProductName.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        lblProductName.AutoSize = True
        lblProductName.Location = New Point(10, picProductImage.Bottom + 10)

        lblDescription.Text = product.Description
        lblDescription.Font = New Font("Segoe UI", 8, FontStyle.Regular)
        lblDescription.ForeColor = Color.Gray
        lblDescription.AutoSize = True
        lblDescription.MaximumSize = New Size(gunaPanel.Width - 20, 0) ' Wrap text
        lblDescription.Location = New Point(10, lblProductName.Bottom + 5)

        lblPrice.Text = "₹ " & product.Price.ToString("F2")
        lblPrice.ForeColor = Color.Brown
        lblPrice.Font = New Font("Arial", 10, FontStyle.Bold)
        lblPrice.AutoSize = True
        lblPrice.Location = New Point(10, lblDescription.Bottom + 10)

        ' Set properties for the button
        btnAddToCart.Text = "Add to Cart"
        btnAddToCart.Width = gunaPanel.Width - 20
        btnAddToCart.Height = 40
        btnAddToCart.Location = New Point(10, lblPrice.Bottom + 10)
        btnAddToCart.FillColor = Color.FromArgb(255, 204, 204) ' Light color for the button
        btnAddToCart.HoverState.FillColor = Color.FromArgb(255, 153, 153) ' Darker color on hover
        AddHandler btnAddToCart.Click, AddressOf btnAddToCart_Click

        ' Arrange controls in the GunaPanel
        gunaPanel.Controls.Add(picProductImage)
        gunaPanel.Controls.Add(lblProductName)
        gunaPanel.Controls.Add(lblDescription)
        gunaPanel.Controls.Add(lblPrice)
        gunaPanel.Controls.Add(btnAddToCart)

        ' Set the UserControl properties
        Me.Controls.Add(gunaPanel)
        Me.Width = gunaPanel.Width
        Me.Height = gunaPanel.Height + 10
    End Sub

    Private Sub btnAddToCart_Click(sender As Object, e As EventArgs)
        MessageBox.Show(lblProductName.Text & " added to cart!")
    End Sub
End Class
