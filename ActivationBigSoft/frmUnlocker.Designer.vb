Partial Class frmUnlocker
#Region "Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()
        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()
    End Sub
    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Requis par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents CmdEMail As System.Windows.Forms.Button
    Public WithEvents TxtEMail As System.Windows.Forms.TextBox
    Public WithEvents TxtLogiciel As System.Windows.Forms.TextBox
    Public WithEvents TxtNumeroSerieDisque As System.Windows.Forms.TextBox
    Public WithEvents TxtClient As System.Windows.Forms.TextBox
    Public WithEvents TxtCleAuthentification As System.Windows.Forms.TextBox
    Public WithEvents TxtCleActivation As System.Windows.Forms.TextBox
    Public WithEvents chkOption5 As System.Windows.Forms.CheckBox
    Public WithEvents chkOption4 As System.Windows.Forms.CheckBox
    Public WithEvents chkOption3 As System.Windows.Forms.CheckBox
    Public WithEvents chkOption2 As System.Windows.Forms.CheckBox
    Public WithEvents chkOption1 As System.Windows.Forms.CheckBox
    Public WithEvents chkOptionToutes As System.Windows.Forms.CheckBox
    Public WithEvents chkVersionEvaluation As System.Windows.Forms.CheckBox
    Public WithEvents TxtDateExpiration As System.Windows.Forms.TextBox
    Public WithEvents TxtNumeroLicence As System.Windows.Forms.TextBox
    Public WithEvents CmdImporterLicence As System.Windows.Forms.Button
    Public WithEvents LblEMail As System.Windows.Forms.Label
    Public WithEvents LblLogiciel As System.Windows.Forms.Label
    Public WithEvents LblDateExpirationCtrl As System.Windows.Forms.Label
    Public WithEvents LblDateExpiration As System.Windows.Forms.Label
    Public WithEvents LblNumeroSerieDisque As System.Windows.Forms.Label
    Public WithEvents LblCleActivation As System.Windows.Forms.Label
    Public WithEvents LblCleAuthentification As System.Windows.Forms.Label
    Public WithEvents LblClient As System.Windows.Forms.Label
    Public WithEvents LblNumeroLicence As System.Windows.Forms.Label
    Public WithEvents cmdImporterLicencePP As System.Windows.Forms.Button
    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Il peut être modifié à l'aide du Concepteur Windows Form.
    'Ne pas le modifier à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
