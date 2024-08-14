
' clsVBLocker.vb : Classe VBLocker et VBUnLocker
' --------------

' VBLocker : Protégez votre application commerciale
' -------------------------------------------------

' Conventions de nommage des variables :
' ------------------------------------
' b pour Boolean (booléen vrai ou faux)
' i pour Integer : % (en VB .Net, l'entier a la capacité du VB6.Long)
' l pour Long : &
' r pour nombre Réel (Single!, Double# ou Decimal : D)
' s pour String : $
' c pour Char ou Byte
' d pour Date
' u pour Unsigned (non signé : entier positif)
' a pour Array (tableau) : ()
' o pour Object : objet instancié localement
' refX pour reference à un objet X préexistant qui n'est pas sensé être fermé
' m_ pour variable Membre de la classe ou de la feuille (Form)
'  (mais pas pour les constantes)
' frm pour Form
' cls pour Classe
' mod pour Module
' ...
' ------------------------------------

' clsVBLocker ne doit pas contenir les fonctions permettant l'activation, 
'  car c'est la classe qui reste du coté client
' Pour utiliser la classe en mode UnLocker, on utilise VBUnLocker = -1 dans les arguments
'  de compilation conditionnelle (et on ne met rien pour clsVBLocker)

Public Class clsVBLocker

    Private m_sEMailVendeur$
    Private m_sCheminLicence$
    Private m_Cle As TCleProtection

    ' Champs de la clé : Position et nombre de car. de chaque champ
    ' Nombre de car. pour les Checksum (CS) : 2 suffit en base 62, 3 en base 32
    ' (26 minuscules + 26 majuscules + 10 chiffres = 62 caractères)
    Private Const iPosNSD% = 1 ' N° de Série du Disque dur
    Private Const iLenNSD% = 7 ' Nbre de car. dans la base 32
    'Private Const iLenNSD% = 6 ' 6 en base 64, car 7 est alors trop grand pour un Long
    Private Const iPosDate% = iPosNSD + iLenNSD ' Champ suivant le champ NSD
    Private Const iLenDate% = 3
    Private Const iPosLic% = iPosDate + iLenDate
    Private Const iLenLic% = 4 ' N° de Licence
    Private Const iPosOptions% = iPosLic + iLenLic
    Private Const iLenOptions% = 2 ' Options du logiciel dans la licence
    Private Const iPosCSClient% = iPosOptions + iLenOptions
    Private Const iLenCSClient% = 3
    Private Const iPosCSEMail% = iPosCSClient + iLenCSClient
    Private Const iLenCSEMail% = 3
    Private Const iPosCSLogiciel% = iPosCSEMail + iLenCSEMail
    Private Const iLenCSLogiciel% = 3
    ' Total des paramètres (sauf le CS final)
    Private Const iLenTot% = iPosCSLogiciel + iLenCSLogiciel
    Private Const iPosCS% = iLenTot
    Private Const iLenCS% = 3
    ' Toute la clé avec le CS final
    Private Const iLenCle% = iPosCS + iLenCS

    Private Declare Function GetVolumeInformation% Lib "kernel32" Alias _
        "GetVolumeInformationA" (lpRootPathName$, lpVolumeNameBuffer$,
        nVolumeNameSize%, ByRef lpVolumeSerialNumber%,
        ByRef lpMaximumComponentLength%, ByRef lpFileSystemFlags%,
        lpFileSystemNameBuffer$, nFileSystemNameSize%)

    Public Property sEMailClient$()
        Get
            sEMailClient = m_Cle.sEMail
        End Get
        Set(Value$)
            m_Cle.sEMail = Value
        End Set
    End Property

    Public Property sCheminLicence$()
        Get
            sCheminLicence = m_sCheminLicence
        End Get
        Set(Value$)
            m_sCheminLicence = Value
        End Set
    End Property

    ' Propriétés en lecture/écriture dans VBLocker,
    '  mais en lecture seule dans VBUnLocker
