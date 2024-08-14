
' frmBigSoft.vb : formulaire de d�marrage de BigSoft
' -------------

Friend Class frmBigSoft : Inherits Form

    Private m_oVBLocker As New clsVBLocker

    Private Sub frmBigSoft_Activated(eventSender As Object,
    eventArgs As EventArgs) Handles MyBase.Activated
        ' Attention en cas d'erreur ou d'expiration : risque de boucle infinie :
        '  pour �viter cela, on doit utiliser une variable globale pour pouvoir
        '  mettre � jour le statut activ� de ce frm lorsque l'on active le logiciel dans
        '  le frm frmEnreg (pas besoin en VB6, car les MsgBox ne g�n�rent apparemment pas 
        '  d'�v�nement Form_Activate, donc ce pb ne s'�tait pas pr�sent� auparavant)
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
    Me.Text = sLogicielBigSoft & " - Version d'�valuation"
    sChemin = Application.StartupPath

    If bTrapErr Then On Error GoTo Erreur
    With m_oVBLocker
        .sLogiciel = sLogicielBigSoft
        .sCheminLicence = sChemin & "\" & sLicenceBigSoft
        sMsgErr = ""
        If .bVersionEnregistree(sMsgErr) Then
            sTitreFinal = .sLogiciel & " - Version enregistr�e pour : [" & .sClient & "]"
        Else
            sTitreFinal = .sLogiciel & " - Version d'�valuation"
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