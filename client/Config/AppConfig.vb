Imports System.Configuration

Namespace Config
    Public Class AppConfig
        Public Shared Function GetConfigValue(key As String) As String
            Try
                Return ConfigurationManager.AppSettings(key)
            Catch ex As Exception
                Throw New Exception("Error retrieving config value for key: " & key)
            End Try
        End Function

        Public Shared Function GetIP() As String
            Return GetConfigValue("ServerIp")
        End Function

        Public Shared Function GetPort() As Integer
            Return Integer.Parse(GetConfigValue("ServerPort"))
        End Function
    End Class
End Namespace
