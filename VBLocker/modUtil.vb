
' modUtil.vb : Module contenant quelques fonctions utilitaires
' ----------

Module modUtil

    Public Function iConv%(sTexte$, Optional iValDef% = 0)

        ' Traiter les erreurs de conversion d'un texte en Int32

        If sTexte.Length = 0 Then iConv = iValDef : Exit Function
        If IsNumeric(sTexte) Then
            Try ' On peut encore dépasser la valeur max.
                Dim dVal# = CDbl(sTexte)
                If dVal > Integer.MaxValue Then
                    iConv = iValDef
                Else
                    iConv = CInt(sTexte)
                End If
            Catch
                iConv = iValDef
            End Try
        Else
            iConv = iValDef
        End If

    End Function

    Public Function bFichierExiste(sCheminFichier$,
        Optional bPrompt As Boolean = False) As Boolean

        ' Retourne True si un fichier correspondant est trouvé
        ' Ne fonctionne pas avec un filtre, par ex. du type C:\*.txt
        bFichierExiste = IO.File.Exists(sCheminFichier)

        If Not bFichierExiste And bPrompt Then _
            MsgBox("Impossible de trouver le fichier :" & vbLf & sCheminFichier,
                MsgBoxStyle.Critical, sTitreMsg & " - Fichier introuvable")

    End Function

    Public Function bChoisirFichier(ByRef sCheminFichier$, sFiltre$, sExtDef$,
        sTitre$, Optional sInitDir$ = "") As Boolean

        ' Afficher une boite de dialogue pour choisir un fichier
        ' Exemple de filtre : "|Fichiers texte (*.txt)|*.txt|Tout les fichiers (*.*)|*.*"
        ' On peut indiquer le dossier initial via InitDir, ou bien via le chemin du fichier

        Static bInit As Boolean = False

        Dim ofd As New OpenFileDialog
        With ofd
            If Not bInit Then
                bInit = True
                If sInitDir.Length = 0 Then
                    If sCheminFichier.Length = 0 Then
                        .InitialDirectory = Application.StartupPath
                    Else
                        .InitialDirectory = IO.Path.GetDirectoryName(sCheminFichier)
                    End If
                Else
                    .InitialDirectory = sInitDir
                End If
            End If
            .CheckFileExists = True
            .DefaultExt = sExtDef
            .Filter = sFiltre
            .Multiselect = False
            .Title = sTitre
            .ShowDialog()
            If .FileName <> "" Then bChoisirFichier = True : sCheminFichier = .FileName
        End With

        Return True

    End Function

    Public Sub OuvrirAppliAssociee(sCheminFichier$,
        Optional bMax As Boolean = False,
        Optional bVerifierFichier As Boolean = True)
        If bVerifierFichier Then
            ' Ne pas vérifier le fichier si c'est une URL à lancer
            If Not bFichierExiste(sCheminFichier, bPrompt:=True) Then Exit Sub
        End If
        Dim p As New Process
        p.StartInfo = New ProcessStartInfo(sCheminFichier)
        If bMax Then p.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
        p.Start()
    End Sub

    Public Sub AfficherMsgErreur(ByRef Erreur As Microsoft.VisualBasic.ErrObject,
        Optional sTitreFct$ = "", Optional sInfo$ = "",
        Optional sDetailMsgErr$ = "")

        If Not Cursor.Current.Equals(Cursors.Default) Then _
            Cursor.Current = Cursors.Default
        Dim sMsg$ = ""
        If sTitreFct <> "" Then sMsg = "Fonction : " & sTitreFct
        If sInfo <> "" Then sMsg &= vbCrLf & sInfo
        If Erreur.Number > 0 Then
            sMsg &= vbCrLf & "Err n°" & Erreur.Number.ToString & " :"
            sMsg &= vbCrLf & Erreur.Description
        End If
        If sDetailMsgErr <> "" Then sMsg &= vbCrLf & sDetailMsgErr
        MsgBox(sMsg, MsgBoxStyle.Critical, sTitreMsg)

    End Sub

    Public Sub AfficherMsgErreur2(ByRef Ex As Exception,
        Optional sTitreFct$ = "", Optional sInfo$ = "",
        Optional sDetailMsgErr$ = "",
        Optional bCopierMsgPressePapier As Boolean = True,
        Optional ByRef sMsgErrFinal$ = "")

        If Not Cursor.Current.Equals(Cursors.Default) Then _
            Cursor.Current = Cursors.Default
        Dim sMsg$ = ""
        If sTitreFct <> "" Then sMsg = "Fonction : " & sTitreFct
        If sInfo <> "" Then sMsg &= vbCrLf & sInfo
        If sDetailMsgErr <> "" Then sMsg &= vbCrLf & sDetailMsgErr
        If Ex.Message <> "" Then
            sMsg &= vbCrLf & Ex.Message.Trim
            If Not IsNothing(Ex.InnerException) Then _
                sMsg &= vbCrLf & Ex.InnerException.Message
        End If
        If bCopierMsgPressePapier Then CopierPressePapier(sMsg)
        sMsgErrFinal = sMsg
        MsgBox(sMsg, MsgBoxStyle.Critical)

    End Sub

    Public Sub CopierPressePapier(sInfo$)

        ' Copier des informations dans le presse-papier de Windows
        ' (elles resteront jusqu'à ce que l'application soit fermée)

        Try
            Dim dataObj As New DataObject
            dataObj.SetData(DataFormats.Text, sInfo)
            Clipboard.SetDataObject(dataObj)
        Catch ex As Exception
            ' Le presse-papier peut être indisponible
            AfficherMsgErreur2(ex, "CopierPressePapier",
                bCopierMsgPressePapier:=False)
        End Try

    End Sub

    Public Function sLirePressePapier$()

        ' Lire les informations du presse-papier de Windows

        Try
            If Clipboard.ContainsText Then
                sLirePressePapier = Clipboard.GetText()
            Else
                sLirePressePapier = ""
            End If
        Catch ex As Exception
            ' Le presse-papier peut être indisponible
            AfficherMsgErreur2(ex, "sLirePressePapier",
                bCopierMsgPressePapier:=False)
            sLirePressePapier = ""
        End Try

    End Function

End Module