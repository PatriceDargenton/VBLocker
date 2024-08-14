
' frmEnreg.vb : formulaire d'enregistrement de BigSoft
' -----------

Friend Class frmEnreg : Inherits Form

    Private m_oVBLocker As New clsVBLocker

    Private Const iPageContrat% = 0
    Private Const iPageAuthentification% = 1 ' Enregistrement
    Private Const iPageActivation% = 2

    Private Sub frmEnreg_Load(ByVal eventSender As Object, ByVal eventArgs As EventArgs) _
        Handles MyBase.Load

        Dim sMsgErr, sFichier, sContrat, sChamp, sCleActivation As String

        Me.CmdAccepter.Enabled = False

        Me.CtrlOnglet.TabPages.Item(iPageAuthentification).Enabled = False
        Me.CtrlOnglet.TabPages.Item(iPageActivation).Enabled = False
        Me.CtrlOnglet.SelectedIndex = iPageContrat

        With m_oVBLocker
            .sLogiciel = sLogicielBigSoft
            .sCheminLicence = Application.StartupPath & "\" & sLicenceBigSoft

            ' Chargement du ficher Contrat.txt
            sFichier = Application.StartupPath & "\" & sContratBigSoft
            sContrat = ""
            If Not .bChargerFichierContrat(sFichier, sContrat) Then Exit Sub
            If sContrat <> "" Then Me.CmdAccepter.Enabled = True
            Me.TxtContrat.Text = sContrat

            ' Lecture du fichier Licence : .Lic
            sChamp = ""
            If .bLireChampLicence(sIniEMail, sChamp, sIniRubriqueInfosClient, ,
                bAutoriserChaineVide:=True) Then
                Me.TxtEMail.Text = sChamp
                .sEMailClient = sChamp
            End If
            If .bLireChampLicence(sIniClient, sChamp, sIniRubriqueInfosClient, ,
                bAutoriserChaineVide:=True) Then
                Me.TxtClient.Text = sChamp
                .sClient = sChamp
            End If
            If .bLireChampLicence(sIniCleAuthentification, sChamp, sIniRubriqueCle, ,
                bAutoriserChaineVide:=True) Then
                Me.TxtCleAuthentification.Text = sChamp
                ' Pour autoriser à nouveau l'envoi de mail, il faut cliquer sur OK
                '  afin de générer la clé
                'If bDebug Then Me.CmdEMail.Enabled = True
            End If

            sMsgErr = ""
            If Not .bVersionEnregistree(sMsgErr) Then
                If sMsgErr <> "" Then MsgBox(sMsgErr, MsgBoxStyle.Critical, sTitreMsg)
                Exit Sub
            End If

            ' Afficher qd même la licence mais désactiver les boutons
            Me.CtrlOnglet.TabPages.Item(iPageActivation).Enabled = True
            Me.CtrlOnglet.SelectedIndex = iPageActivation

            ' Lire la clé d'activation = débridage
            sCleActivation = ""
            .bLireChampLicence(sIniCleActivation, sCleActivation, sIniRubriqueCle)
            Me.TxtCleActivation.Text = sCleActivation
            LireCleActivation()
            Me.CmdCreerCleAuthentification.Visible = False
            Me.CmdAccepter.Visible = False
            Me.CmdRefuser.Visible = False
            Me.CtrlOnglet.TabPages.Item(iPageAuthentification).Enabled = True
            Me.TxtClient.Enabled = False
            Me.TxtEMail.Enabled = False
        End With

    End Sub

    Private Sub CmdAccepter_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) _
        Handles CmdAccepter.Click

        Me.CtrlOnglet.TabPages.Item(iPageAuthentification).Enabled = True
        Me.CtrlOnglet.TabPages.Item(iPageActivation).Enabled = False
        Me.CtrlOnglet.SelectedIndex = iPageAuthentification
        Me.CmdAccepter.Visible = False
        Me.CmdRefuser.Visible = False
        Dim sCleAuthentification, sMsg As String
        sCleAuthentification = ""
        If Not m_oVBLocker.bLireChampLicence(sIniCleAuthentification, sCleAuthentification,
            sIniRubriqueCle) Then Exit Sub
        sMsg = "Avez-vous reçu votre clé d'activation de la part de " & sEditeurBigSoft & " ?"
        If MsgBoxResult.No = MsgBox(sMsg, MsgBoxStyle.YesNo Or MsgBoxStyle.Question,
            m_oVBLocker.sLogiciel) Then Exit Sub
        Me.CtrlOnglet.TabPages.Item(iPageActivation).Enabled = True
        Me.CtrlOnglet.SelectedIndex = iPageActivation
        Me.TxtClient.Enabled = False
        Me.TxtEMail.Enabled = False

    End Sub

    Private Sub CmdRefuser_Click(ByVal eventSender As Object, ByVal eventArgs As EventArgs) _
        Handles CmdRefuser.Click
        Me.Close()
    End Sub

    Private Sub CmdCreerCleAuthentification_Click(ByVal eventSender As Object,
        ByVal eventArgs As EventArgs) Handles CmdCreerCleAuthentification.Click

        ' Point d'entrée de la demande de licence du client

        Dim sMsgErr, sCleAuthentification As String
        With m_oVBLocker
            sMsgErr = ""
            If Not .bVerifierEMail((Me.TxtEMail).Text, sMsgErr) Then
                Me.TxtCleAuthentification.Text = sMsgErr
                Me.TxtEMail.Focus()
                Exit Sub
            End If

            If Me.TxtClient.Text = "" Then
                Me.TxtCleAuthentification.Text = "Saisir un nom de client"
                Me.TxtClient.Focus()
                Exit Sub
            End If

            .sClient = Me.TxtClient.Text

            ' Créer la clé d'authentification du client

            sCleAuthentification = ""
            If Not .bCreerCleAuthentification(sCleAuthentification, sMsgErr) Then
                Me.TxtCleAuthentification.Text = sMsgErr
                Exit Sub
            End If
            Me.TxtCleAuthentification.Text = sCleAuthentification
            ' Ecriture des renseignements dans le fichier
            .bEcrireChampLicence(sIniCleAuthentification, Me.TxtCleAuthentification.Text,
                sIniRubriqueCle)
            .bEcrireChampLicence(sIniEMail, Me.TxtEMail.Text, sIniRubriqueInfosClient)
            .bEcrireChampLicence(sIniClient, Me.TxtClient.Text, sIniRubriqueInfosClient)
            .bEcrireChampLicence(sIniLogiciel, .sLogiciel, sIniRubriqueInfosClient)
            CmdEMail.Enabled = True
        End With

    End Sub

    Private Sub CmdValiderCleActivation_Click(ByVal eventSender As Object,
        ByVal eventArgs As EventArgs) Handles CmdValiderCleActivation.Click

        If Me.TxtCleActivation.Text = "" Then Exit Sub
        Dim sMsgErr, sCleActivation As String
        sCleActivation = Me.TxtCleActivation.Text
        sMsgErr = ""
        If Not m_oVBLocker.bTesterCleActivation(sCleActivation, sMsgErr) Then
            MsgBox("La clé d'activation est incorrecte : " & vbCrLf &
                sMsgErr, MsgBoxStyle.Critical)
            Me.TxtCleActivation.Focus()
            Exit Sub
        End If
        LireCleActivation()
        MsgBox("Félicitation : " & m_oVBLocker.sLogiciel & " est activé",
            MsgBoxStyle.Information)
        m_oVBLocker.bEcrireChampLicence(sIniCleActivation, sCleActivation, sIniRubriqueCle)

        ' 01/01/2008 Provoquer une revérification de licence dans frmBigSoft
        '  pour changer le statut dans la barre de titre
        glb_bLicenceVerifiee = False

    End Sub

    Private Sub LireCleActivation()

        ' Afficher les informations codées dans la clé

        With m_oVBLocker
            Me.LblNumeroLicence.Text = "N° de licence : " & .iNumeroLicence
            If .dDateExpiration = dDateIllimitee Then
                LblDateExpiration.Text = "Date d'expiration : Pas de limite dans le temps"
            Else
                LblDateExpiration.Text = "Date d'expiration : " &
                    .dDateExpiration.ToString("dd/MM/yyyy")
                ' Marche parfois mais pas tjrs, par ex. pas dans la fenêtre d'Exécution :
                'LblDateExpiration.Text = "Date d'expiration : " & _
                '    VB6.Format(.dDateExpiration, "dd/mm/yyyy")
            End If
            Me.chkVersionEvaluation.CheckState = CheckState.Unchecked
            Me.chkOptionToutes.CheckState = CheckState.Unchecked
            Me.chkOption1.CheckState = CheckState.Unchecked
            Me.chkOption2.CheckState = CheckState.Unchecked
            Me.chkOption3.CheckState = CheckState.Unchecked
            Me.chkOption4.CheckState = CheckState.Unchecked
            Me.chkOption5.CheckState = CheckState.Unchecked
            If .bVersionEvaluation Then _
                Me.chkVersionEvaluation.CheckState = CheckState.Checked
            If CBool(.iOptionsLogiciel And iMasqueToutesOptions) Then _
                Me.chkOptionToutes.CheckState = CheckState.Checked
            If CBool(.iOptionsLogiciel And iMasqueOption1) Then _
                Me.chkOption1.CheckState = CheckState.Checked
            If CBool(.iOptionsLogiciel And iMasqueOption2) Then _
                Me.chkOption2.CheckState = CheckState.Checked
            If CBool(.iOptionsLogiciel And iMasqueOption3) Then _
                Me.chkOption3.CheckState = CheckState.Checked
            If CBool(.iOptionsLogiciel And iMasqueOption4) Then _
                Me.chkOption4.CheckState = CheckState.Checked
            If CBool(.iOptionsLogiciel And iMasqueOption5) Then _
                Me.chkOption5.CheckState = CheckState.Checked
        End With

    End Sub

    Private Sub TxtEMail_TextChanged(ByVal eventSender As Object,
        ByVal eventArgs As EventArgs) Handles TxtEMail.TextChanged
        Dim sMsgErr$ = ""
        If Not m_oVBLocker.bVerifierEMail((Me.TxtEMail).Text, sMsgErr) Then
            Me.TxtCleAuthentification.Text = sMsgErr
        Else
            Me.TxtCleAuthentification.Text = ""
        End If
    End Sub

    Private Sub CmdEMail_Click(ByVal eventSender As Object,
        ByVal eventArgs As EventArgs) Handles CmdEMail.Click

        Dim sSujet$ = "Enregistrement de " & m_oVBLocker.sLogiciel
        Dim sContenu$ = sChampLogiciel & sSepar & m_oVBLocker.sLogiciel
        sContenu &= vbCrLf & sChampClient & sSepar &
            sGm & m_oVBLocker.sClient & sGm
        sContenu &= vbCrLf & sChampCourrielClient & sSepar &
            m_oVBLocker.sEMailClient
        sContenu &= vbCrLf & sChampCleAuthentification & sSepar &
            m_oVBLocker.sCleAuthentification
        If Not bEnvoyerCourriel(sVendeurDef, m_oVBLocker.sEMailVendeur,
            sSujet, sContenu) Then Exit Sub
        MsgBox(sMsgMailEnvoye & vbCrLf &
            "Veuillez fermer le formulaire d'enregistrement en attendant de recevoir votre clé d'activation.",
            MsgBoxStyle.Information, "Enregistrement de " & m_oVBLocker.sLogiciel)

    End Sub

End Class