Me.CmdEMail = New System.Windows.Forms.Button
Me.CmdImporterLicence = New System.Windows.Forms.Button
Me.cmdImporterLicencePP = New System.Windows.Forms.Button
Me.TxtEMail = New System.Windows.Forms.TextBox
Me.TxtLogiciel = New System.Windows.Forms.TextBox
Me.TxtNumeroSerieDisque = New System.Windows.Forms.TextBox
Me.TxtClient = New System.Windows.Forms.TextBox
Me.TxtCleAuthentification = New System.Windows.Forms.TextBox
Me.TxtCleActivation = New System.Windows.Forms.TextBox
Me.chkOption5 = New System.Windows.Forms.CheckBox
Me.chkOption4 = New System.Windows.Forms.CheckBox
Me.chkOption3 = New System.Windows.Forms.CheckBox
Me.chkOption2 = New System.Windows.Forms.CheckBox
Me.chkOption1 = New System.Windows.Forms.CheckBox
Me.chkOptionToutes = New System.Windows.Forms.CheckBox
Me.chkVersionEvaluation = New System.Windows.Forms.CheckBox
Me.TxtDateExpiration = New System.Windows.Forms.TextBox
Me.TxtNumeroLicence = New System.Windows.Forms.TextBox
Me.LblEMail = New System.Windows.Forms.Label
Me.LblLogiciel = New System.Windows.Forms.Label
Me.LblDateExpirationCtrl = New System.Windows.Forms.Label
Me.LblDateExpiration = New System.Windows.Forms.Label
Me.LblNumeroSerieDisque = New System.Windows.Forms.Label
Me.LblCleActivation = New System.Windows.Forms.Label
Me.LblCleAuthentification = New System.Windows.Forms.Label
Me.LblClient = New System.Windows.Forms.Label
Me.LblNumeroLicence = New System.Windows.Forms.Label
Me.SuspendLayout()
'
'CmdEMail
'
Me.CmdEMail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.CmdEMail.BackColor = System.Drawing.SystemColors.Control
Me.CmdEMail.Cursor = System.Windows.Forms.Cursors.Default
Me.CmdEMail.Enabled = False
Me.CmdEMail.ForeColor = System.Drawing.SystemColors.ControlText
Me.CmdEMail.Location = New System.Drawing.Point(512, 376)
Me.CmdEMail.Name = "CmdEMail"
Me.CmdEMail.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.CmdEMail.Size = New System.Drawing.Size(65, 25)
Me.CmdEMail.TabIndex = 25
Me.CmdEMail.Text = "Courriel"
Me.ToolTip1.SetToolTip(Me.CmdEMail, "Retourner un courriel au client avec sa clé d'activation")
Me.CmdEMail.UseVisualStyleBackColor = False
'
'CmdImporterLicence
'
Me.CmdImporterLicence.BackColor = System.Drawing.SystemColors.Control
Me.CmdImporterLicence.Cursor = System.Windows.Forms.Cursors.Default
Me.CmdImporterLicence.ForeColor = System.Drawing.SystemColors.ControlText
Me.CmdImporterLicence.Location = New System.Drawing.Point(165, 12)
Me.CmdImporterLicence.Name = "CmdImporterLicence"
Me.CmdImporterLicence.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.CmdImporterLicence.Size = New System.Drawing.Size(140, 25)
Me.CmdImporterLicence.TabIndex = 0
Me.CmdImporterLicence.Text = "Importer la licence (.lic)"
Me.ToolTip1.SetToolTip(Me.CmdImporterLicence, "Choisir un autre fichier licence")
Me.CmdImporterLicence.UseVisualStyleBackColor = False
'
'cmdImporterLicencePP
'
Me.cmdImporterLicencePP.BackColor = System.Drawing.SystemColors.Control
Me.cmdImporterLicencePP.Cursor = System.Windows.Forms.Cursors.Default
Me.cmdImporterLicencePP.ForeColor = System.Drawing.SystemColors.ControlText
Me.cmdImporterLicencePP.Location = New System.Drawing.Point(328, 12)
Me.cmdImporterLicencePP.Name = "cmdImporterLicencePP"
Me.cmdImporterLicencePP.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.cmdImporterLicencePP.Size = New System.Drawing.Size(140, 25)
Me.cmdImporterLicencePP.TabIndex = 26
Me.cmdImporterLicencePP.Text = "Importer la licence (p.p.)"
Me.ToolTip1.SetToolTip(Me.cmdImporterLicencePP, "Importer la licence via le presse-papier (un copié/collé du contenu du courriel e" & _
        "nvoyé par le client)")
