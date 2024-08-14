
' modIni.vb : Module de gestion des fichiers ini
' ---------

Module modIni

    Private Declare Function WritePrivateProfileString% Lib "kernel32" Alias _
        "WritePrivateProfileStringA" (lpApplicationName$, lpKeyName$, lpString$, lpFileName$)

    Private Declare Function GetPrivateProfileString% Lib "kernel32" Alias _
        "GetPrivateProfileStringA" (lpApplicationName$, lpKeyName$,
        lpDefault$, lpReturnedString$, nSize%, lpFileName$)

    Public Function bLireFichierIni(ByRef sCle$, ByRef sSection$,
        ByRef sFichier$, ByRef sValeur$, ByRef sDefaut$,
        Optional ByRef bNumerique As Boolean = True,
        Optional ByRef bBooleen As Boolean = False,
        Optional ByRef bPromptErr As Boolean = False) As Boolean

        ' Lire la valeur d'un champ dans un fichier ini

        If bTrapErr Then On Error GoTo Erreur

        Dim sContenu$
        Dim iRet%
        sContenu = New String(Chr(0), 255)
        iRet = GetPrivateProfileString(sSection, sCle, "", sContenu, Len(sContenu), sFichier)
        If iRet > 0 Then
            sValeur = Left(sContenu, iRet)
        Else
            sValeur = sDefaut
        End If
        If bNumerique And Not bBooleen Then sValeur = CStr(Val(sValeur))
        If bBooleen Then
            If CInt(sValeur) <> 0 Then sValeur = CStr(True)
        End If

        If bPromptErr And iRet <= 0 Then GoTo Erreur
        bLireFichierIni = True
        Exit Function

Erreur:
        Dim sMsg$
        sMsg = "Fonction: bLireFichierIni" & vbCrLf
        sMsg = sMsg & "Impossible de lire la rubrique [" & sCle & "]"
        sMsg = sMsg & vbCrLf & "dans la section [" & sSection & "]"
        sMsg = sMsg & vbCrLf & "dans le fichier [" & sFichier & "]"
        'If Not IsDBNull(vDefaut) And CStr(vDefaut) <> "" Then
        If CStr(sDefaut) <> "" Then
            sMsg = sMsg & vbCrLf & "Défaut : [" & sDefaut & "]"
        End If
        AfficherMsgErreur(Err, "bLireFichierIni", sMsg)
        sValeur = sDefaut
        Exit Function

    End Function

    Public Function bEcrireFichierIni(ByRef sCle$, ByRef sSection$,
        ByRef sFichier$, ByRef sValeur$,
        Optional ByRef bNumerique As Boolean = False,
        Optional ByRef bBooleen As Boolean = False,
        Optional ByRef bPromptErr As Boolean = True) As Boolean

        ' Ecrire la valeur d'un champ dans un fichier ini

        If bTrapErr Then On Error GoTo Erreur

        ' Attention, si la rubrique ou le fichier n'existe pas, cette fct la crée
        ' L'erreur ne peut se produire qu'en cas d'échec d'accès (ou création) fichier

        Dim sContenu$
        Dim iRet%
        'If IsNumeric(vValeur) Then : attention !!! si n° de téléphone : 0 tronqué !!!
        If bBooleen Then
            'sContenu = Str$(Val(vValeur)) : ne marche pas
            If CBool(sValeur) = True Then
                sContenu = "-1"
            Else
                sContenu = "0"
            End If
        ElseIf bNumerique Then
            sContenu = Str(sValeur) ' Pour conserver le pt décimal
        Else
            sContenu = sValeur ' Perte du pt décimal : ne pas utiliser si décimal
        End If
        iRet = WritePrivateProfileString(sSection, sCle, sContenu, sFichier)
        If bPromptErr And iRet <= 0 Then GoTo Erreur
        bEcrireFichierIni = True
        Exit Function

Erreur:
        Dim sMsg$
        sMsg = "Fonction: bEcrireFichierIni" & vbCrLf
        sMsg = sMsg & "Impossible d'écrire la rubrique [" & sCle & "]"
        sMsg = sMsg & vbCrLf & "dans la section [" & sSection & "]"
        sMsg = sMsg & vbCrLf & "dans le fichier [" & sFichier & "]"
        sMsg = sMsg & vbCrLf &
            "Cause possible : fichier protégé ou échec de l'écriture sur le lecteur"
        AfficherMsgErreur(Err, "bEcrireFichierIni", sMsg)

    End Function

End Module