
' frmBigSoft.vb : formulaire de démarrage de BigSoft
' -------------

Friend Class frmBigSoft : Inherits Form

    Private m_oVBLocker As New clsVBLocker

    Private Sub frmBigSoft_Activated(eventSender As Object,
    eventArgs As EventArgs) Handles MyBase.Activated
        ' Attention en cas d'erreur ou d'expiration : risque de boucle infinie :
        '  pour éviter cela, on doit utiliser une variable globale pour pouvoir
        '  mettre à jour le statut activé de ce frm lorsque l'on active le logiciel dans
        '  le frm frmEnreg (pas besoin en VB6, car les MsgBox ne génèrent apparemment pas 
        '  d'événement Form_Activate, donc ce pb ne s'était pas présenté auparavant)
        If glb_bLicenceVerifiee Then Exit Sub
        glb_bLicenceVerifiee = True
        VerifierLicence()
    End Sub

    Private Sub frmBigSoft_FormClosed(eventSender As Object,
    eventArgs As Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        m_oVBLocker = Nothing
    End Sub

    Private Sub VerifierLicence()

    Dim sMsgErr, sClient, sTitreFinal, sChemin As String
    Me.Text = sLogicielBigSoft & " - Version d'évaluation"
    sChemin = Application.StartupPath

    If bTrapErr Then On Error GoTo Erreur
    With m_oVBLocker
        .sLogiciel = sLogicielBigSoft
        .sCheminLicence = sChemin & "\" & sLicenceBigSoft
        sMsgErr = ""
        If .bVersionEnregistree(sMsgErr) Then
            sTitreFinal = .sLogiciel & " - Version enregistrée pour : [" & .sClient & "]"
        Else
            sTitreFinal = .sLogiciel & " - Version d'évaluation"
            If sMsgErr <> "" Then MsgBox(sMsgErr, MsgBoxStyle.Critical, sTitreMsg)
        End If
    End With
    Me.Text = sTitreFinal
    CmdVoirLicence.Enabled = True
    Exit Sub

Erreur:
    AfficherMsgErreur(Err, "VerifierLicence")
    CmdVoirLicence.Enabled = False

End Sub

    Private Sub CmdVoirLicence_Click(eventSender As Object,
    eventArgs As EventArgs) Handles CmdVoirLicence.Click

        frmEnreg.Show()

    End Sub

End Class