Me.cmdImporterLicencePP.UseVisualStyleBackColor = False
'
'TxtEMail
'
Me.TxtEMail.AcceptsReturn = True
Me.TxtEMail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TxtEMail.BackColor = System.Drawing.SystemColors.Window
Me.TxtEMail.Cursor = System.Windows.Forms.Cursors.IBeam
Me.TxtEMail.Enabled = False
Me.TxtEMail.ForeColor = System.Drawing.SystemColors.WindowText
Me.TxtEMail.Location = New System.Drawing.Point(165, 144)
Me.TxtEMail.MaxLength = 0
Me.TxtEMail.Name = "TxtEMail"
Me.TxtEMail.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.TxtEMail.Size = New System.Drawing.Size(412, 20)
Me.TxtEMail.TabIndex = 23
'
'TxtLogiciel
'
Me.TxtLogiciel.AcceptsReturn = True
Me.TxtLogiciel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TxtLogiciel.BackColor = System.Drawing.SystemColors.Window
Me.TxtLogiciel.Cursor = System.Windows.Forms.Cursors.IBeam
Me.TxtLogiciel.Enabled = False
Me.TxtLogiciel.ForeColor = System.Drawing.SystemColors.WindowText
Me.TxtLogiciel.Location = New System.Drawing.Point(165, 120)
Me.TxtLogiciel.MaxLength = 0
Me.TxtLogiciel.Name = "TxtLogiciel"
Me.TxtLogiciel.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.TxtLogiciel.Size = New System.Drawing.Size(412, 20)
Me.TxtLogiciel.TabIndex = 21
'
'TxtNumeroSerieDisque
'
Me.TxtNumeroSerieDisque.AcceptsReturn = True
Me.TxtNumeroSerieDisque.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TxtNumeroSerieDisque.BackColor = System.Drawing.SystemColors.Window
Me.TxtNumeroSerieDisque.Cursor = System.Windows.Forms.Cursors.IBeam
Me.TxtNumeroSerieDisque.Enabled = False
Me.TxtNumeroSerieDisque.ForeColor = System.Drawing.SystemColors.WindowText
Me.TxtNumeroSerieDisque.Location = New System.Drawing.Point(165, 72)
Me.TxtNumeroSerieDisque.MaxLength = 0
Me.TxtNumeroSerieDisque.Name = "TxtNumeroSerieDisque"
Me.TxtNumeroSerieDisque.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.TxtNumeroSerieDisque.Size = New System.Drawing.Size(412, 20)
Me.TxtNumeroSerieDisque.TabIndex = 19
'
'TxtClient
'
Me.TxtClient.AcceptsReturn = True
Me.TxtClient.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TxtClient.BackColor = System.Drawing.SystemColors.Window
Me.TxtClient.Cursor = System.Windows.Forms.Cursors.IBeam
Me.TxtClient.Enabled = False
Me.TxtClient.ForeColor = System.Drawing.SystemColors.WindowText
Me.TxtClient.Location = New System.Drawing.Point(165, 48)
Me.TxtClient.MaxLength = 0
Me.TxtClient.Name = "TxtClient"
Me.TxtClient.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.TxtClient.Size = New System.Drawing.Size(412, 20)
Me.TxtClient.TabIndex = 18
'
'TxtCleAuthentification
'
Me.TxtCleAuthentification.AcceptsReturn = True
Me.TxtCleAuthentification.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TxtCleAuthentification.BackColor = System.Drawing.SystemColors.Window
Me.TxtCleAuthentification.Cursor = System.Windows.Forms.Cursors.IBeam
Me.TxtCleAuthentification.Enabled = False
Me.TxtCleAuthentification.ForeColor = System.Drawing.SystemColors.WindowText
Me.TxtCleAuthentification.Location = New System.Drawing.Point(165, 96)
Me.TxtCleAuthentification.MaxLength = 0
Me.TxtCleAuthentification.Name = "TxtCleAuthentification"
Me.TxtCleAuthentification.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.TxtCleAuthentification.Size = New System.Drawing.Size(412, 20)
Me.TxtCleAuthentification.TabIndex = 17
'
'TxtCleActivation
'
Me.TxtCleActivation.AcceptsReturn = True
Me.TxtCleActivation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TxtCleActivation.BackColor = System.Drawing.SystemColors.Window
Me.TxtCleActivation.Cursor = System.Windows.Forms.Cursors.IBeam
Me.TxtCleActivation.ForeColor = System.Drawing.SystemColors.WindowText
Me.TxtCleActivation.Location = New System.Drawing.Point(165, 344)
Me.TxtCleActivation.MaxLength = 0
Me.TxtCleActivation.Name = "TxtCleActivation"
Me.TxtCleActivation.ReadOnly = True
Me.TxtCleActivation.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.TxtCleActivation.Size = New System.Drawing.Size(412, 20)
Me.TxtCleActivation.TabIndex = 16
'
'chkOption5
'
Me.chkOption5.BackColor = System.Drawing.SystemColors.Control
Me.chkOption5.Cursor = System.Windows.Forms.Cursors.Default
Me.chkOption5.ForeColor = System.Drawing.SystemColors.ControlText
Me.chkOption5.Location = New System.Drawing.Point(152, 304)
Me.chkOption5.Name = "chkOption5"
Me.chkOption5.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.chkOption5.Size = New System.Drawing.Size(121, 25)
Me.chkOption5.TabIndex = 15
Me.chkOption5.Text = "Option 5"
Me.chkOption5.UseVisualStyleBackColor = False
'
'chkOption4
'
Me.chkOption4.BackColor = System.Drawing.SystemColors.Control
Me.chkOption4.Cursor = System.Windows.Forms.Cursors.Default
Me.chkOption4.ForeColor = System.Drawing.SystemColors.ControlText
Me.chkOption4.Location = New System.Drawing.Point(152, 280)
Me.chkOption4.Name = "chkOption4"
Me.chkOption4.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.chkOption4.Size = New System.Drawing.Size(121, 25)
Me.chkOption4.TabIndex = 14
Me.chkOption4.Text = "Option 4"
Me.chkOption4.UseVisualStyleBackColor = False
'
'chkOption3
'
Me.chkOption3.BackColor = System.Drawing.SystemColors.Control
Me.chkOption3.Cursor = System.Windows.Forms.Cursors.Default
Me.chkOption3.ForeColor = System.Drawing.SystemColors.ControlText
Me.chkOption3.Location = New System.Drawing.Point(152, 256)
Me.chkOption3.Name = "chkOption3"
Me.chkOption3.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.chkOption3.Size = New System.Drawing.Size(121, 25)
Me.chkOption3.TabIndex = 13
Me.chkOption3.Text = "Option 3"
Me.chkOption3.UseVisualStyleBackColor = False
'
'chkOption2
'
Me.chkOption2.BackColor = System.Drawing.SystemColors.Control
Me.chkOption2.Cursor = System.Windows.Forms.Cursors.Default
Me.chkOption2.ForeColor = System.Drawing.SystemColors.ControlText
Me.chkOption2.Location = New System.Drawing.Point(16, 304)
Me.chkOption2.Name = "chkOption2"
Me.chkOption2.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.chkOption2.Size = New System.Drawing.Size(121, 25)
Me.chkOption2.TabIndex = 12
Me.chkOption2.Text = "Option 2"
Me.chkOption2.UseVisualStyleBackColor = False
'
'chkOption1
'
Me.chkOption1.BackColor = System.Drawing.SystemColors.Control
Me.chkOption1.Cursor = System.Windows.Forms.Cursors.Default
Me.chkOption1.ForeColor = System.Drawing.SystemColors.ControlText
Me.chkOption1.Location = New System.Drawing.Point(16, 280)
Me.chkOption1.Name = "chkOption1"
Me.chkOption1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.chkOption1.Size = New System.Drawing.Size(121, 25)
Me.chkOption1.TabIndex = 11
Me.chkOption1.Text = "Option 1"
Me.chkOption1.UseVisualStyleBackColor = False
'
'chkOptionToutes
'
Me.chkOptionToutes.BackColor = System.Drawing.SystemColors.Control
Me.chkOptionToutes.Cursor = System.Windows.Forms.Cursors.Default
Me.chkOptionToutes.ForeColor = System.Drawing.SystemColors.ControlText
Me.chkOptionToutes.Location = New System.Drawing.Point(16, 256)
Me.chkOptionToutes.Name = "chkOptionToutes"
Me.chkOptionToutes.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.chkOptionToutes.Size = New System.Drawing.Size(121, 25)
Me.chkOptionToutes.TabIndex = 10
Me.chkOptionToutes.Text = "Toutes options"
Me.chkOptionToutes.UseVisualStyleBackColor = False
'
'chkVersionEvaluation
'
Me.chkVersionEvaluation.BackColor = System.Drawing.SystemColors.Control
Me.chkVersionEvaluation.Cursor = System.Windows.Forms.Cursors.Default
Me.chkVersionEvaluation.ForeColor = System.Drawing.SystemColors.ControlText
Me.chkVersionEvaluation.Location = New System.Drawing.Point(16, 232)
Me.chkVersionEvaluation.Name = "chkVersionEvaluation"
Me.chkVersionEvaluation.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.chkVersionEvaluation.Size = New System.Drawing.Size(121, 25)
Me.chkVersionEvaluation.TabIndex = 9
Me.chkVersionEvaluation.Text = "Version d'évaluation"
Me.chkVersionEvaluation.UseVisualStyleBackColor = False
'
'TxtDateExpiration
'
Me.TxtDateExpiration.AcceptsReturn = True
Me.TxtDateExpiration.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TxtDateExpiration.BackColor = System.Drawing.SystemColors.Window
Me.TxtDateExpiration.Cursor = System.Windows.Forms.Cursors.IBeam
Me.TxtDateExpiration.ForeColor = System.Drawing.SystemColors.WindowText
Me.TxtDateExpiration.Location = New System.Drawing.Point(165, 200)
Me.TxtDateExpiration.MaxLength = 0
Me.TxtDateExpiration.Name = "TxtDateExpiration"
Me.TxtDateExpiration.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.TxtDateExpiration.Size = New System.Drawing.Size(412, 20)
Me.TxtDateExpiration.TabIndex = 8
'
'TxtNumeroLicence
'
Me.TxtNumeroLicence.AcceptsReturn = True
Me.TxtNumeroLicence.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TxtNumeroLicence.BackColor = System.Drawing.SystemColors.Window
Me.TxtNumeroLicence.Cursor = System.Windows.Forms.Cursors.IBeam
Me.TxtNumeroLicence.ForeColor = System.Drawing.SystemColors.WindowText
Me.TxtNumeroLicence.Location = New System.Drawing.Point(165, 176)
Me.TxtNumeroLicence.MaxLength = 0
Me.TxtNumeroLicence.Name = "TxtNumeroLicence"
Me.TxtNumeroLicence.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.TxtNumeroLicence.Size = New System.Drawing.Size(412, 20)
Me.TxtNumeroLicence.TabIndex = 7
'
'LblEMail
'
Me.LblEMail.BackColor = System.Drawing.SystemColors.Control
Me.LblEMail.Cursor = System.Windows.Forms.Cursors.Default
Me.LblEMail.ForeColor = System.Drawing.SystemColors.ControlText
Me.LblEMail.Location = New System.Drawing.Point(16, 144)
Me.LblEMail.Name = "LblEMail"
Me.LblEMail.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.LblEMail.Size = New System.Drawing.Size(113, 17)
Me.LblEMail.TabIndex = 24
Me.LblEMail.Text = "Courriel :"
'
'LblLogiciel
'
Me.LblLogiciel.BackColor = System.Drawing.SystemColors.Control
Me.LblLogiciel.Cursor = System.Windows.Forms.Cursors.Default
Me.LblLogiciel.ForeColor = System.Drawing.SystemColors.ControlText
Me.LblLogiciel.Location = New System.Drawing.Point(16, 120)
Me.LblLogiciel.Name = "LblLogiciel"
Me.LblLogiciel.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.LblLogiciel.Size = New System.Drawing.Size(113, 17)
Me.LblLogiciel.TabIndex = 22
Me.LblLogiciel.Text = "Logiciel :"
'
'LblDateExpirationCtrl
'
Me.LblDateExpirationCtrl.BackColor = System.Drawing.SystemColors.Control
Me.LblDateExpirationCtrl.Cursor = System.Windows.Forms.Cursors.Default
Me.LblDateExpirationCtrl.ForeColor = System.Drawing.SystemColors.ControlText
Me.LblDateExpirationCtrl.Location = New System.Drawing.Point(165, 224)
Me.LblDateExpirationCtrl.Name = "LblDateExpirationCtrl"
Me.LblDateExpirationCtrl.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.LblDateExpirationCtrl.Size = New System.Drawing.Size(412, 17)
Me.LblDateExpirationCtrl.TabIndex = 20
'
'LblDateExpiration
'
Me.LblDateExpiration.BackColor = System.Drawing.SystemColors.Control
Me.LblDateExpiration.Cursor = System.Windows.Forms.Cursors.Default
Me.LblDateExpiration.ForeColor = System.Drawing.SystemColors.ControlText
Me.LblDateExpiration.Location = New System.Drawing.Point(16, 200)
Me.LblDateExpiration.Name = "LblDateExpiration"
Me.LblDateExpiration.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.LblDateExpiration.Size = New System.Drawing.Size(113, 17)
Me.LblDateExpiration.TabIndex = 6
Me.LblDateExpiration.Text = "Date d'expiration :"
'
'LblNumeroSerieDisque
'
Me.LblNumeroSerieDisque.BackColor = System.Drawing.SystemColors.Control
Me.LblNumeroSerieDisque.Cursor = System.Windows.Forms.Cursors.Default
Me.LblNumeroSerieDisque.ForeColor = System.Drawing.SystemColors.ControlText
Me.LblNumeroSerieDisque.Location = New System.Drawing.Point(16, 72)
Me.LblNumeroSerieDisque.Name = "LblNumeroSerieDisque"
Me.LblNumeroSerieDisque.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.LblNumeroSerieDisque.Size = New System.Drawing.Size(133, 19)
Me.LblNumeroSerieDisque.TabIndex = 5
Me.LblNumeroSerieDisque.Text = "N° de série du disque :"
'
'LblCleActivation
'
Me.LblCleActivation.BackColor = System.Drawing.SystemColors.Control
Me.LblCleActivation.Cursor = System.Windows.Forms.Cursors.Default
Me.LblCleActivation.ForeColor = System.Drawing.SystemColors.ControlText
Me.LblCleActivation.Location = New System.Drawing.Point(16, 344)
Me.LblCleActivation.Name = "LblCleActivation"
Me.LblCleActivation.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.LblCleActivation.Size = New System.Drawing.Size(113, 17)
Me.LblCleActivation.TabIndex = 4
Me.LblCleActivation.Text = "Clé d'activation :"
'
'LblCleAuthentification
'
Me.LblCleAuthentification.BackColor = System.Drawing.SystemColors.Control
Me.LblCleAuthentification.Cursor = System.Windows.Forms.Cursors.Default
Me.LblCleAuthentification.ForeColor = System.Drawing.SystemColors.ControlText
Me.LblCleAuthentification.Location = New System.Drawing.Point(16, 96)
Me.LblCleAuthentification.Name = "LblCleAuthentification"
Me.LblCleAuthentification.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.LblCleAuthentification.Size = New System.Drawing.Size(133, 19)
Me.LblCleAuthentification.TabIndex = 3
Me.LblCleAuthentification.Text = "Clé d'authentification :"
'
'LblClient
'
Me.LblClient.BackColor = System.Drawing.SystemColors.Control
Me.LblClient.Cursor = System.Windows.Forms.Cursors.Default
Me.LblClient.ForeColor = System.Drawing.SystemColors.ControlText
Me.LblClient.Location = New System.Drawing.Point(16, 48)
Me.LblClient.Name = "LblClient"
Me.LblClient.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.LblClient.Size = New System.Drawing.Size(113, 17)
Me.LblClient.TabIndex = 2
Me.LblClient.Text = "Client :"
'
'LblNumeroLicence
'
Me.LblNumeroLicence.BackColor = System.Drawing.SystemColors.Control
Me.LblNumeroLicence.Cursor = System.Windows.Forms.Cursors.Default
Me.LblNumeroLicence.ForeColor = System.Drawing.SystemColors.ControlText
Me.LblNumeroLicence.Location = New System.Drawing.Point(16, 176)
Me.LblNumeroLicence.Name = "LblNumeroLicence"
Me.LblNumeroLicence.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.LblNumeroLicence.Size = New System.Drawing.Size(113, 17)
Me.LblNumeroLicence.TabIndex = 1
Me.LblNumeroLicence.Text = "Licence n° :"
'
'frmUnlocker
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.BackColor = System.Drawing.SystemColors.Control
Me.ClientSize = New System.Drawing.Size(644, 416)
Me.Controls.Add(Me.cmdImporterLicencePP)
Me.Controls.Add(Me.CmdEMail)
Me.Controls.Add(Me.TxtEMail)
Me.Controls.Add(Me.TxtLogiciel)
Me.Controls.Add(Me.TxtNumeroSerieDisque)
Me.Controls.Add(Me.TxtClient)
Me.Controls.Add(Me.TxtCleAuthentification)
Me.Controls.Add(Me.TxtCleActivation)
Me.Controls.Add(Me.chkOption5)
Me.Controls.Add(Me.chkOption4)
Me.Controls.Add(Me.chkOption3)
Me.Controls.Add(Me.chkOption2)
Me.Controls.Add(Me.chkOption1)
Me.Controls.Add(Me.chkOptionToutes)
Me.Controls.Add(Me.chkVersionEvaluation)
Me.Controls.Add(Me.TxtDateExpiration)
Me.Controls.Add(Me.TxtNumeroLicence)
Me.Controls.Add(Me.CmdImporterLicence)
Me.Controls.Add(Me.LblEMail)
Me.Controls.Add(Me.LblLogiciel)
Me.Controls.Add(Me.LblDateExpirationCtrl)
Me.Controls.Add(Me.LblDateExpiration)
Me.Controls.Add(Me.LblNumeroSerieDisque)
Me.Controls.Add(Me.LblCleActivation)
Me.Controls.Add(Me.LblCleAuthentification)
Me.Controls.Add(Me.LblClient)
Me.Controls.Add(Me.LblNumeroLicence)
Me.Cursor = System.Windows.Forms.Cursors.Default
Me.Location = New System.Drawing.Point(4, 23)
Me.Name = "frmUnlocker"
Me.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Text = "Gestion des licences BigSoft"
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
#End Region
End Class