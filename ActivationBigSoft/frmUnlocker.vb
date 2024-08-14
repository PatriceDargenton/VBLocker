
' frmUnlocker : Activation de BigSoft
' -----------------------------------

Friend Class frmUnlocker : Inherits Form

    Private Const sTitreMsg$ = "Activation de BigSoft"

    Private m_oVBLocker As New clsVBLocker

    ' Ces infos ne sont sauvées dans la licence que pour info. pour le vendeur
    '  seule la clé d'activation est retournée au client par mail
    '  pas par le fichier licence.
    Private Const sIniRubriqueCleActivation$ = "CleActivation"
    Private Const sIniCleActivation$ = "CleActivation"
    Private Const sIniNumeroLicence$ = "NumeroLicence"
    Private Const sIniOptions$ = "Options"
    Private Const sIniDateExpiration$ = "DateExpiration"

    ' Pour ne pas lancer de traitement lors du rappel des infos de la licence
    Private m_bLectureFichierIniEnCours As Boolean

    Private Sub FrmUnlocker_Activated(eventSender As Object, eventArgs As EventArgs) Handles MyBase.Activated

        ImporterLicence(Application.StartupPath & "\" & sFichierLicenceDef)

    End Sub

#Region "Import licence via le presse-papier"

    Private Sub cmdImporterLicencePP_Click(sender As Object, e As EventArgs) _
        Handles cmdImporterLicencePP.Click

        ' Logiciel : BigSoftV1.0    Client : "abc def"    Courriel client : a@a    Cle d'authentification : 1JPLLM789ABCDEFGH7CKTKN4ARM4
        Dim sLicenceBrute$ = sLirePressePapier()
        Dim iDebut% = 0
        Dim sLogiciel$ = sLireChampPP(sLicenceBrute, sChampLogiciel, iDebut)
        Dim sClient$ = sLireChampPP(sLicenceBrute, sChampClient, iDebut)
        sClient = sClient.Replace(sGm, "")
        Dim sCourrielClient$ = sLireChampPP(sLicenceBrute, sChampCourrielClient, iDebut)
        Dim sCleAuthentification$ = sLireChampPP(sLicenceBrute, sChampCleAuthentification, iDebut)

        ImporterLicencePP(sLogiciel, sClient, sCourrielClient, sCleAuthentification)

    End Sub

    Private Function sLireChampPP$(sTxt$, sChamp$, ByRef iDebut%)

        'Const sDelimiteur$ = "  "
        Const sDelimiteur$ = vbCrLf
        sLireChampPP = ""
        Dim iPosEspaces% = 0
        Dim iPosChamp% = sTxt.IndexOf(sChamp, iDebut)
        If iPosChamp > -1 Then
            iPosEspaces = sTxt.IndexOf(sDelimiteur, iPosChamp + 1)
            iDebut = iPosChamp + sChamp.Length + sSepar.Length
            If iPosEspaces > -1 Then
                sLireChampPP = sTxt.Substring(
                    iDebut, iPosEspaces - iPosChamp - sChamp.Length - sSepar.Length)
            Else
                sLireChampPP = sTxt.Substring(iDebut)
            End If
            iDebut += sLireChampPP.Length
        End If

    End Function

    Private Sub ImporterLicencePP(sLogiciel$, sClient$, sCourrielClient$, sCleAuthentification$)

        With m_oVBLocker
            ' Lecture des infos sur le client dans sa licence
            .sCleAuthentification = sCleAuthentification
            Me.TxtCleAuthentification.Text = sCleAuthentification

            .sClient = sClient
            Me.TxtClient.Text = sClient

            .sLogiciel = sLogiciel
            Me.TxtLogiciel.Text = sLogiciel

            .sEMailClient = sCourrielClient
            Me.TxtEMail.Text = sCourrielClient
        End With

        Dim sCheminFichierLicenceACreer$ = Application.StartupPath & "\" &
            sFichierLicenceDef
        If Not bLireCleAuthentification(sCheminFichierLicenceACreer) Then Exit Sub
        bCreerCleActivation()

    End Sub

#End Region

#Region "Import licence via un fichier .lic"

    Private Sub CmdImporterLicence_Click(eventSender As Object,
        eventArgs As EventArgs) Handles CmdImporterLicence.Click

        ' Gerer la boîte de dialogue pour choisir un fichier
        Dim sInitDir$, sCheminLic$
        Const sFiltreLic$ =
            "Licences (*.lic)|*.lic|" &
            "Autres fichiers licences (*.*)|*.*"
        Const sMsgTitreBoiteDlg$ = sTitreMsg &
            " - Veuillez choisir un fichier licence à importer"
        ' Initialiser le chemin seulement la première fois
        Static bDejaInit As Boolean
        sCheminLic = ""
        sInitDir = ""
        If Not bDejaInit Then
            bDejaInit = True : sInitDir = Application.StartupPath
            sCheminLic = sInitDir & "\" & sFichierLicenceDef
        End If
        If False = bChoisirFichier(sCheminLic, sFiltreLic, "*.lic",
            sMsgTitreBoiteDlg, sInitDir) Then Exit Sub
        ImporterLicence(sCheminLic)

    End Sub

    Private Sub ImporterLicence(ByRef sFichier$)

        Dim sChamp$
        With m_oVBLocker
            ' Lecture des infos sur le client dans sa licence
            sChamp = ""
            If .bLireChampLicence(sIniCleAuthentification, sChamp, sIniRubriqueCle, sFichier) Then
                .sCleAuthentification = sChamp
                Me.TxtCleAuthentification.Text = sChamp
            End If
            If .bLireChampLicence(sIniClient, sChamp, sIniRubriqueInfosClient, sFichier) Then
                .sClient = sChamp
                Me.TxtClient.Text = sChamp
            End If
            If .bLireChampLicence(sIniLogiciel, sChamp, sIniRubriqueInfosClient, sFichier) Then
                .sLogiciel = sChamp
                Me.TxtLogiciel.Text = sChamp
            End If
            If .bLireChampLicence(sIniEMail, sChamp, sIniRubriqueInfosClient, sFichier) Then
                .sEMailClient = sChamp
                Me.TxtEMail.Text = sChamp
            End If
        End With

        If Not bLireCleAuthentification(sFichier) Then Exit Sub
        bCreerCleActivation()

    End Sub

#End Region

    Private Function bLireCleAuthentification(ByRef sFichier$) As Boolean

        If m_oVBLocker Is Nothing Then Return False

        If Me.TxtCleAuthentification.Text = "" Then Return False

        ' Lecture de la clé
        Dim sMsgErr$, sCleAuthentification$
        sCleAuthentification = Me.TxtCleAuthentification.Text
        sMsgErr = ""
        If Not m_oVBLocker.bTesterCleAuthentification(sCleAuthentification, sMsgErr) Then
            ' L'erreur peut être variée :
            Me.TxtNumeroSerieDisque.Text = sMsgErr
            'Me.TxtCleActivation.Text = sMsgErr
            Return False
        End If
        Me.TxtNumeroSerieDisque.Text = CStr(m_oVBLocker.iNumeroSerieDisque)

        Dim sChamp$
        Dim iCodeOptions%
        m_bLectureFichierIniEnCours = True
        With m_oVBLocker
            ' Rappel des infos du client pour mémoire seulement
            .sCheminLicence = sFichier
            sChamp = ""
            If .bLireChampLicence(sIniNumeroLicence, sChamp, sIniRubriqueCleActivation, sFichier) Then _
                Me.TxtNumeroLicence.Text = sChamp
            If .bLireChampLicence(sIniOptions, sChamp, sIniRubriqueCleActivation, sFichier) Then
                If sChamp <> "" Then
                    iCodeOptions = CInt(sChamp)
                    Me.chkVersionEvaluation.CheckState = CheckState.Unchecked
                    Me.chkOptionToutes.CheckState = CheckState.Unchecked
                    Me.chkOption1.CheckState = CheckState.Unchecked
                    Me.chkOption2.CheckState = CheckState.Unchecked
                    Me.chkOption3.CheckState = CheckState.Unchecked
                    Me.chkOption4.CheckState = CheckState.Unchecked
                    Me.chkOption5.CheckState = CheckState.Unchecked
                    If CBool(iCodeOptions And iMasqueVersionEvaluation) Then _
                        Me.chkVersionEvaluation.CheckState = CheckState.Checked
                    If CBool(iCodeOptions And iMasqueToutesOptions) Then _
                        Me.chkOptionToutes.CheckState = CheckState.Checked
                    If CBool(iCodeOptions And iMasqueOption1) Then _
                        Me.chkOption1.CheckState = CheckState.Checked
                    If CBool(iCodeOptions And iMasqueOption2) Then _
                        Me.chkOption2.CheckState = CheckState.Checked
                    If CBool(iCodeOptions And iMasqueOption3) Then _
                        Me.chkOption3.CheckState = CheckState.Checked
                    If CBool(iCodeOptions And iMasqueOption4) Then _
                        Me.chkOption4.CheckState = CheckState.Checked
                    If CBool(iCodeOptions And iMasqueOption5) Then _
                        Me.chkOption5.CheckState = CheckState.Checked
                End If
            End If

            If .bLireChampLicence(sIniDateExpiration, sChamp, sIniRubriqueCleActivation, sFichier) Then
                If sChamp <> "" Then Me.TxtDateExpiration.Text = sChamp
            End If

        End With
        m_bLectureFichierIniEnCours = False

        Return True

    End Function

    Private Function bCreerCleActivation() As Boolean

        ' Création d'une clé d'activation = débridage à partir des renseignements saisis

        If m_oVBLocker Is Nothing Then Exit Function

        ' Ne rien faire tant que l'on est en train de récupérer les infos
        '  dans le fichier ini !
        If m_bLectureFichierIniEnCours Then Exit Function

        If bTrapErr Then On Error GoTo Erreur

        CmdEMail.Enabled = False
        Dim sMsgErr, sCleActivation As String

        With m_oVBLocker

            If Me.TxtCleAuthentification.Text = "" Then
                Me.TxtCleActivation.Text = "La clé d'authentification n'est pas renseignée"
                Exit Function
            End If
            If Me.TxtClient.Text = "" Then
                Me.TxtCleActivation.Text = "Le client n'est pas renseigné"
                Exit Function
            End If
            sMsgErr = ""
            If Not .bTesterCleAuthentification(Me.TxtCleAuthentification.Text, sMsgErr) Then
                Me.TxtCleActivation.Text = sMsgErr
                Exit Function
            End If
            .iNumeroLicence = iConv(Me.TxtNumeroLicence.Text)
            If .iNumeroLicence = 0 Then
                Me.TxtCleActivation.Text = "Saisir un numéro de licence"
                Exit Function
            End If

            .sCleAuthentification = Me.TxtCleAuthentification.Text
            .sClient = Me.TxtClient.Text
            .bVersionEvaluation = (Me.chkVersionEvaluation.CheckState = CheckState.Checked)

            If Me.TxtDateExpiration.Text = "" Then
                .dDateExpiration = dDateIllimitee
                LblDateExpirationCtrl.Text =
                    "Date d'expiration codée : Pas de limite dans le temps"
            Else
                If IsDate(Me.TxtDateExpiration.Text) Then
                    .dDateExpiration = CDate(Me.TxtDateExpiration.Text)
                    LblDateExpirationCtrl.Text =
                        "Date d'expiration codée : " &
                        .dDateExpiration.ToString("01/MM/yyyy")
                Else
                    Me.TxtCleActivation.Text = "Date incorrecte"
                    Exit Function
                End If
            End If

            .iOptionsLogiciel =
                CShort(IIf(Me.chkVersionEvaluation.CheckState = CheckState.Checked, iMasqueVersionEvaluation, 0)) +
                CShort(IIf(Me.chkOptionToutes.CheckState = CheckState.Checked, iMasqueToutesOptions, 0)) +
                CShort(IIf(Me.chkOption1.CheckState = CheckState.Checked, iMasqueOption1, 0)) +
                CShort(IIf(Me.chkOption2.CheckState = CheckState.Checked, iMasqueOption2, 0)) +
                CShort(IIf(Me.chkOption3.CheckState = CheckState.Checked, iMasqueOption3, 0)) +
                CShort(IIf(Me.chkOption4.CheckState = CheckState.Checked, iMasqueOption4, 0)) +
                CShort(IIf(Me.chkOption5.CheckState = CheckState.Checked, iMasqueOption5, 0))

            .iNumeroSerieDisque = CInt(Me.TxtNumeroSerieDisque.Text)

            sCleActivation = ""
            If Not .bCoderCle(sCleActivation, sMsgErr, bCleAuthentification:=False) Then _
                Me.TxtCleActivation.Text = sMsgErr : Exit Function

            If .dDateExpiration = dDateIllimitee Then LblDateExpirationCtrl.Text =
                "Date d'expiration codée : Pas de limite dans le temps"

            Me.TxtCleActivation.Text = sCleActivation

            ' Pour conserver la clé du coté du vendeur

            ' Si on importe depuis le presse-papier, alors sauver aussi
            '  ces 4 info. comme si elles venaient d'un fichier .lic importé
            m_oVBLocker.bEcrireChampLicence(sIniCleAuthentification, .sCleAuthentification,
                sIniRubriqueCle)
            m_oVBLocker.bEcrireChampLicence(sIniLogiciel, .sLogiciel,
                sIniRubriqueInfosClient)
            m_oVBLocker.bEcrireChampLicence(sIniClient, .sClient,
                sIniRubriqueInfosClient)
            m_oVBLocker.bEcrireChampLicence(sIniEMail, .sEMailClient,
                sIniRubriqueInfosClient)

            m_oVBLocker.bEcrireChampLicence(sIniCleActivation, sCleActivation,
                sIniRubriqueCleActivation)
            m_oVBLocker.bEcrireChampLicence(sIniNumeroLicence, CStr(.iNumeroLicence),
                sIniRubriqueCleActivation)
            m_oVBLocker.bEcrireChampLicence(sIniOptions, CStr(.iOptionsLogiciel),
                sIniRubriqueCleActivation)
            If .dDateExpiration <> dDateIllimitee Then
                m_oVBLocker.bEcrireChampLicence(sIniDateExpiration, CStr(.dDateExpiration),
                    sIniRubriqueCleActivation)
            Else
                m_oVBLocker.bEcrireChampLicence(sIniDateExpiration, "",
                    sIniRubriqueCleActivation)
            End If

            .sCleActivation = sCleActivation

        End With

        bCreerCleActivation = True
        CmdEMail.Enabled = True
        Exit Function

Erreur:
        Me.TxtCleActivation.Text = Err.Description

    End Function

    Private Sub TxtDateExpiration_TextChanged(eventSender As Object,
        eventArgs As EventArgs) Handles TxtDateExpiration.TextChanged
        bCreerCleActivation()
    End Sub

    Private Sub TxtNumeroLicence_TextChanged(eventSender As Object,
        eventArgs As EventArgs) Handles TxtNumeroLicence.TextChanged
        bCreerCleActivation()
    End Sub

    Private Sub ChkVersionEvaluation_CheckStateChanged(eventSender As Object,
        eventArgs As EventArgs) Handles chkVersionEvaluation.CheckStateChanged
        bCreerCleActivation()
    End Sub

    Private Sub chkOptionToutes_CheckStateChanged(sender As Object,
        e As EventArgs) Handles chkOptionToutes.CheckStateChanged,
        chkOption1.CheckStateChanged, chkOption2.CheckStateChanged,
        chkOption3.CheckStateChanged, chkOption4.CheckStateChanged,
        chkOption5.CheckStateChanged, chkVersionEvaluation.CheckStateChanged

        Const iIndexToutesOptions% = 0
        Dim Index% = iIndexToutesOptions
        Select Case True
            Case sender Is chkOptionToutes : Index = iIndexToutesOptions
            Case sender Is chkOption1 : Index = 1
            Case sender Is chkOption2 : Index = 2
            Case sender Is chkOption3 : Index = 3
            Case sender Is chkOption4 : Index = 4
            Case sender Is chkOption5 : Index = 5
            Case sender Is chkVersionEvaluation : Index = 6
        End Select

        If Index = iIndexToutesOptions And
            Me.chkOptionToutes.CheckState = CheckState.Checked Then
            ' Toutes-options cochées
            Me.chkOption1.CheckState = CheckState.Checked
            Me.chkOption2.CheckState = CheckState.Checked
            Me.chkOption3.CheckState = CheckState.Checked
            Me.chkOption4.CheckState = CheckState.Checked
            Me.chkOption5.CheckState = CheckState.Checked
        End If

        Dim iSommeOptions% =
            Me.chkOption1.CheckState + Me.chkOption2.CheckState +
            Me.chkOption3.CheckState + Me.chkOption4.CheckState +
            Me.chkOption5.CheckState

        If Index = iIndexToutesOptions And
            Me.chkOptionToutes.CheckState = CheckState.Unchecked And
            iSommeOptions = 5 Then
            ' Toutes-options décochées
            Me.chkOption1.CheckState = CheckState.Unchecked
            Me.chkOption2.CheckState = CheckState.Unchecked
            Me.chkOption3.CheckState = CheckState.Unchecked
            Me.chkOption4.CheckState = CheckState.Unchecked
            Me.chkOption5.CheckState = CheckState.Unchecked
        End If

        If Index > 0 Then
            If iSommeOptions < 5 Then
                ' Pas Toutes-options
                Me.chkOptionToutes.CheckState = CheckState.Unchecked
            Else
                ' Toutes-options
                Me.chkOptionToutes.CheckState = CheckState.Checked
            End If
        End If
        bCreerCleActivation()

    End Sub

    Private Sub CmdEMail_Click(eventSender As Object, eventArgs As EventArgs) _
        Handles CmdEMail.Click

        If bTrapErr Then On Error GoTo Erreur

        Dim sSujet$ = "Re: Enregistrement de " & m_oVBLocker.sLogiciel
        Dim sContenu$ = sChampLogiciel & sSepar & m_oVBLocker.sLogiciel
        sContenu &= vbCrLf & sChampClient & sSepar & m_oVBLocker.sClient
        sContenu &= vbCrLf & sChampCourrielClient & sSepar & m_oVBLocker.sEMailClient
        ' On peut omettre la clé d'authentification pour éviter que le client confonde
        ' (l'import via le presse-papier ne fonctionnera plus, mais pas besoin dans ce sens)
        'sContenu &= vbCrLf & sChampCleAuthentification & sSepar & _
        '    m_oVBLocker.sCleAuthentification
        sContenu &= vbCrLf & sChampCleActivation & sSepar & m_oVBLocker.sCleActivation
        If Not bEnvoyerCourriel(m_oVBLocker.sClient, m_oVBLocker.sEMailClient,
            sSujet, sContenu) Then Exit Sub

        MsgBox(sMsgMailEnvoye, MsgBoxStyle.Information, sTitreMsg)
        Exit Sub

Erreur:
        AfficherMsgErreur(Err, "", "CmdEMail")

    End Sub

End Class