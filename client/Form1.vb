Imports System.Text
Imports System.Net
Imports System.Net.Sockets
Public Class Form1
    Private client As TcpClient
    Private serverIp As String = "127.0.0.1" ' Change to your server's IP address
    Private serverPort As Integer = 13000 ' Change to your server's port
    Private stream As NetworkStream
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        Cursor = Cursors.WaitCursor
        Call ConnectToServer()
    End Sub

    Private Sub btnDisconnect_Click(sender As Object, e As EventArgs) Handles btnDisconnect.Click
        Call DisconnectToServer()
    End Sub

    Public Sub ConnectToServer()
        Try
            client = New TcpClient(serverIp, serverPort) ' Connect to the server
            AppendTextToConsole("Connected to server.")
            ' Send a message to the server
            Dim message As String = "Hello, Server!"
            Dim data As Byte() = Encoding.ASCII.GetBytes(message)
            Dim stream As NetworkStream = client.GetStream()
            stream.Write(data, 0, data.Length)
            AppendTextToConsole("Sent: " & message)

            ' Optionally, receive a response from the server
            Dim responseData As Byte() = New Byte(256) {}
            Dim bytes As Int32 = stream.Read(responseData, 0, responseData.Length)
            Dim responseMessage As String = Encoding.ASCII.GetString(responseData, 0, bytes)
            AppendTextToConsole("Received: " & responseMessage)

        Catch ex As Exception
            AppendTextToConsole("Error: " & ex.Message)
        Finally
            GC.Collect()
            Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub DisconnectToServer()
        Try
            If client Is Nothing Then
                AppendTextToConsole("Not connected to server.")
                Return
            End If

            If stream IsNot Nothing Then
                stream.Close() ' Close the network stream
            End If

            If client IsNot Nothing Then
                client.Close() ' Close the TcpClient
                client = Nothing ' Set client to Nothing
                AppendTextToConsole("Disconnected from server.")
            End If
        Catch ex As Exception
            AppendTextToConsole("Error during disconnection: " & ex.Message)
        End Try
    End Sub

    Private Sub AppendTextToConsole(text As String)
        ' Use Invoke to update the UI from a different thread
        If console.InvokeRequired Then
            console.Invoke(New Action(Of String)(AddressOf AppendTextToConsole), text)
        Else
            console.AppendText(text & Environment.NewLine)
        End If
    End Sub
End Class
