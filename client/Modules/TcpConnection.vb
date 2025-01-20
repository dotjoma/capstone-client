Imports System.Text
Imports System.Net
Imports System.Net.Sockets
Imports System.Configuration
Imports System.Threading
Module TcpConnection
    Private client As TcpClient
    Private serverIp As String = ConfigurationManager.AppSettings("ServerIp")
    Private serverPort As Integer = ConfigurationManager.AppSettings("ServerPort")
    Private stream As NetworkStream
    Private rtb As RichTextBox

    Public Sub ConnectToServer()
        Try
            client = New TcpClient(serverIp, serverPort) ' Connect to the server
            AppendTextToConsole(rtb, "Connected to server.")

            ' Send a message to the server
            Dim message As String = "Ping!"
            Dim data As Byte() = Encoding.ASCII.GetBytes(message)
            Dim stream As NetworkStream = client.GetStream()
            stream.Write(data, 0, data.Length)
            AppendTextToConsole(rtb, "Sent: " & message)

            ' Optionally, receive a response from the server
            Dim responseData As Byte() = New Byte(256) {}
            Dim bytes As Int32 = stream.Read(responseData, 0, responseData.Length)
            Dim responseMessage As String = Encoding.ASCII.GetString(responseData, 0, bytes)
            AppendTextToConsole(rtb, "Received: " & responseMessage)

        Catch ex As Exception
            AppendTextToConsole(rtb, "Error: " & ex.Message)
            MsgBox("A connection could not be established. A complete log can be found in the log file.", MsgBoxStyle.Critical, "Error")
            Logger.LogError(ex.Message.ToString())
            Application.Exit()
        Finally
            GC.Collect()
            Form1.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub DisconnectToServer()
        Try
            If client Is Nothing Then
                AppendTextToConsole(rtb, "Not connected to server.")
                Return
            End If

            If stream IsNot Nothing Then
                stream.Close() ' Close the network stream
            End If

            If client IsNot Nothing Then
                client.Close() ' Close the TcpClient
                client = Nothing ' Set client to Nothing

                AppendTextToConsole(rtb, "Disconnected from server.")
            End If
        Catch ex As Exception
            AppendTextToConsole(rtb, "Error during disconnection: " & ex.Message)
        End Try
    End Sub

    Private Sub AppendTextToConsole(console As RichTextBox, text As String)
        If Form1.console.InvokeRequired Then
            Form1.console.Invoke(New Action(Sub() AppendTextToConsole(console, text)))
        Else
            Form1.console.AppendText(text & Environment.NewLine)
        End If
    End Sub

End Module
