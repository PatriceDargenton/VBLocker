Partial Class frmBigSoft
#Region "Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub
    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents CmdVoirLicence As System.Windows.Forms.Button
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CmdVoirLicence = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CmdVoirLicence
        '
        Me.CmdVoirLicence.BackColor = System.Drawing.SystemColors.Control
        Me.CmdVoirLicence.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdVoirLicence.Enabled = False
        Me.CmdVoirLicence.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdVoirLicence.Location = New System.Drawing.Point(189, 72)
        Me.CmdVoirLicence.Name = "CmdVoirLicence"
        Me.CmdVoirLicence.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdVoirLicence.Size = New System.Drawing.Size(114, 41)
        Me.CmdVoirLicence.TabIndex = 1
        Me.CmdVoirLicence.Text = "Licence"
        Me.ToolTip1.SetToolTip(Me.CmdVoirLicence, "Obtenir ou afficher la licence")
        Me.CmdVoirLicence.UseVisualStyleBackColor = False
        '
        'frmBigSoft
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(490, 213)
        Me.Controls.Add(Me.CmdVoirLicence)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "frmBigSoft"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "BigSoft de Bigrosoft"
        Me.ResumeLayout(False)

    End Sub
#End Region
End Class