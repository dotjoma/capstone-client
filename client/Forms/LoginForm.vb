Imports System.Threading
Imports System.Net.Sockets
Imports System.Text
Public Class LoginForm
    Private isPasswordVisible As Boolean = False
    Private isDragging As Boolean = False
    Private dragCursor As Point
    Private dragForm As Point
    Public serverThread As Thread

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblYear.Text = Now.Year
        txtPassword.UseSystemPasswordChar = True
        ' serverThread = New Thread(AddressOf ConnectToServer)
        ' serverThread.IsBackground = True
        ' serverThread.Start()
    End Sub

    Private Sub btnExit_MouseEnter(sender As Object, e As EventArgs) Handles btnExit.MouseEnter
        btnExit.BackColor = Color.FromArgb(255, 91, 54, 27)
    End Sub

    Private Sub btnExit_MouseLeave(sender As Object, e As EventArgs) Handles btnExit.MouseLeave
        btnExit.BackColor = Color.Transparent
    End Sub

    Private Sub btnMinimize_MouseEnter(sender As Object, e As EventArgs) Handles btnMinimize.MouseEnter
        btnMinimize.BackColor = Color.FromArgb(255, 91, 54, 27)
    End Sub

    Private Sub btnMinimize_MouseLeave(sender As Object, e As EventArgs) Handles btnMinimize.MouseLeave
        btnMinimize.BackColor = Color.Transparent
    End Sub

    Private Sub CursorHand()
        Cursor = Cursors.Hand
    End Sub

    Private Sub CursorDefault()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        If MsgBox("Are you sure you want to exit?", vbQuestion + vbYesNo, "Exit application") = vbYes Then
            For i As Integer = Application.OpenForms.Count - 1 To 0 Step -1
                Application.OpenForms(i).Close()
            Next

            Environment.Exit(0)
        End If
    End Sub

    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Panel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Panel1.MouseDown
        Mouse_Down()
    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        Mouse_Move()
    End Sub

    Private Sub Panel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Panel1.MouseUp
        Mouse_Up()
    End Sub

    Private Sub Label1_MouseDown(sender As Object, e As MouseEventArgs) Handles Label1.MouseDown
        Mouse_Down()
    End Sub

    Private Sub Label1_MouseMove(sender As Object, e As MouseEventArgs) Handles Label1.MouseMove
        Mouse_Move()
    End Sub

    Private Sub Label1_MouseUp(sender As Object, e As MouseEventArgs) Handles Label1.MouseUp
        Mouse_Up()
    End Sub

    Private Sub Mouse_Down()
        isDragging = True
        dragCursor = Cursor.Position
        dragForm = Me.Location
    End Sub

    Private Sub Mouse_Move()
        If isDragging Then
            Dim newPosition As Point = dragForm + (Cursor.Position - dragCursor)
            Me.Location = newPosition
        End If
    End Sub

    Private Sub Mouse_Up()
        isDragging = False
    End Sub

    Private Sub btnShowHidePassword_Click(sender As Object, e As EventArgs) Handles btnShowHidePassword.Click
        isPasswordVisible = Not isPasswordVisible

        If isPasswordVisible Then
            txtPassword.UseSystemPasswordChar = False
            btnShowHidePassword.Image = My.Resources.HideY
        Else

            btnShowHidePassword.Image = My.Resources.EyeY
            txtPassword.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub btnForgotPass_MouseEnter(sender As Object, e As EventArgs) Handles btnForgotPass.MouseEnter
        btnForgotPass.Font = New Font(btnForgotPass.Font, FontStyle.Underline)
        CursorHand()
    End Sub

    Private Sub btnForgotPass_MouseLeave(sender As Object, e As EventArgs) Handles btnForgotPass.MouseLeave
        btnForgotPass.Font = New Font(btnForgotPass.Font, FontStyle.Regular)
        CursorDefault()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = Trim(txtUsername.Text)
        Dim password As String = Trim(txtPassword.Text)

        If Not Validation(username, password) Then
            Return
        End If

        Dim loginSuccess As Boolean = RequestLogin(username, password)

        If loginSuccess Then
            MsgBox("Login successful!")
            Me.Hide()
            MainForm.Show()
        Else
            MsgBox("Login failed. Please check your credentials.")
        End If

    End Sub

    Private Function RequestLogin(username As String, password As String) As Boolean
        Using clientSocket As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
            Dim serverIp As String = Config.AppConfig.GetIP()
            Dim serverPort As Integer = Config.AppConfig.GetPort()

            Try
                ' Connect to the server
                clientSocket.Connect(serverIp, serverPort)

                ' Prepare the login data
                Dim loginData As String = username & ":" & password
                Dim dataToSend As Byte() = Encoding.UTF8.GetBytes(loginData)

                ' Send the login request
                clientSocket.Send(dataToSend)

                ' Receive the response
                Dim buffer(1024) As Byte
                Dim bytesReceived As Integer = clientSocket.Receive(buffer) ' Corrected 'Buffer' to 'buffer'
                Dim response As String = Encoding.UTF8.GetString(buffer, 0, bytesReceived)

                ' Check the response
                If response.StartsWith("SUCCESS") Then ' Use StartsWith to allow for more detailed responses
                    Return True
                Else
                    MsgBox("Login failed: " & response) ' Show the response message for better feedback
                    Return False
                End If
            Catch ex As Exception
                ' Handle any exceptions (e.g., connection issues)
                MsgBox("An error occurred: " & ex.Message)
                Return False
            Finally
                ' Close the socket
                clientSocket.Close()
            End Try
        End Using
    End Function

    Private Function Validation(username As String, password As String)

        If String.IsNullOrEmpty(username) Or String.IsNullOrEmpty(password) Then
            MsgBox("Please enter both username and password.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        Return True
    End Function

End Class