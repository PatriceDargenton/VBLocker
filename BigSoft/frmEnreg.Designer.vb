Partial Class frmEnreg
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
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents TxtContrat As System.Windows.Forms.TextBox
    Public WithEvents CmdAccepter As System.Windows.Forms.Button
    Public WithEvents CmdRefuser As System.Windows.Forms.Button
    Public WithEvents _CtrlOnglet_TabPage0 As System.Windows.Forms.TabPage
    Public WithEvents LblInstructions As System.Windows.Forms.Label
    Public WithEvents LblEMail As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents TxtEMail As System.Windows.Forms.TextBox
    Public WithEvents TxtClient As System.Windows.Forms.TextBox
    Public WithEvents TxtCleAuthentification As System.Windows.Forms.TextBox
    Public WithEvents CmdCreerCleAuthentification As System.Windows.Forms.Button
    Public WithEvents CmdEMail As System.Windows.Forms.Button
    Public WithEvents _CtrlOnglet_TabPage1 As System.Windows.Forms.TabPage
    Public WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents LblNumeroLicence As System.Windows.Forms.Label
    Public WithEvents LblDateExpiration As System.Windows.Forms.Label
    Public WithEvents TxtCleActivation As System.Windows.Forms.TextBox
    Public WithEvents CmdValiderCleActivation As System.Windows.Forms.Button
    Public WithEvents chkOptionToutes As System.Windows.Forms.CheckBox
    Public WithEvents chkOption1 As System.Windows.Forms.CheckBox
    Public WithEvents chkOption2 As System.Windows.Forms.CheckBox
    Public WithEvents chkOption3 As System.Windows.Forms.CheckBox
    Public WithEvents chkOption4 As System.Windows.Forms.CheckBox
    Public WithEvents chkOption5 As System.Windows.Forms.CheckBox
    Public WithEvents chkVersionEvaluation As System.Windows.Forms.CheckBox
    Public WithEvents _CtrlOnglet_TabPage2 As System.Windows.Forms.TabPage
    Public WithEvents CtrlOnglet As System.Windows.Forms.TabControl
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
Me.components = New System.ComponentModel.Container
Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
Me.CmdAccepter = New System.Windows.Forms.Button
Me.CmdRefuser = New System.Windows.Forms.Button
Me.TxtEMail = New System.Windows.Forms.TextBox
Me.TxtClient = New System.Windows.Forms.TextBox
Me.CmdCreerCleAuthentification = New System.Windows.Forms.Button
Me.CmdEMail = New System.Windows.Forms.Button
Me.TxtCleActivation = New System.Windows.Forms.TextBox
Me.CmdValiderCleActivation = New System.Windows.Forms.Button
Me.CtrlOnglet = New System.Windows.Forms.TabControl
Me._CtrlOnglet_TabPage0 = New System.Windows.Forms.TabPage
Me.Label1 = New System.Windows.Forms.Label
Me.TxtContrat = New System.Windows.Forms.TextBox
Me._CtrlOnglet_TabPage1 = New System.Windows.Forms.TabPage
Me.LblInstructions = New System.Windows.Forms.Label
Me.LblEMail = New System.Windows.Forms.Label
Me.Label4 = New System.Windows.Forms.Label
Me.Label5 = New System.Windows.Forms.Label
Me.TxtCleAuthentification = New System.Windows.Forms.TextBox
Me._CtrlOnglet_TabPage2 = New System.Windows.Forms.TabPage
Me.Label6 = New System.Windows.Forms.Label
Me.LblNumeroLicence = New System.Windows.Forms.Label
Me.LblDateExpiration = New System.Windows.Forms.Label
Me.chkOptionToutes = New System.Windows.Forms.CheckBox
Me.chkOption1 = New System.Windows.Forms.CheckBox
Me.chkOption2 = New System.Windows.Forms.CheckBox
Me.chkOption3 = New System.Windows.Forms.CheckBox
Me.chkOption4 = New System.Windows.Forms.CheckBox
Me.chkOption5 = New System.Windows.Forms.CheckBox
Me.chkVersionEvaluation = New System.Windows.Forms.CheckBox
Me.CtrlOnglet.SuspendLayout()
Me._CtrlOnglet_TabPage0.SuspendLayout()
Me._CtrlOnglet_TabPage1.SuspendLayout()
Me._CtrlOnglet_TabPage2.SuspendLayout()
Me.SuspendLayout()
'
'CmdAccepter
'
Me.CmdAccepter.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
Me.CmdAccepter.BackColor = System.Drawing.SystemColors.Control
Me.CmdAccepter.Cursor = System.Windows.Forms.Cursors.Default
Me.CmdAccepter.ForeColor = System.Drawing.SystemColors.ControlText
Me.CmdAccepter.Location = New System.Drawing.Point(104, 280)
Me.CmdAccepter.Name = "CmdAccepter"
Me.CmdAccepter.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.CmdAccepter.Size = New System.Drawing.Size(73, 33)
Me.CmdAccepter.TabIndex = 3
Me.CmdAccepter.Text = "J'Accepte"
Me.ToolTip1.SetToolTip(Me.CmdAccepter, "Accepter le contrat afin d'obtenir une licence du logiciel")
Me.CmdAccepter.UseVisualStyleBackColor = False
'
'CmdRefuser
'
Me.CmdRefuser.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.CmdRefuser.BackColor = System.Drawing.SystemColors.Control
Me.CmdRefuser.Cursor = System.Windows.Forms.Cursors.Default
Me.CmdRefuser.ForeColor = System.Drawing.SystemColors.ControlText
Me.CmdRefuser.Location = New System.Drawing.Point(248, 280)
Me.CmdRefuser.Name = "CmdRefuser"
Me.CmdRefuser.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.CmdRefuser.Size = New System.Drawing.Size(113, 33)
Me.CmdRefuser.TabIndex = 4
Me.CmdRefuser.Text = "Je Refuse"
Me.ToolTip1.SetToolTip(Me.CmdRefuser, "Refuser le contrat et ne pas obtenir de licence pour le logiciel")
Me.CmdRefuser.UseVisualStyleBackColor = False
'
'TxtEMail
'
Me.TxtEMail.AcceptsReturn = True
Me.TxtEMail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TxtEMail.BackColor = System.Drawing.SystemColors.Window
Me.TxtEMail.Cursor = System.Windows.Forms.Cursors.IBeam
Me.TxtEMail.ForeColor = System.Drawing.SystemColors.WindowText
Me.TxtEMail.Location = New System.Drawing.Point(92, 80)
Me.TxtEMail.MaxLength = 0
Me.TxtEMail.Name = "TxtEMail"
Me.TxtEMail.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.TxtEMail.Size = New System.Drawing.Size(357, 20)
Me.TxtEMail.TabIndex = 6
Me.ToolTip1.SetToolTip(Me.TxtEMail, "Saisir ici votre adresse E-Mail")
'
'TxtClient
'
Me.TxtClient.AcceptsReturn = True
Me.TxtClient.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TxtClient.BackColor = System.Drawing.SystemColors.Window
Me.TxtClient.Cursor = System.Windows.Forms.Cursors.IBeam
Me.TxtClient.ForeColor = System.Drawing.SystemColors.WindowText
Me.TxtClient.Location = New System.Drawing.Point(92, 112)
Me.TxtClient.MaxLength = 0
Me.TxtClient.Name = "TxtClient"
Me.TxtClient.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.TxtClient.Size = New System.Drawing.Size(357, 20)
Me.TxtClient.TabIndex = 7
Me.ToolTip1.SetToolTip(Me.TxtClient, "Saisir ici votre nom de client")
'
'CmdCreerCleAuthentification
'
Me.CmdCreerCleAuthentification.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.CmdCreerCleAuthentification.BackColor = System.Drawing.SystemColors.Control
Me.CmdCreerCleAuthentification.Cursor = System.Windows.Forms.Cursors.Default
Me.CmdCreerCleAuthentification.ForeColor = System.Drawing.SystemColors.ControlText
Me.CmdCreerCleAuthentification.Location = New System.Drawing.Point(384, 248)
Me.CmdCreerCleAuthentification.Name = "CmdCreerCleAuthentification"
Me.CmdCreerCleAuthentification.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.CmdCreerCleAuthentification.Size = New System.Drawing.Size(65, 25)
Me.CmdCreerCleAuthentification.TabIndex = 23
Me.CmdCreerCleAuthentification.Text = "OK"
Me.ToolTip1.SetToolTip(Me.CmdCreerCleAuthentification, "Créer votre clé d'authentification")
Me.CmdCreerCleAuthentification.UseVisualStyleBackColor = False
'
'CmdEMail
'
Me.CmdEMail.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.CmdEMail.BackColor = System.Drawing.SystemColors.Control
Me.CmdEMail.Cursor = System.Windows.Forms.Cursors.Default
Me.CmdEMail.Enabled = False
Me.CmdEMail.ForeColor = System.Drawing.SystemColors.ControlText
Me.CmdEMail.Location = New System.Drawing.Point(384, 280)
Me.CmdEMail.Name = "CmdEMail"
Me.CmdEMail.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.CmdEMail.Size = New System.Drawing.Size(65, 25)
Me.CmdEMail.TabIndex = 25
Me.CmdEMail.Text = "Courriel"
Me.ToolTip1.SetToolTip(Me.CmdEMail, "Envoyer un courriel à Bigrosoft pour obtenir la clé d'activation")
Me.CmdEMail.UseVisualStyleBackColor = False
'
'TxtCleActivation
'
Me.TxtCleActivation.AcceptsReturn = True
Me.TxtCleActivation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TxtCleActivation.BackColor = System.Drawing.SystemColors.Window
Me.TxtCleActivation.Cursor = System.Windows.Forms.Cursors.IBeam
Me.TxtCleActivation.ForeColor = System.Drawing.SystemColors.WindowText
Me.TxtCleActivation.Location = New System.Drawing.Point(120, 280)
Me.TxtCleActivation.MaxLength = 0
Me.TxtCleActivation.Name = "TxtCleActivation"
Me.TxtCleActivation.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.TxtCleActivation.Size = New System.Drawing.Size(329, 20)
Me.TxtCleActivation.TabIndex = 12
Me.ToolTip1.SetToolTip(Me.TxtCleActivation, "Saisir ici votre clé d'activation fournie par l'éditeur")
'
'CmdValiderCleActivation
'
Me.CmdValiderCleActivation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.CmdValiderCleActivation.BackColor = System.Drawing.SystemColors.Control
Me.CmdValiderCleActivation.Cursor = System.Windows.Forms.Cursors.Default
Me.CmdValiderCleActivation.ForeColor = System.Drawing.SystemColors.ControlText
Me.CmdValiderCleActivation.Location = New System.Drawing.Point(392, 248)
Me.CmdValiderCleActivation.Name = "CmdValiderCleActivation"
Me.CmdValiderCleActivation.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.CmdValiderCleActivation.Size = New System.Drawing.Size(57, 25)
Me.CmdValiderCleActivation.TabIndex = 14
Me.CmdValiderCleActivation.Text = "OK"
Me.ToolTip1.SetToolTip(Me.CmdValiderCleActivation, "Activer le logiciel avec votre clé d'activation fournie par l'éditeur")
Me.CmdValiderCleActivation.UseVisualStyleBackColor = False
'
'CtrlOnglet
'
Me.CtrlOnglet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.CtrlOnglet.Controls.Add(Me._CtrlOnglet_TabPage0)
Me.CtrlOnglet.Controls.Add(Me._CtrlOnglet_TabPage1)
Me.CtrlOnglet.Controls.Add(Me._CtrlOnglet_TabPage2)
Me.CtrlOnglet.ItemSize = New System.Drawing.Size(42, 18)
Me.CtrlOnglet.Location = New System.Drawing.Point(8, 8)
Me.CtrlOnglet.Name = "CtrlOnglet"
Me.CtrlOnglet.SelectedIndex = 2
Me.CtrlOnglet.Size = New System.Drawing.Size(465, 345)
Me.CtrlOnglet.TabIndex = 0
'
'_CtrlOnglet_TabPage0
'
Me._CtrlOnglet_TabPage0.Controls.Add(Me.Label1)
Me._CtrlOnglet_TabPage0.Controls.Add(Me.TxtContrat)
Me._CtrlOnglet_TabPage0.Controls.Add(Me.CmdAccepter)
Me._CtrlOnglet_TabPage0.Controls.Add(Me.CmdRefuser)
Me._CtrlOnglet_TabPage0.Location = New System.Drawing.Point(4, 22)
Me._CtrlOnglet_TabPage0.Name = "_CtrlOnglet_TabPage0"
Me._CtrlOnglet_TabPage0.Size = New System.Drawing.Size(457, 319)
Me._CtrlOnglet_TabPage0.TabIndex = 0
Me._CtrlOnglet_TabPage0.Text = "Contrat"
'
'Label1
'
Me.Label1.BackColor = System.Drawing.SystemColors.Control
Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
Me.Label1.Location = New System.Drawing.Point(16, 48)
Me.Label1.Name = "Label1"
Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Label1.Size = New System.Drawing.Size(335, 21)
Me.Label1.TabIndex = 2
Me.Label1.Text = "Veuillez lire les conditions d'utilisation du logiciel ci-dessous :"
'
'TxtContrat
'
Me.TxtContrat.AcceptsReturn = True
Me.TxtContrat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TxtContrat.BackColor = System.Drawing.SystemColors.Window
Me.TxtContrat.Cursor = System.Windows.Forms.Cursors.IBeam
Me.TxtContrat.ForeColor = System.Drawing.SystemColors.WindowText
Me.TxtContrat.Location = New System.Drawing.Point(16, 72)
Me.TxtContrat.MaxLength = 0
Me.TxtContrat.Multiline = True
Me.TxtContrat.Name = "TxtContrat"
Me.TxtContrat.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.TxtContrat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.TxtContrat.Size = New System.Drawing.Size(425, 201)
Me.TxtContrat.TabIndex = 1
Me.TxtContrat.Text = "Contrat" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
'
'_CtrlOnglet_TabPage1
'
Me._CtrlOnglet_TabPage1.Controls.Add(Me.LblInstructions)
Me._CtrlOnglet_TabPage1.Controls.Add(Me.LblEMail)
Me._CtrlOnglet_TabPage1.Controls.Add(Me.Label4)
Me._CtrlOnglet_TabPage1.Controls.Add(Me.Label5)
Me._CtrlOnglet_TabPage1.Controls.Add(Me.TxtEMail)
Me._CtrlOnglet_TabPage1.Controls.Add(Me.TxtClient)
Me._CtrlOnglet_TabPage1.Controls.Add(Me.TxtCleAuthentification)
Me._CtrlOnglet_TabPage1.Controls.Add(Me.CmdCreerCleAuthentification)
Me._CtrlOnglet_TabPage1.Controls.Add(Me.CmdEMail)
Me._CtrlOnglet_TabPage1.Location = New System.Drawing.Point(4, 22)
Me._CtrlOnglet_TabPage1.Name = "_CtrlOnglet_TabPage1"
Me._CtrlOnglet_TabPage1.Size = New System.Drawing.Size(457, 319)
Me._CtrlOnglet_TabPage1.TabIndex = 1
Me._CtrlOnglet_TabPage1.Text = "Enregistrement"
'
'LblInstructions
'
Me.LblInstructions.BackColor = System.Drawing.SystemColors.Control
Me.LblInstructions.Cursor = System.Windows.Forms.Cursors.Default
Me.LblInstructions.ForeColor = System.Drawing.SystemColors.ControlText
Me.LblInstructions.Location = New System.Drawing.Point(16, 48)
Me.LblInstructions.Name = "LblInstructions"
Me.LblInstructions.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.LblInstructions.Size = New System.Drawing.Size(385, 17)
Me.LblInstructions.TabIndex = 5
Me.LblInstructions.Text = "Veuillez compléter les champs suivants (* obligatoires) "
'
'LblEMail
'
Me.LblEMail.BackColor = System.Drawing.SystemColors.Control
Me.LblEMail.Cursor = System.Windows.Forms.Cursors.Default
Me.LblEMail.ForeColor = System.Drawing.SystemColors.ControlText
Me.LblEMail.Location = New System.Drawing.Point(16, 80)
Me.LblEMail.Name = "LblEMail"
Me.LblEMail.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.LblEMail.Size = New System.Drawing.Size(70, 20)
Me.LblEMail.TabIndex = 8
Me.LblEMail.Text = "E-Mail* :"
'
'Label4
'
Me.Label4.BackColor = System.Drawing.SystemColors.Control
Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
Me.Label4.Location = New System.Drawing.Point(16, 112)
Me.Label4.Name = "Label4"
Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Label4.Size = New System.Drawing.Size(70, 20)
Me.Label4.TabIndex = 9
Me.Label4.Text = "Client* :"
'
'Label5
'
Me.Label5.BackColor = System.Drawing.SystemColors.Control
Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
Me.Label5.Location = New System.Drawing.Point(16, 216)
Me.Label5.Name = "Label5"
Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Label5.Size = New System.Drawing.Size(124, 20)
Me.Label5.TabIndex = 11
Me.Label5.Text = "Clé d'authentification :"
'
'TxtCleAuthentification
'
Me.TxtCleAuthentification.AcceptsReturn = True
Me.TxtCleAuthentification.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.TxtCleAuthentification.BackColor = System.Drawing.SystemColors.Window
Me.TxtCleAuthentification.Cursor = System.Windows.Forms.Cursors.IBeam
Me.TxtCleAuthentification.ForeColor = System.Drawing.SystemColors.WindowText
Me.TxtCleAuthentification.Location = New System.Drawing.Point(146, 216)
Me.TxtCleAuthentification.MaxLength = 0
Me.TxtCleAuthentification.Name = "TxtCleAuthentification"
Me.TxtCleAuthentification.ReadOnly = True
Me.TxtCleAuthentification.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.TxtCleAuthentification.Size = New System.Drawing.Size(303, 20)
Me.TxtCleAuthentification.TabIndex = 10
'
'_CtrlOnglet_TabPage2
'
Me._CtrlOnglet_TabPage2.Controls.Add(Me.Label6)
Me._CtrlOnglet_TabPage2.Controls.Add(Me.LblNumeroLicence)
Me._CtrlOnglet_TabPage2.Controls.Add(Me.LblDateExpiration)
Me._CtrlOnglet_TabPage2.Controls.Add(Me.TxtCleActivation)
Me._CtrlOnglet_TabPage2.Controls.Add(Me.CmdValiderCleActivation)
Me._CtrlOnglet_TabPage2.Controls.Add(Me.chkOptionToutes)
Me._CtrlOnglet_TabPage2.Controls.Add(Me.chkOption1)
Me._CtrlOnglet_TabPage2.Controls.Add(Me.chkOption2)
Me._CtrlOnglet_TabPage2.Controls.Add(Me.chkOption3)
Me._CtrlOnglet_TabPage2.Controls.Add(Me.chkOption4)
Me._CtrlOnglet_TabPage2.Controls.Add(Me.chkOption5)
Me._CtrlOnglet_TabPage2.Controls.Add(Me.chkVersionEvaluation)
Me._CtrlOnglet_TabPage2.Location = New System.Drawing.Point(4, 22)
Me._CtrlOnglet_TabPage2.Name = "_CtrlOnglet_TabPage2"
Me._CtrlOnglet_TabPage2.Size = New System.Drawing.Size(457, 319)
Me._CtrlOnglet_TabPage2.TabIndex = 2
Me._CtrlOnglet_TabPage2.Text = "Activation"
'
'Label6
'
Me.Label6.BackColor = System.Drawing.SystemColors.Control
Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
Me.Label6.Location = New System.Drawing.Point(24, 280)
Me.Label6.Name = "Label6"
Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Label6.Size = New System.Drawing.Size(89, 17)
Me.Label6.TabIndex = 13
Me.Label6.Text = "Clé d'activation :"
'
'LblNumeroLicence
'
Me.LblNumeroLicence.BackColor = System.Drawing.SystemColors.Control
Me.LblNumeroLicence.Cursor = System.Windows.Forms.Cursors.Default
Me.LblNumeroLicence.ForeColor = System.Drawing.SystemColors.ControlText
Me.LblNumeroLicence.Location = New System.Drawing.Point(56, 72)
Me.LblNumeroLicence.Name = "LblNumeroLicence"
Me.LblNumeroLicence.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.LblNumeroLicence.Size = New System.Drawing.Size(289, 17)
Me.LblNumeroLicence.TabIndex = 15
Me.LblNumeroLicence.Text = "N° de Licence :"
'
'LblDateExpiration
'
Me.LblDateExpiration.BackColor = System.Drawing.SystemColors.Control
Me.LblDateExpiration.Cursor = System.Windows.Forms.Cursors.Default
Me.LblDateExpiration.ForeColor = System.Drawing.SystemColors.ControlText
Me.LblDateExpiration.Location = New System.Drawing.Point(56, 216)
Me.LblDateExpiration.Name = "LblDateExpiration"
Me.LblDateExpiration.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.LblDateExpiration.Size = New System.Drawing.Size(305, 17)
Me.LblDateExpiration.TabIndex = 22
Me.LblDateExpiration.Text = "Date d'expiration :"
'
'chkOptionToutes
'
Me.chkOptionToutes.BackColor = System.Drawing.SystemColors.Control
Me.chkOptionToutes.Cursor = System.Windows.Forms.Cursors.Default
Me.chkOptionToutes.Enabled = False
Me.chkOptionToutes.ForeColor = System.Drawing.SystemColors.ControlText
Me.chkOptionToutes.Location = New System.Drawing.Point(56, 96)
Me.chkOptionToutes.Name = "chkOptionToutes"
Me.chkOptionToutes.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.chkOptionToutes.Size = New System.Drawing.Size(97, 33)
Me.chkOptionToutes.TabIndex = 16
Me.chkOptionToutes.Text = "Toutes options"
Me.chkOptionToutes.UseVisualStyleBackColor = False
'
'chkOption1
'
Me.chkOption1.BackColor = System.Drawing.SystemColors.Control
Me.chkOption1.Cursor = System.Windows.Forms.Cursors.Default
Me.chkOption1.Enabled = False
Me.chkOption1.ForeColor = System.Drawing.SystemColors.ControlText
Me.chkOption1.Location = New System.Drawing.Point(160, 96)
Me.chkOption1.Name = "chkOption1"
Me.chkOption1.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.chkOption1.Size = New System.Drawing.Size(73, 33)
Me.chkOption1.TabIndex = 17
Me.chkOption1.Text = "Option 1"
Me.chkOption1.UseVisualStyleBackColor = False
'
'chkOption2
'
Me.chkOption2.BackColor = System.Drawing.SystemColors.Control
Me.chkOption2.Cursor = System.Windows.Forms.Cursors.Default
Me.chkOption2.Enabled = False
Me.chkOption2.ForeColor = System.Drawing.SystemColors.ControlText
Me.chkOption2.Location = New System.Drawing.Point(248, 96)
Me.chkOption2.Name = "chkOption2"
Me.chkOption2.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.chkOption2.Size = New System.Drawing.Size(73, 33)
Me.chkOption2.TabIndex = 18
Me.chkOption2.Text = "Option 2"
Me.chkOption2.UseVisualStyleBackColor = False
'
'chkOption3
'
Me.chkOption3.BackColor = System.Drawing.SystemColors.Control
Me.chkOption3.Cursor = System.Windows.Forms.Cursors.Default
Me.chkOption3.Enabled = False
Me.chkOption3.ForeColor = System.Drawing.SystemColors.ControlText
Me.chkOption3.Location = New System.Drawing.Point(56, 136)
Me.chkOption3.Name = "chkOption3"
Me.chkOption3.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.chkOption3.Size = New System.Drawing.Size(73, 33)
Me.chkOption3.TabIndex = 19
Me.chkOption3.Text = "Option 3"
Me.chkOption3.UseVisualStyleBackColor = False
'
'chkOption4
'
Me.chkOption4.BackColor = System.Drawing.SystemColors.Control
Me.chkOption4.Cursor = System.Windows.Forms.Cursors.Default
Me.chkOption4.Enabled = False
Me.chkOption4.ForeColor = System.Drawing.SystemColors.ControlText
Me.chkOption4.Location = New System.Drawing.Point(160, 136)
Me.chkOption4.Name = "chkOption4"
Me.chkOption4.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.chkOption4.Size = New System.Drawing.Size(73, 33)
Me.chkOption4.TabIndex = 20
Me.chkOption4.Text = "Option 4"
Me.chkOption4.UseVisualStyleBackColor = False
'
'chkOption5
'
Me.chkOption5.BackColor = System.Drawing.SystemColors.Control
Me.chkOption5.Cursor = System.Windows.Forms.Cursors.Default
Me.chkOption5.Enabled = False
Me.chkOption5.ForeColor = System.Drawing.SystemColors.ControlText
Me.chkOption5.Location = New System.Drawing.Point(248, 136)
Me.chkOption5.Name = "chkOption5"
Me.chkOption5.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.chkOption5.Size = New System.Drawing.Size(73, 33)
Me.chkOption5.TabIndex = 21
Me.chkOption5.Text = "Option 5"
Me.chkOption5.UseVisualStyleBackColor = False
'
'chkVersionEvaluation
'
Me.chkVersionEvaluation.BackColor = System.Drawing.SystemColors.Control
Me.chkVersionEvaluation.Cursor = System.Windows.Forms.Cursors.Default
Me.chkVersionEvaluation.Enabled = False
Me.chkVersionEvaluation.ForeColor = System.Drawing.SystemColors.ControlText
Me.chkVersionEvaluation.Location = New System.Drawing.Point(56, 176)
Me.chkVersionEvaluation.Name = "chkVersionEvaluation"
Me.chkVersionEvaluation.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.chkVersionEvaluation.Size = New System.Drawing.Size(137, 25)
Me.chkVersionEvaluation.TabIndex = 24
Me.chkVersionEvaluation.Text = "Version d'évaluation"
Me.chkVersionEvaluation.UseVisualStyleBackColor = False
'
'frmEnreg
'
Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
Me.BackColor = System.Drawing.SystemColors.Control
Me.ClientSize = New System.Drawing.Size(481, 362)
Me.Controls.Add(Me.CtrlOnglet)
Me.Cursor = System.Windows.Forms.Cursors.Default
Me.Location = New System.Drawing.Point(4, 23)
Me.Name = "frmEnreg"
Me.RightToLeft = System.Windows.Forms.RightToLeft.No
Me.Text = "Enregistrement de BigSoft de Bigrosoft"
Me.CtrlOnglet.ResumeLayout(False)
Me._CtrlOnglet_TabPage0.ResumeLayout(False)
Me._CtrlOnglet_TabPage0.PerformLayout()
Me._CtrlOnglet_TabPage1.ResumeLayout(False)
Me._CtrlOnglet_TabPage1.PerformLayout()
Me._CtrlOnglet_TabPage2.ResumeLayout(False)
Me._CtrlOnglet_TabPage2.PerformLayout()
Me.ResumeLayout(False)

End Sub
#End Region
End Class