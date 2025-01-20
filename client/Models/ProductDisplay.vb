Imports Guna.UI2.WinForms
Public Class ProductDisplay
    Inherits UserControl

    Private ReadOnly flowPanel As FlowLayoutPanel
    Private ReadOnly gunaScrollBar As Guna2VScrollBar

    Public Sub New(products As List(Of Product))
        ' Initialize the FlowLayoutPanel
        flowPanel = New FlowLayoutPanel() With {
            .Dock = DockStyle.Fill,
            .AutoScroll = True,
            .WrapContents = True,
            .FlowDirection = FlowDirection.LeftToRight,
            .Padding = New Padding(10),
            .Margin = New Padding(0)
        }

        gunaScrollBar = New Guna2VScrollBar() With {
            .Dock = DockStyle.Right,
            .FillColor = Color.LightGray,
            .ThumbColor = Color.DarkGray,
            .BorderRadius = 5,
        .Width = 2
        }

        gunaScrollBar.BindingContainer = flowPanel

        ' Add product cards to the FlowLayoutPanel
        For Each product In products
            Dim productCard = CreateProductCard(product)
            flowPanel.Controls.Add(productCard)
        Next

        Me.Controls.Add(gunaScrollBar)
        Me.Controls.Add(flowPanel)
    End Sub

    Private Function CreateProductCard(product As Product) As Panel
        Dim cardPanel As New Panel() With {
            .Width = 190,
            .Height = 270,
            .BackColor = Color.White,
            .Margin = New Padding(10),
            .Padding = New Padding(10)
        }

        ' PictureBox for product image
        Dim picProductImage As New PictureBox() With {
            .Image = Image.FromFile(product.ImagePath),
            .SizeMode = PictureBoxSizeMode.StretchImage,
            .Width = 140,
            .Height = 90,
            .Location = New Point(25, 15)
        }

        ' Label for product name
        Dim lblProductName As New Label() With {
            .Text = product.Name,
            .Font = New Font("Segoe UI", 14, FontStyle.Bold),
            .AutoSize = False,
            .TextAlign = ContentAlignment.MiddleLeft,
            .Width = 150,
            .Top = 120,
            .Left = 5
        }

        ' Label for product description
        Dim lblDescription As New Label() With {
            .Text = product.Description,
            .Font = New Font("Segoe UI", 8, FontStyle.Regular),
            .AutoSize = False,
            .Height = 40,
            .Width = 150,
            .TextAlign = ContentAlignment.MiddleLeft,
            .Top = 150,
            .Left = 6
        }

        ' Label for product price
        Dim lblPrice As New Label() With {
            .Text = "₱ " & product.Price.ToString("F2"),
            .Font = New Font("Segoe UI", 12, FontStyle.Bold),
            .ForeColor = Color.Brown,
            .AutoSize = False,
            .TextAlign = ContentAlignment.MiddleLeft,
            .Width = 150,
            .Top = 190,
            .Left = 5
        }

        ' Button for "Add to Cart"
        Dim btnAddToCart As New Guna2Button() With {
            .Text = "Add to Cart",
            .Dock = DockStyle.Bottom,
            .FillColor = Color.FromArgb(255, 204, 204),
            .Image = Image.FromFile("E:\Visual Studio 2013 Ultimate Projects\Capstone-Project\client\client\Resources\Icons\Shopping Bag.png")
        }
        btnAddToCart.HoverState.FillColor = Color.FromArgb(255, 153, 153)
        AddHandler btnAddToCart.Click, AddressOf btnAddToCart_Click

        Dim pnlBackground As New Panel() With {
            .Dock = DockStyle.Top,
            .Height = 100,
            .BackColor = Color.FromArgb(255, 204, 204)
        }

        ' Add controls to the card panel
        cardPanel.Controls.Add(picProductImage)
        cardPanel.Controls.Add(lblProductName)
        cardPanel.Controls.Add(lblDescription)
        cardPanel.Controls.Add(lblPrice)
        cardPanel.Controls.Add(btnAddToCart)
        cardPanel.Controls.Add(pnlBackground)

        Return cardPanel
    End Function

    Private Sub btnAddToCart_Click(sender As Object, e As EventArgs)
        MsgBox("Added to cart!", vbInformation, "Test")
    End Sub

End Class
