
' modConstantes.vb : Module des constantes des projets liés à VBLocker
' ----------------

Module modConstantes

    ' Cette constante est définie dans le fichier projet :
    '    <DefineConstants>Win32 = True, VBUnLocker = True</DefineConstants>
    '#Const VBUnLocker = True

#If DEBUG Then
    Public Const bDebug As Boolean = True
    Public Const bRelease As Boolean = False
    Public Const bTrapErr As Boolean = False
#Else
    Public Const bDebug As Boolean = False
    Public Const bRelease As Boolean = True
    Public Const bTrapErr As Boolean = True
#End If

    Public Const sTitreMsg$ = "VBLocker"

    Public Const sVendeurDef$ = "Bigrosoft-Ventes"
    Public Const sEMailVendeurDef$ = "ventes@bigrosoft.com"
    Public Const sFichierLicenceDef$ = "BigSoft.lic"
    Public Const sMsgMailEnvoye$ =
        "Le courriel a été déposé dans la boite d'envoi :" & vbCrLf &
        "Le cas échéant, n'oubliez pas d'ouvrir votre messagerie pour l'envoi effectif."

    Public Const sLecteurDefaut$ = "C:\"

    Public Const iMaxInt16% = Short.MaxValue ' 32767 ' (2 ^ 15) - 1
    Public Const iMaxInt32% = Integer.MaxValue ' CInt((2 ^ 31) - 1) ' = 2147483647

    Public Const sIniRubriqueInfosClient$ = "Formulaire"
    Public Const sIniRubriqueCle$ = "Cle"
    Public Const sIniCleActivation$ = "CleActivation"
    Public Const sIniCleAuthentification$ = "CleAuthentification"
    Public Const sIniClient$ = "Client"
    Public Const sIniLogiciel$ = "Logiciel"
    Public Const sIniEMail$ = "EMail"

    ' Via courriel :
    Public Const sGm$ = """"
    Public Const sSepar$ = " : "
    Public Const sChampLogiciel$ = "Logiciel"
    Public Const sChampClient$ = "Client"
    Public Const sChampCourrielClient$ = "Courriel client" ' Ancienne version : "EMail Client"
    Public Const sChampCleAuthentification$ = "Cle d'authentification"
    Public Const sChampCleActivation$ = "Cle d'activation"

    ' Base du codage sur plusieurs caractères
    '  d'un entier long (4 octets en VB6)
    '  Entre 2 et 62 au maximum,
    '  par exemple, codage en base décimale (10),
    '  hexadécimale (16), en binaire (2), ...
    ' on enlève WXYZ afin de faciliter le cryptage avec le XOR
    '  car le nombre de caractères est une puissance de 2
    Public Const iBaseCodage% = 32 ' Chiffres + MAJ - WXYZ
    ' Si iBaseCodage = 64 : Diminuez iLenNSD à 6 dans ClsVBLocker
    'Public Const iBaseCodage% = 64 ' Chiffres + MAJ + min + 2 car.
    ' Désactiver ou revoir le cryptage si iBaseCodage n'est pas une puissance de 2
    '  (sinon des caractères hors base vont apparaître après le cryptage)
    ' Augmenter la taille des champs (par ex. iLenNSD) si la base diminue
    'Public Const iBaseCodage% = 62 ' Chiffres + MAJ + min
    'Public Const iBaseCodage% = 36  ' Chiffres + MAJ
    'Public Const iBaseCodage% = 10  ' Chiffres
    'Public Const iBaseCodage% = 20  ' Chiffres + 10 premières MAJ

    ' Masques des bits codant les options offertes pour la licence achetée
    Public Const iMasqueVersionEvaluation% = 1
    Public Const iMasqueToutesOptions% = 2
    Public Const iMasqueOption1% = 4
    Public Const iMasqueOption2% = 8
    Public Const iMasqueOption3% = 16
    Public Const iMasqueOption4% = 32
    Public Const iMasqueOption5% = 64

    ' Par convention :
    Public Const dDateIllimitee As Date = #1/1/2000# ' mm/jj/aaaa

    ' Champs de la clé de protection
    Public Structure TCleProtection
        Dim bVersionEvaluation As Boolean
        Dim iOptionsLogiciel%
        Dim iNumeroLicence%
        Dim dDateExpiration As Date
        Dim sLecteur$ ' C:\ ou autre
        Dim iNumeroSerieDisque%
        Dim sClient$
        Dim iCSClient% ' CS pour CheckSum
        Dim sLogiciel$
        Dim iCSLogiciel%
        Dim sEMail$
        Dim iCSEMail%
        Dim sCleAuthentification$
        Dim sCleActivation$
    End Structure

End Module