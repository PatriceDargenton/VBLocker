
' modCourriel.vb : Module pour envoyer un courriel via la messagerie par défaut
' --------------

Module modCourriel

    ' API pour la fonction bEnvoyerCourriel
    Private Declare Function ShellExecute% Lib "shell32.dll" Alias "ShellExecuteA" (hwnd%, lpOperation$,
        lpFile$, lpParameters$, lpDirectory$, nShowCmd%)

    Public Function bEnvoyerCourriel(sNomDestinataire$, sCourrielDest$, sSujet$, sContenu$) As Boolean

        ' Envoyer un courriel via la messagerie par défaut
        ' (via un ShellExecute mailto)

        If bTrapErr Then On Error GoTo Erreur

        ' Créer la chaîne de commande avec les paramètres fournis
        Dim sCmd$ = ""
        If sSujet.Length > 0 Then sCmd = "&Subject=" & sSujet
        Const sSautLigneMailTo$ = "%0D%0A"
        ' 14/10/2007 Attention : les guillemets (") ne passent pas avec OutLook,
        '  il faut donc les enlever (les guillemets ne marchent qu'avec Outlook Express, 
        '   à moins de trouver le bon codage ?)
        If sContenu.Length > 0 Then sCmd &= "&Body=" &
        sContenu.Replace(vbCrLf, sSautLigneMailTo).Replace("""", "")

        'Dim sCC$, sCCC$
        'If Len(sCC) Then sCmd = sCmd & "&CC=" & sCC ' Copie Carbone
        ' Blind Carbon Coy : Copie Carbone Cachée
        'If Len(sCCC) Then sCmd = sCmd & "&BCC=" & sCCC 

        ' La pièce jointe ne fonctionne pas avec Outlook Express
        '  ce qui est genant car on ne sait pas comment le client va envoyer le message
        ' (il faut une solution qui fonctionne chez tous les clients, 
        '  quel que soit leur logiciel de messagerie)
        ' Solution : mettre le contenu dans le corps du message, et faire une 
        '  fonction d'import via le presse papier
        ' (l'autre solution est de passer par une session MAPI : 
        '  fonctionne en général avec les pièces jointes sous Windows NT et >,
        '  mais pas toujours sous Windows 9x et Me)
        'Const sCheminPJ$ = "C:\Tmp\BigSoft.lic"
        'Const sCheminPJ$ = "C:/Tmp/BigSoft.lic"
        'If sCheminPJ.Length > 0 Then sCmd &= "&Attach='" & sCheminPJ & "'"
        'If sCheminPJ.Length > 0 Then sCmd &= "&attachment='" & sCheminPJ & "'"
        'If sCheminPJ.Length > 0 Then sCmd &= "&attachment=" & sCheminPJ
        'If sCheminPJ.Length > 0 Then sCmd &= "&attachment=" & """" & sCheminPJ & """"

        ' Remplacer le premier '&' (s'il existe) par un '?'
        If Mid(sCmd, 1, 1) = "&" Then Mid(sCmd, 1, 1) = "?"

        ' Ajouter la commande 'mailto:' et l'adresse
        Dim sDestinataire$ = sNomDestinataire & "<" & sCourrielDest & ">"
        sCmd = "mailto:" & sDestinataire & sCmd
        Const SW_SHOWNORMAL& = 1
        ' 0 : Me.hwnd
        ShellExecute(0, "open", sCmd, vbNullString, vbNullString, SW_SHOWNORMAL)
        bEnvoyerCourriel = True
        Exit Function

Erreur:
        AfficherMsgErreur(Err, "bEnvoyerCourriel")

    End Function

End Module