#If VBUnLocker Then

    Public Property sEMailVendeur$()
        Get
            sEMailVendeur = m_sEMailVendeur
        End Get
        Set(Value$)
            m_sEMailVendeur = Value
        End Set
    End Property

    Public Property sCleAuthentification$()
        Get
            sCleAuthentification = m_Cle.sCleAuthentification
        End Get
        Set(Value$)
            m_Cle.sCleAuthentification = Value
        End Set
    End Property

    Public Property sCleActivation$()
        Get
            sCleActivation = m_Cle.sCleActivation
        End Get
        Set(Value$)
            m_Cle.sCleActivation = Value
        End Set
    End Property

    Public Property iNumeroLicence%()
        Get
            iNumeroLicence = m_Cle.iNumeroLicence
        End Get
        Set(Value%)
            m_Cle.iNumeroLicence = Value
        End Set
    End Property

    Public Property dDateExpiration() As Date
        Get
            dDateExpiration = m_Cle.dDateExpiration
        End Get
        Set(Value As Date)
            m_Cle.dDateExpiration = Value
        End Set
    End Property

    Public Property iOptionsLogiciel%()
        Get
            iOptionsLogiciel = m_Cle.iOptionsLogiciel
        End Get
        Set(iValue%)
            m_Cle.iOptionsLogiciel = iValue
        End Set
    End Property

    Public Property bVersionEvaluation() As Boolean
        Get
            bVersionEvaluation = m_Cle.bVersionEvaluation
        End Get
        Set(Value As Boolean)
            m_Cle.bVersionEvaluation = Value
        End Set
    End Property

#Else

    Public ReadOnly Property sEMailVendeur$()
        Get
            sEMailVendeur = m_sEMailVendeur
        End Get
    End Property

    Public ReadOnly Property sCleAuthentification$()
        Get
            sCleAuthentification = m_Cle.sCleAuthentification
        End Get
    End Property

    Public ReadOnly Property iNumeroLicence%()
        Get
            iNumeroLicence = m_Cle.iNumeroLicence
        End Get
    End Property

    Public ReadOnly Property dDateExpiration() As Date
        Get
            dDateExpiration = m_Cle.dDateExpiration
        End Get
    End Property

    Public ReadOnly Property iOptionsLogiciel%()
        Get
            iOptionsLogiciel = m_Cle.iOptionsLogiciel
        End Get
    End Property

    Public ReadOnly Property bVersionEvaluation() As Boolean
        Get
            bVersionEvaluation = m_Cle.bVersionEvaluation
        End Get
    End Property

#End If

    ' La property Get doit être présente pour que
    '  la property Let fonctionne sous Access !

    Public Property iNumeroSerieDisque%()
        Get
            iNumeroSerieDisque = m_Cle.iNumeroSerieDisque
        End Get
        Set(Value%)
            m_Cle.iNumeroSerieDisque = Value
        End Set
    End Property

    Public Property sClient$()
        Get
            sClient = m_Cle.sClient
        End Get
        Set(Value$)
            m_Cle.sClient = Value
        End Set
    End Property

    Public Property sLogiciel$()
        Get
            sLogiciel = m_Cle.sLogiciel
        End Get
        Set(Value$)
            m_Cle.sLogiciel = Value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        m_sEMailVendeur = sEMailVendeurDef
        m_sCheminLicence = Application.StartupPath & "\" & sFichierLicenceDef
    End Sub

    Public Function bVerifierEMail(ByRef sEMail$, ByRef sMsgErr$) As Boolean

        If sEMail = "" Then sMsgErr = "Veuillez saisir votre EMail" : Return False
        If InStr(sEMail, "@") = 0 OrElse
           InStr(sEMail, " ") > 0 OrElse
           Left(sEMail, 1) = "@" OrElse
           Right(sEMail, 1) = "@" Then _
            sMsgErr = "Adresse E-Mail incorrecte" : Return False
        sMsgErr = ""
        m_Cle.sEMail = sEMail

        Return True

    End Function

    Public Function bCreerCleAuthentification(ByRef sCleAuthentification$, ByRef sMsgErr$) As Boolean

        ' Créer la clé d'authentification avec le nom du client et
        '  le numéro de série du disque dur de l'utilisateur
        '  (de la partition où est installé le logiciel en fait)

        If bTrapErr Then On Error GoTo Erreur

        With m_Cle
            .sLecteur = Left(Application.StartupPath, 3)
            If Not bLireNSD(.sLecteur, .iNumeroSerieDisque) Then
                ' On teste sur C: alors, le cas le plus sûr
                If Not bLireNSD(sLecteurDefaut, .iNumeroSerieDisque) Then
                    sMsgErr = "Installation impossible sur ce lecteur"
                    Exit Function
                End If
            End If
        End With

        Dim sCleCryptee$
        sCleCryptee = ""
        ' Coder la clé d'authentification
        If Not bCoderCleEnPrive(sCleCryptee, sMsgErr, bCleAuthentification:=True) Then Exit Function

        sCleAuthentification = sCleCryptee
        m_Cle.sCleAuthentification = sCleAuthentification
        bCreerCleAuthentification = True
        Exit Function

