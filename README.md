# VBLocker
Protégez votre application commerciale

Supposons que vous soyez le responsable des ventes de la société Bigrosoft.com, vous voulez protéger votre nouveau logiciel BigSoft v1.0 contre la copie illégale :

1. Vous mettez votre logiciel BigSoft v1.0 sur le Web, il est présenté comme une version d'évaluation ;

2. Les internautes téléchargent votre logiciel et l'installent sur leur PC sous Windows ;

3. Le logiciel fonctionne mais le message d'information "Version d'évaluation" s'affiche partout, le client se décide donc à acquérir une licence pour BigSoft v1.0 : pour cela, il clique sur un bouton qui va déclancher la procédure d'activation (débridage) du logiciel : le nom du client et les options souhaitées sont demandés au client, puis la procédure crypte ces infos en les combinant avec le numéro de série (de la partition) du disque dur du client. Enfin, la procédure envoie un courriel contenant ces infos cryptées à ventes@bigrosoft.com ;

4. Le responsable (vous !) reçoit ce courriel, et si le paiement correspondant à la licence avec les options souhaitées est bien reçue également, il lance la procédure d'activation (ActivationBigSoft.exe) du coté du vendeur cette fois : celle-ci à pour but de débrider uniquement le logiciel installé sur le disque dur du client qui vient de payer. La procédure coté vendeur génère un courriel avec ce code de débridage spécifique et crypté également, et ce courriel est retourné au client ;

5. Le client réceptionne ce courriel et saisit dans le logiciel la clé fournie : le logiciel est débridé :-)

## Table des matières
- [Versions](#versions)
- [Liens](#liens)

## Versions

Voir le [Changelog.md](Changelog.md)

## Liens

Documentation d'origine complète : [VBLocker.html](http://patrice.dargenton.free.fr/CodesSources/VBLocker.html)