
' modCryptage.vb : Module de cryptage
' --------------

Module modCryptage

#Const CryptagePerso = False

    Public Function sCrypter$(ByRef bCleAuthentification As Boolean, sCle$)

        ' Crypter/D�crypter une cl� de fa�on sym�trique donc r�versible
        ' Remplacez ici sCrypterXOR par l'appel vers votre propre fonction
        '  de cryptage
        ' Vous pouvez utiliser 2 algo. distincts pour la cl� d'authent.
        '  et la cl� d'activation
        ' Attention ! la difficult� consiste � ne conserver que des
        '  caract�res bien lisibles (compris dans la plage pr�cis�e
        '  par iBaseCodage) soit au maximum 64 caract�res :
        'Public Const iBaseCodage% = 64 ' Chiffres + MAJ + min + 2 car.

        ' Pour d�sactiver le cryptage :
        'sCrypter = sCle: Exit Function

#If CryptagePerso Then
        sCrypter = sCrypterPseudoAleatoire(bCleAuthentification, sCle) : Exit Function
#Else

        sCrypter = sCrypterXOR(sCle) : Exit Function
        'sCrypter = sCrypterXOR(sCrypter) ' V�rification de la r�versibilit�

        'sCrypter = sCrypterMaFonctionDeCryptage(sCle)

#End If

    End Function

    Private Function sCrypterXOR$(sCle$)

        Dim iCodeCarCrypte, iLen, i, iCodeCar, iCarXOR As Integer
        Dim iCar, iCarCrypte As Integer
        Dim sCleCryptee$

        sCleCryptee = sCle
        iLen = Len(sCle)
        For i = 1 To iLen
            iCar = Asc(Mid(sCle, i, 1))
            iCodeCar = iCoderCar(iCar)

            ' -------------------------------------
            ' Algorythme de cryptage
            ' Oui c'est b�te ! � vous de trouver un
            '  meilleur cryptage sym�trique
            iCarXOR = i
            iCodeCarCrypte = iXORCar(iCodeCar, CInt(iCarXOR))
            ' -------------------------------------

            iCarCrypte = iCoderCar(iCodeCarCrypte, bDecoder:=True)
            ' Remplacer le caract�re original par le caract�re crypt�
            Mid(sCleCryptee, i, 1) = Chr(iCarCrypte)

CarSuivant:
        Next i
        sCrypterXOR = sCleCryptee

    End Function

    Function iXORCar%(ByRef iCar%, ByRef iNombre%)

        ' Appliquer un XOR sur le caract�re pour le crypter de fa�on r�versible

        ' Ne pas modifier les bits au-del� de la base afin d'�viter
        '  de faire appara�tre un caract�re hors-base
        Const iMasque6PremiersBits% = 63 ' Pour iBaseCodage% = 64
        Const iMasque5PremiersBits% = 31 ' Pour iBaseCodage% = 32
        Const iMasque4PremiersBits% = 15 ' Pour iBaseCodage% = 16
        Const iMasque3PremiersBits% = 7 ' Pour iBaseCodage% = 8
        Const iMasque2PremiersBits% = 3 ' Pour iBaseCodage% = 4

        Select Case iBaseCodage
            Case 2 To 7 : iXORCar = (iNombre And iMasque2PremiersBits) Xor iCar
            Case 8 To 15 : iXORCar = (iNombre And iMasque3PremiersBits) Xor iCar
            Case 16 To 31 : iXORCar = (iNombre And iMasque4PremiersBits) Xor iCar
            Case 32 To 63 : iXORCar = (iNombre And iMasque5PremiersBits) Xor iCar
            Case 64 : iXORCar = (iNombre And iMasque6PremiersBits) Xor iCar
            Case Else : iXORCar = iCar
        End Select

    End Function

    Public Function iCoderCar%(ByRef iCodeCar%, Optional ByRef bDecoder As Boolean = False)

        ' Coder ou D�coder un caract�re � partir de son code ASCII
        '  vers le num�ro du caract�re dans le jeu de caract�res finaux
        '  (iBaseCodage = nbre de car. retenus pour le codage)

        ' Codage sur des caract�res bien lisibles
        Const iCode0% = 48
        Const iCode9% = iCode0 + 10 - 1 ' 57
        Const iCodeA% = 65
        Const iCodeZ% = iCodeA + 26 - 1 ' 90
        Const iCode_a% = 97
        Const iCode_z% = iCode_a + 26 - 1 ' 122
        Const iCodeDiese% = 35
        Const iCodeEtoile% = 42

        ' Si iBaseCodage > 32
        '  l'Amplitude de codage max. est = 26*2+10 = 62
        '  2^6 = 64, il faut donc ajouter 2 caract�res en plus
        '  pour pouvoir faire un XOR, on choisit les
        '  caract�res # et * car ils sont bien lisibles
        '  cf. iMasque7PremiersBits = 63 dans la fonction sCrypterXOR

        If bDecoder Then GoTo DecoderCar

        ' Modifier seulement les caract�res bien lisibles
        ' 48 -> 57  : 0123... -> 9
        Select Case iCodeCar
            ' 48 -> 57  : 0123... -> 9
            Case iCode0 To iCode9
                iCoderCar = iCodeCar - iCode0
                ' 65 -> 90  : ABC... -> Z
            Case iCodeA To iCodeZ
                iCoderCar = iCodeCar - (iCodeA - 10) ' 55
                ' 97 -> 122 : abc... -> z
            Case iCode_a To iCode_z
                iCoderCar = iCodeCar - (iCode_a - 26 - 10) ' 61
            Case iCodeDiese : iCoderCar = 62
            Case iCodeEtoile : iCoderCar = 63
            Case Else
                iCoderCar = iCodeCar
                MsgBox("Caract�re non autoris� !") : Return 0
        End Select
        Return iCoderCar

DecoderCar:
        ' Remettre le caract�re dans la plage lisible
        Dim iCodeCarBaseCodage, iCarDecode As Integer
        iCodeCarBaseCodage = iCodeCar
        'Case 0: iCoderCar = 0 ' Pas de cryptage
        ' 0123...  -> 9 : 48 -> 57
        Select Case iCodeCarBaseCodage
            'Case 0: iCoderCar = 0 ' Pas de cryptage
            ' 0123...  -> 9 : 48 -> 57
            Case 0 To 10 - 1
                iCarDecode = iCodeCarBaseCodage + iCode0
                ' ABC... -> Z   : 65 -> 90
            Case 10 To 26 + 10 - 1 ' 37
                iCarDecode = iCodeCarBaseCodage + iCodeA - 10 ' 55
                ' abc...   -> z : 97 -> 122
            Case 26 + 10 To 62 - 1 ' 36 � 61
                iCarDecode = iCodeCarBaseCodage + iCode_a - 26 - 10 ' 61
            Case 62 : iCarDecode = iCodeDiese
            Case 63 : iCarDecode = iCodeEtoile
            Case Else
                iCarDecode = iCodeCarBaseCodage
                MsgBox("Caract�re non autoris� !") : Return 0
        End Select
        Return iCarDecode

    End Function

End Module