Erreur:
        sMsgErr = Err.Description

    End Function

#If VBUnLocker Then
    Public Function bCoderCle(ByRef sCle$, ByRef sMsgErr$, ByRef bCleAuthentification As Boolean) As Boolean
        bCoderCle = bCoderCleEnPrive(sCle, sMsgErr, bCleAuthentification)
    End Function
#End If

    ' Fonction privée : ne change pas grand chose pour Reflector : on voit qd même le src !
    Private Function bCoderCleEnPrive(ByRef sCle$, ByRef sMsgErr$,
        ByRef bCleAuthentification As Boolean) As Boolean

        sCle = New String("0"c, iLenCle - 1) ' 0 : Pour éviter les espaces

        Dim sCodeCSEMail, sCodeNSD, sCodeCSClient, sCodeLicence As String
        Dim sCleCryptee$
        Dim sCodeCSLogiciel, sCodeOptions, sCodeDate, sCodeCS As String
        Dim iCodage%
        With m_Cle

            ' N° de Série du Disque
            sMsgErr = "NSD"
            ' bVerifierLimite:=True : On doit s'assurer que le n° de série
            '  du disque du client pourra être codé !
            sCodeNSD = sConvInt32BitsEnChaineLisible(.iNumeroSerieDisque, iLenNSD,
                sMsgErr, bVerifierLimiteInt32:=True)
            If sMsgErr <> "" Then Return False
            Mid(sCle, iPosNSD, iLenNSD) = sCodeNSD

            ' Date d'expiration
            sMsgErr = "Date"
            iCodage = iConvDateEnInt(.dDateExpiration)
            sCodeDate = sConvInt32BitsEnChaineLisible(iCodage, iLenDate, sMsgErr)
            If sMsgErr <> "" Then Return False
            Mid(sCle, iPosDate, iLenDate) = sCodeDate

            ' Licence
            sMsgErr = "Licence"
            sCodeLicence = sConvInt32BitsEnChaineLisible(.iNumeroLicence, iLenLic, sMsgErr)
            If sMsgErr <> "" Then Return False
            Mid(sCle, iPosLic, iLenLic) = sCodeLicence

            ' Options du logiciel
            iCodage = .iOptionsLogiciel
            sMsgErr = "Options"
            sCodeOptions = sConvInt32BitsEnChaineLisible(iCodage, iLenOptions, sMsgErr)
            If sMsgErr <> "" Then Return False
            Mid(sCle, iPosOptions, iLenOptions) = sCodeOptions

            ' Checksum du client
            If .iCSClient = 0 Then .iCSClient = iCheckSum(.sClient)
            sMsgErr = "CSClient"
            sCodeCSClient = sConvInt32BitsEnChaineLisible(.iCSClient, iLenCSClient,
                sMsgErr, , bVerifierLimiteInt16:=True)
            If sMsgErr <> "" Then Return False
            Mid(sCle, iPosCSClient, iLenCSClient) = sCodeCSClient

            ' Checksum de l'email client
            If .iCSEMail = 0 Then .iCSEMail = iCheckSum(.sEMail)
            sMsgErr = "CSEMail"
            sCodeCSEMail = sConvInt32BitsEnChaineLisible(.iCSEMail, iLenCSEMail,
                sMsgErr, , bVerifierLimiteInt16:=True)
            If sMsgErr <> "" Then Return False
            Mid(sCle, iPosCSEMail, iLenCSEMail) = sCodeCSEMail

            ' Checksum du logiciel
            If .iCSLogiciel = 0 Then .iCSLogiciel = iCheckSum(.sLogiciel)
            sMsgErr = "CSLogiciel"
            sCodeCSLogiciel = sConvInt32BitsEnChaineLisible(.iCSLogiciel, iLenCSLogiciel,
                sMsgErr, , bVerifierLimiteInt16:=True)
            If sMsgErr <> "" Then Return False
            Mid(sCle, iPosCSLogiciel, iLenCSLogiciel) = sCodeCSLogiciel

            ' Checksum total
            sCodeCS = Mid(sCle, 1, iLenTot - 1)
            iCodage = iCheckSum(sCodeCS)
            ' Crypter le checksum et l'ajouter dans la chaine
            sMsgErr = "CS"
            sCodeCS = sConvInt32BitsEnChaineLisible(iCodage, iLenCS,
                sMsgErr, , bVerifierLimiteInt16:=True)
            If sMsgErr <> "" Then Return False
            Mid(sCle, iPosCS, iLenCS) = sCodeCS

            ' Crypter la clé
            sCleCryptee = sCrypter(bCleAuthentification, sCle)
            sCle = sCleCryptee

        End With

        Return True

    End Function

    Private Function bDecoderCle(ByRef sCle$, ByRef sMsgErr$,
        ByRef bCleAuthentification As Boolean) As Boolean

        If bTrapErr Then On Error GoTo Erreur

        If Len(sCle) <> iLenCle - 1 Then sMsgErr = "Longueur de clé incorrecte" : Exit Function

        Dim iCodage, iCS As Integer
        Dim sCode, sCleDecryptee As String

        With m_Cle
            ' Décrypter la chaine
            sCleDecryptee = sCrypter(bCleAuthentification, sCle)

            ' Checksum de la chaine
            sCode = Mid(sCleDecryptee, iPosCS, iLenCS)
            iCodage = iConvChaineLisibleEnInt32Bits(sCode)
            ' Vérification du checksum
            sCode = Mid(sCleDecryptee, 1, iLenTot - 1)
            iCS = iCheckSum(sCode)
            If iCodage <> iCS Then sMsgErr = "Clé incorrecte" : Exit Function

            ' Checksum client
            sCode = Mid(sCleDecryptee, iPosCSClient, iLenCSClient)
            .iCSClient = iConvChaineLisibleEnInt32Bits(sCode)
            iCodage = iCheckSum(.sClient)
            If iCodage <> .iCSClient Then sMsgErr = "Client incorrect" : Exit Function

            ' Checksum EMail client
            sCode = Mid(sCleDecryptee, iPosCSEMail, iLenCSEMail)
            .iCSEMail = iConvChaineLisibleEnInt32Bits(sCode)
            iCodage = iCheckSum(.sEMail)
            If iCodage <> .iCSEMail Then sMsgErr = "EMail incorrect" : Exit Function

            ' Checksum logiciel
            sCode = Mid(sCleDecryptee, iPosCSLogiciel, iLenCSLogiciel)
            .iCSLogiciel = iConvChaineLisibleEnInt32Bits(sCode)
            iCodage = iCheckSum(.sLogiciel)
            If iCodage <> .iCSLogiciel Then sMsgErr = "Logiciel incorrect" : Exit Function

            .iNumeroSerieDisque = iConvChaineLisibleEnInt32Bits(
                Mid(sCleDecryptee, iPosNSD, iLenNSD))
            iCodage = iConvChaineLisibleEnInt32Bits(Mid(sCleDecryptee, iPosDate, iLenDate))
            .dDateExpiration = dConvIntEnDate(iCodage)
            .iNumeroLicence = iConvChaineLisibleEnInt32Bits(
                Mid(sCleDecryptee, iPosLic, iLenLic))
            ' Options du logiciel
            iCodage = iConvChaineLisibleEnInt32Bits(
                Mid(sCleDecryptee, iPosOptions, iLenOptions))
            ' Vrai si le bit 0 est à 1
            .bVersionEvaluation = CBool(iCodage And iMasqueVersionEvaluation)
            .iOptionsLogiciel = iCodage

        End With

        sCle = sCleDecryptee
        bDecoderCle = True
        Exit Function

