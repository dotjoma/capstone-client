Imports System.IO
Public Class Logger
    Private Shared ReadOnly LogFilePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "logs.txt")

    Public Shared Sub LogInfo(message As String)
        WriteLog("INFO", message)
    End Sub

    Public Shared Sub LogWarning(message As String)
        WriteLog("WARNING", message)
    End Sub

    ' Method to log errors
    Public Shared Sub LogError(message As String)
        WriteLog("ERROR", message)
    End Sub

    ' Private method to write to the log file
    Private Shared Sub WriteLog(logType As String, message As String)
        Try
            Dim logMessage As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & " [" & logType & "] " & message
            Dim directoryPath As String = Path.GetDirectoryName(LogFilePath)

            ' Ensure the directory exists
            If Not Directory.Exists(directoryPath) Then
                Directory.CreateDirectory(directoryPath)
                MsgBox("Logs directory created at: " & directoryPath)
            End If

            ' Append the log message to the file
            File.AppendAllText(LogFilePath, logMessage & Environment.NewLine)
        Catch ex As Exception
            File.AppendAllText("error_log.txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & " [ERROR] " & ex.Message & Environment.NewLine)
        End Try
    End Sub
End Class
