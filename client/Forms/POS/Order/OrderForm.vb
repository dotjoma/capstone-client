Public Class OrderForm
    Private Sub OrderForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer.Start()
        ' Mock data
        Dim products As New List(Of Product) From {
            New Product With {.Name = "Product 1", .Description = "This is the description for Product 1.", .Price = 10.99, .ImagePath = "E:\Visual Studio 2013 Ultimate Projects\Capstone-Project\client\client\Resources\Images\ramen.png"},
            New Product With {.Name = "Product 2", .Description = "This is the description for Product 2.", .Price = 15.49, .ImagePath = "E:\Visual Studio 2013 Ultimate Projects\Capstone-Project\client\client\Resources\Images\ramen.png"},
            New Product With {.Name = "Product 3", .Description = "This is the description for Product 3.", .Price = 7.89, .ImagePath = "E:\Visual Studio 2013 Ultimate Projects\Capstone-Project\client\client\Resources\Images\ramen.png"},
            New Product With {.Name = "Product 4", .Description = "This is the description for Product 4.", .Price = 25.0, .ImagePath = "E:\Visual Studio 2013 Ultimate Projects\Capstone-Project\client\client\Resources\Images\ramen.png"},
            New Product With {.Name = "Product 5", .Description = "This is the description for Product 5.", .Price = 12.0, .ImagePath = "E:\Visual Studio 2013 Ultimate Projects\Capstone-Project\client\client\Resources\Images\ramen.png"},
            New Product With {.Name = "Product 6", .Description = "This is the description for Product 6.", .Price = 20.0, .ImagePath = "E:\Visual Studio 2013 Ultimate Projects\Capstone-Project\client\client\Resources\Images\ramen.png"},
            New Product With {.Name = "Product 6", .Description = "This is the description for Product 6.", .Price = 20.0, .ImagePath = "E:\Visual Studio 2013 Ultimate Projects\Capstone-Project\client\client\Resources\Images\ramen.png"},
            New Product With {.Name = "Product 6", .Description = "This is the description for Product 6.", .Price = 20.0, .ImagePath = "E:\Visual Studio 2013 Ultimate Projects\Capstone-Project\client\client\Resources\Images\ramen.png"},
            New Product With {.Name = "Product 6", .Description = "This is the description for Product 6.", .Price = 20.0, .ImagePath = "E:\Visual Studio 2013 Ultimate Projects\Capstone-Project\client\client\Resources\Images\ramen.png"},
            New Product With {.Name = "Product 6", .Description = "This is the description for Product 6.", .Price = 20.0, .ImagePath = "E:\Visual Studio 2013 Ultimate Projects\Capstone-Project\client\client\Resources\Images\ramen.png"},
            New Product With {.Name = "Product 6", .Description = "This is the description for Product 6.", .Price = 20.0, .ImagePath = "E:\Visual Studio 2013 Ultimate Projects\Capstone-Project\client\client\Resources\Images\ramen.png"},
            New Product With {.Name = "Product 6", .Description = "This is the description for Product 6.", .Price = 20.0, .ImagePath = "E:\Visual Studio 2013 Ultimate Projects\Capstone-Project\client\client\Resources\Images\ramen.png"},
            New Product With {.Name = "Product 6", .Description = "This is the description for Product 6.", .Price = 20.0, .ImagePath = "E:\Visual Studio 2013 Ultimate Projects\Capstone-Project\client\client\Resources\Images\ramen.png"},
            New Product With {.Name = "Product 6", .Description = "This is the description for Product 6.", .Price = 20.0, .ImagePath = "E:\Visual Studio 2013 Ultimate Projects\Capstone-Project\client\client\Resources\Images\ramen.png"}
        }

        ' Create an instance of ProductDisplay and add it to the form
        Dim display As New ProductDisplay(products) With {
            .Dock = DockStyle.Fill
        }

        ' Add the display to the form's controls
        pnlDisplay.Controls.Add(display)
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        lblDay.Text = DateTime.Now.ToString("dddd") & ", " & StrConv(DateTime.Now.ToString("hh:mm:ss tt"), VbStrConv.Uppercase)
        lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy")
    End Sub
End Class