Erreur:
        AfficherMsgErreur(Err, "bDecoderCle")

    End Function

    Public Function bVersionEnregistree(ByRef sMsgErr$) As Boolean

        Dim dDateLimite As Date
        Dim iNumeroLicence%
        Dim iOptions%
        Dim sCleAuthentification, sCleActivation As String
        Dim bDateExpiree As Boolean

        bVersionEnregistree = False

        ' Vérification de la clé d'authentification
        Dim sClient, sEMailClient As String
        sClient = "" : sEMailClient = ""
        If Not bLireChampLicence(sIniClient, sClient, sIniRubriqueInfosClient) Then Exit Function
        If Not bLireChampLicence(sIniEMail, sEMailClient, sIniRubriqueInfosClient) Then Exit Function
        m_Cle.sClient = sClient
        m_Cle.sEMail = sEMailClient

        sCleAuthentification = ""
        If Not bLireChampLicence(sIniCleAuthentification, sCleAuthentification, sIniRubriqueCle) Then Exit Function

        sMsgErr = ""
        If Not bTesterCleAuthentification(sCleAuthentification, sMsgErr) Then Exit Function

        ' Vérification de la clé d'activation
        sCleActivation = ""
        If Not bLireChampLicence(sIniCleActivation, sCleActivation, sIniRubriqueCle) Then _
            Exit Function

        ' Appeler la procédure générale de test
        sMsgErr = ""
        If Not bTesterCleActivation(sCleActivation, sMsgErr, dDateLimite,
            iNumeroLicence, iOptions) Then Exit Function

        bDateExpiree = True
        If dDateLimite = dDateIllimitee Or dDateLimite >= Now Then bDateExpiree = False
        ' Si la procédure d'enregistrement est suivie, seule la date compte
        bVersionEnregistree = Not bDateExpiree

    End Function

    Public Function bTesterCleAuthentification(sCleAuthentification$, ByRef sMsgErr$) _
        As Boolean

        If Not bDecoderCle(sCleAuthentification, sMsgErr, bCleAuthentification:=True) Then _
            Return False
        Return True

    End Function

    Public Function bTesterCleActivation(sCleActivation$, ByRef sMsgErr$,
        Optional ByRef dDateExpiration As Date = #12:00:00 AM#,
        Optional ByRef iNumeroLicence% = 0,
        Optional ByRef iOptions% = 0) As Boolean

        ' Procédure de test de la clé
        ' Retourne en option : Date exp., Numéro de licence, les options de la licence

        If bTrapErr Then On Error GoTo Erreur

        ' Lire le nom du client, son EMail et le logiciel
        Dim sEMail, sClient, sCleDecodee, sLogiciel As String
        sClient = "" : sEMail = "" : sLogiciel = ""
        If Not bLireChampLicence("Client", sClient, sIniRubriqueInfosClient) Then Exit Function
        If Not bLireChampLicence("EMail", sEMail, sIniRubriqueInfosClient) Then Exit Function
        If Not bLireChampLicence("Logiciel", sLogiciel, sIniRubriqueInfosClient) Then _
            Exit Function
        m_Cle.sClient = sClient
        m_Cle.sCleActivation = sCleActivation
        m_Cle.sEMail = sEMail

        ' Décoder la clé
        sCleDecodee = sCleActivation
        If Not bDecoderCle(sCleDecodee, sMsgErr, bCleAuthentification:=False) Then Exit Function
        If sCleDecodee = "" Then Exit Function

        ' Lire les options de la clé
        Dim iNSD%
        With m_Cle

            ' Tester le numéro du lecteur
            .sLecteur = Left(Application.StartupPath, 3)
            If Not bLireNSD(.sLecteur, iNSD) Then
                If Not bLireNSD(sLecteurDefaut, iNSD) Then
                    sMsgErr = "Installation impossible sur ce lecteur"
                    Exit Function
                End If
            End If
            If .iNumeroSerieDisque <> iNSD Then sMsgErr = "Clé invalide" : Exit Function

            ' Date limite
            If .dDateExpiration <> dDateIllimitee Then
                If .dDateExpiration < Now Then sMsgErr = "Date expirée" : Exit Function
            End If
            dDateExpiration = .dDateExpiration
            iNumeroLicence = .iNumeroLicence
            iOptions = .iOptionsLogiciel

            ' 08/09/2007 : Correction d'une faille critique existant depuis le 08/05/2002
            '  le n° de licence ne peut être égal à 0, et au moins une option doit être activée
            If iNumeroLicence = 0 Or iOptions = 0 Then sMsgErr = "Clé invalide" : Exit Function

        End With

        bTesterCleActivation = True
        Exit Function

