
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
            sMsg = sMsg & vbCrLf & "D�faut : [" & sDefaut & "]"
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

        ' Attention, si la rubrique ou le fichier n'existe pas, cette fct la cr�e
        ' L'erreur ne peut se produire qu'en cas d'�chec d'acc�s (ou cr�ation) fichier

        Dim sContenu$
        Dim iRet%
        'If IsNumeric(vValeur) Then : attention !!! si n� de t�l�phone : 0 tronqu� !!!
        If bBooleen Then
            'sContenu = Str$(Val(vValeur)) : ne marche pas
            If CBool(sValeur) = True Then
                sContenu = "-1"
            Else
                sContenu = "0"
            End If
        ElseIf bNumerique Then
            sContenu = Str(sValeur) ' Pour conserver le pt d�cimal
        Else
            sContenu = sValeur ' Perte du pt d�cimal : ne pas utiliser si d�cimal
        End If
        iRet = WritePrivateProfileString(sSection, sCle, sContenu, sFichier)
        If bPromptErr And iRet <= 0 Then GoTo Erreur
        bEcrireFichierIni = True
        Exit Function

Erreur:
        Dim sMsg$
        sMsg = "Fonction: bEcrireFichierIni" & vbCrLf
        sMsg = sMsg & "Impossible d'�crire la rubrique [" & sCle & "]"
        sMsg = sMsg & vbCrLf & "dans la section [" & sSection & "]"
        sMsg = sMsg & vbCrLf & "dans le fichier [" & sFichier & "]"
        sMsg = sMsg & vbCrLf &
            "Cause possible : fichier prot�g� ou �chec de l'�criture sur le lecteur"
        AfficherMsgErreur(Err, "bEcrireFichierIni", sMsg)

    End Function

End Module