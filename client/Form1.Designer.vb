<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.console = New System.Windows.Forms.RichTextBox()
        Me.btnDisconnect = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(12, 27)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(178, 37)
        Me.btnConnect.TabIndex = 0
        Me.btnConnect.Text = "Connect to Server"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'console
        '
        Me.console.Location = New System.Drawing.Point(14, 71)
        Me.console.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.console.Name = "console"
        Me.console.ReadOnly = True
        Me.console.Size = New System.Drawing.Size(418, 312)
        Me.console.TabIndex = 1
        Me.console.Text = ""
        '
        'btnDisconnect
        '
        Me.btnDisconnect.Location = New System.Drawing.Point(196, 27)
        Me.btnDisconnect.Name = "btnDisconnect"
        Me.btnDisconnect.Size = New System.Drawing.Size(190, 37)
        Me.btnDisconnect.TabIndex = 2
        Me.btnDisconnect.Text = "Disconnect to Server"
        Me.btnDisconnect.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(446, 396)
        Me.Controls.Add(Me.btnDisconnect)
        Me.Controls.Add(Me.console)
        Me.Controls.Add(Me.btnConnect)
        Me.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Client"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents console As System.Windows.Forms.RichTextBox
    Friend WithEvents btnDisconnect As System.Windows.Forms.Button

End Class