Erreur:
        AfficherMsgErreur(Err, "bTesterCleActivation")

    End Function

    Private Function bLireNSD(ByRef sLecteur$, ByRef iNSD%) As Boolean

        ' Retourne le numéro de série du lecteur

        If bTrapErr Then On Error GoTo Erreur

        ' Autre méthode possible : même résultat !
        'Dim oFSO As Object, vLecteur As Variant
        'Set oFSO = CreateObject("Scripting.FileSystemObject")
        'Set vLecteur = oFSO.GetDrive(oFSO.GetDriveName( _
        'oFSO.GetAbsolutePathName(sLecteur)))
        'iNSD = vLecteur.SerialNumber
        'Set vLecteur = Nothing
        'Set oFSO = Nothing

        Dim sLabel, sSysName As String
        Dim iMaxComp, iSerial, iFlags, iRet As Integer
        Const iLongCheminMax% = 256
        sLabel = New String(Chr(0), iLongCheminMax)
        sSysName = New String(Chr(0), iLongCheminMax)

        iRet = GetVolumeInformation(sLecteur, sLabel, 255, iSerial, iMaxComp,
            iFlags, sSysName, 255)

        ' Unable to retrieve volume information
        If iRet = 0 Then Exit Function

        ' The device is not ready
        If Err.LastDllError = 21 Then Exit Function

        ' Impossible de déterminer le numéro de série
        If iSerial = 0 Then Exit Function

        ' Parfois le n° de série est négatif !
        iNSD = System.Math.Abs(iSerial)
        bLireNSD = True
        Exit Function

Erreur:
        AfficherMsgErreur(Err, "bLireNSD")

    End Function

    Private Function sConvInt32BitsEnChaineLisible$(lVal%, ByRef iNbCarPrevus%,
        ByRef sMsgErr$,
        Optional ByRef bVerifierLimiteInt32 As Boolean = False,
        Optional ByRef bVerifierLimiteInt16 As Boolean = False)

        ' Transformer un entier long (4 octets en VB6) en notation base au choix
        ' et coder la chaine à l'aide des chiffres et des lettres minuscules
        ' puis majuscules en utilisant juste le nombre de caractères nécessaires
        ' Fonction inverse : iConvChaineLisibleEnInt32Bits

        sConvInt32BitsEnChaineLisible = ""

        ' La base maximale est 64
        ' 26 minuscules + 26 majuscules + 10 chiffres = 62 caractères + 2
        If iBaseCodage > 64 Or iBaseCodage < 2 Then _
            sMsgErr = "Base de codage invalide" : Exit Function

        Dim iCar, iNbCarMax, i, iCodeCar As Integer 'Short
        Dim iDiv%
        Dim sChaine$

        If bVerifierLimiteInt16 Then
            Do Until (iBaseCodage ^ iNbCarMax) >= iMaxInt16
                iNbCarMax = iNbCarMax + 1
            Loop
            If iNbCarMax > iNbCarPrevus Then
                sMsgErr = sMsgErr & " : Dépassement de capacité du codage : " &
                    iNbCarMax & " > " & iNbCarPrevus & " car."
                Exit Function
            End If
        End If

        iNbCarMax = 0
        ' Nombre maximum de caractères possibles = 6 pour un long en base 62
        Do Until (iBaseCodage ^ iNbCarMax) >= iMaxInt32
            iNbCarMax = iNbCarMax + 1
        Loop

        If iNbCarMax > iNbCarPrevus And bVerifierLimiteInt32 Then
            sMsgErr = sMsgErr & " : Dépassement de capacité du codage : " &
                iNbCarMax & " > " & iNbCarPrevus & " car."
            Exit Function
        End If

        ' Tableau des unités et du reste de la division précédente
        Const iUnite% = 0
        Const iReste% = 1
        Dim alDiv%(iNbCarMax, iReste)

        ' Remplissage du tableau des unités de la base
        alDiv(iNbCarMax, 1) = lVal
        For i = (iNbCarMax - 1) To 0 Step -1
            iDiv = CInt(iBaseCodage ^ i)
            alDiv(i, iUnite) = alDiv(i + 1, iReste) \ iDiv ' Unité
            ' Reste de la division entière
            alDiv(i, iReste) = alDiv(i + 1, iReste) Mod iDiv
        Next i
        alDiv(0, iReste) = alDiv(0, iUnite)

        ' Création de la chaine
        sChaine = ""
        For i = (iNbCarMax - 1) To 0 Step -1
            iCar = alDiv(i, iUnite)
            ' Sauter la valeur Zéro sauf pour la première unité
            If i < iNbCarPrevus Or iCar > 0 Then
                iCodeCar = iCoderCar(iCar, bDecoder:=True)
                sChaine = sChaine & Chr(iCodeCar)
            End If
        Next i

        If Len(sChaine) > iNbCarPrevus Then
            sMsgErr = sMsgErr & " : Dépassement de capacité du codage : " &
                iNbCarPrevus & " car."
            Exit Function
        End If

        sMsgErr = ""
        sConvInt32BitsEnChaineLisible = sChaine

    End Function

    Private Function iConvChaineLisibleEnInt32Bits%(sChaine$)

        ' Transformer une chaine représentant un numérique en notation base au choix
        ' en valeur numérique décimale (base 10) dans un entier long (signé)
        ' Fonction inverse : sConvInt32BitsEnChaineLisible
        ' Exemple base 62: 62 ^ 2 = 3844, 62 ^ 3 = 238328, 62 ^ 4 =  14776336

        Dim iCar, i, j, iLenStr As Integer
        Dim iCarCode, iCodeFinal As Integer
        If bTrapErr Then On Error GoTo Erreur
        iLenStr = Len(sChaine)
        For i = iLenStr To 1 Step -1
            iCar = Asc(Mid(sChaine, i, 1))
            iCarCode = iCoderCar(iCar)
            iCodeFinal = CInt(iCodeFinal + iCarCode * iBaseCodage ^ j)
            j = j + 1
        Next i

        iConvChaineLisibleEnInt32Bits = iCodeFinal
        Exit Function

Erreur:
        MsgBox("Dépassement de capacité du codage en Long :" & vbCrLf &
            "Changez les paramètres du codage", MsgBoxStyle.Critical)

    End Function

    Private Function iConvDateEnInt%(ByRef dDate As Date)

        Dim iMois, iAn As Integer
        If dDate = dDateIllimitee Then iConvDateEnInt = 0 : Exit Function
        iMois = Month(dDate)
        iAn = Year(dDate)
        ' Pour booster le marché de l'emploi info. dans un futur lointain,
        '  on va essayer de faire tenir le codage sur 2 caractères seulement :-)
        iAn = iAn - 2000
        If iAn < 0 Then
            iConvDateEnInt = 0
            dDate = dDateIllimitee
            Exit Function
        End If
        iConvDateEnInt = iMois + CInt(iAn) * 12 ' Codage en mois

    End Function

    Private Function dConvIntEnDate(ByRef iCodage%) As Date

        Dim iMois, iAn As Integer
        If iCodage = 0 Then dConvIntEnDate = dDateIllimitee : Exit Function
        iAn = CInt(iCodage / 12)
        iMois = iCodage - CInt(iAn) * 12
        iAn = iAn + 2000
        dConvIntEnDate = DateSerial(iAn, iMois, 1)

    End Function

    Private Function iCheckSum%(sChaine$)

        ' Calculer le Checksum d'un texte : somme de contrôle
        ' (ce n'est pas un véritable hash unique)

        Dim sBuffer$
        Dim i%
        Dim rCS As Single ' Mieux vaut laisser Single en cas de gd texte

        ' Calculer un premier checksum entier
        rCS = 0
        For i = 1 To Len(sChaine)
            rCS += Asc(Mid(sChaine, i, 1))
        Next i

        ' Calculer le checksum final
        Do While rCS > iMaxInt16
            'sBuffer = VB6.Format(rCS) ' Transformer l'entier en texte
            sBuffer = rCS.ToString ' Transformer l'entier en texte
            rCS = 0
            For i = 1 To Len(sBuffer)
                rCS += CSng(Val(Mid(sBuffer, i, 1)))
            Next i
        Loop

        iCheckSum = CInt(rCS)

    End Function

    Public Function sCheminFichierLicence$(
        Optional bVerifierFichierExiste As Boolean = False,
        Optional ByRef bFichierExiste0 As Boolean = False)

        ' Obtenir le nom du fichier licence .lic

        If bTrapErr Then On Error GoTo Erreur
        Dim bOK As Boolean
        bOK = bFichierExiste(m_sCheminLicence)
        ' Renvoyer l'existence du fichier en option
        If bVerifierFichierExiste Then bFichierExiste0 = bOK
        sCheminFichierLicence = m_sCheminLicence
        Exit Function

Erreur:
        AfficherMsgErreur(Err, "sCheminFichierLicence")

    End Function

    Public Function bLireChampLicence(ByRef sChamp$, ByRef sVal$, ByRef sSection$,
        Optional ByRef sFichier$ = "",
        Optional ByRef bAutoriserChaineVide As Boolean = False) As Boolean

        ' Lire un champ dans le fichier ini

        If bTrapErr Then On Error GoTo Erreur
        Dim bFichierExiste As Boolean
        If sFichier = "" Then
            sFichier = sCheminFichierLicence(bVerifierFichierExiste:=True,
                bFichierExiste0:=bFichierExiste)
            If bFichierExiste = False Then Exit Function
        End If

        If bLireFichierIni(sChamp, sSection, sFichier, sVal, "", bNumerique:=False,
            bPromptErr:=False) Then
            If sVal = "" Then
                If bAutoriserChaineVide Then bLireChampLicence = True : Exit Function
                Exit Function
            End If
            bLireChampLicence = True
        End If
        Exit Function

Erreur:
        AfficherMsgErreur(Err, "bLireChampLicence")

    End Function

    Public Function bEcrireChampLicence(ByRef sChamp$, sVal$, ByRef sSection$) As Boolean

        ' Ecrire un champ dans le fichier .lic

        Dim sCheminFichierLic$ = sCheminFichierLicence()
        bEcrireChampLicence = bEcrireFichierIni(sChamp, sSection, sCheminFichierLic,
            sVal, bPromptErr:=True, bNumerique:=False)

    End Function

    Public Function bChargerFichierContrat(ByRef sFichier$, ByRef sContrat$) As Boolean

        ' Chargement du ficher Contrat.txt

        If bTrapErr Then On Error GoTo Erreur

        Dim lNumFichier%
        If Not bFichierExiste(sFichier) Then
            sContrat = "Le fichier " & sFichier & " est introuvable"
            Exit Function
        End If
        lNumFichier = FreeFile()
        FileOpen(lNumFichier, sFichier, OpenMode.Input)
        Input(lNumFichier, sContrat)
        FileClose(lNumFichier)
        bChargerFichierContrat = True
        Exit Function

Erreur:
        AfficherMsgErreur(Err, "bChargerFichierContrat")

    End Function

End Class