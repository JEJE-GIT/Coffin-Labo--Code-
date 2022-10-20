
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestonnaireClick : MonoBehaviour
{
    
    [SerializeField] private GestionnairePeripherique gestionnairePeripherique;     //Pour acc�der au script "gestionnairePeripherique", il faut cr�er une propri�t� qui est visible dans l'inspecteur. On peut impl�menter le script gestionnairePeripherique directement dans l'inspecteur
    [SerializeField] private GameObject gameManager;     //Pour acc�der au script "gamemanager", il faut cr�er une propri�t� qui est visible dans l'inspecteur. On va prendre le gameobjet "gameManager", mais on a pas encore acc�s au script
    [SerializeField] private GameObject changementScene;     //Pour acc�der au script "changementScene", il faut cr�er une propri�t� qui est visible dans l'inspecteur. On va prendre le gameobjet "gameManager", mais on a pas encore acc�s au script

    private GameManager scriptManager;      //Gr�ce a cette propri�t�, on aura acc�s au script du gamemanager, mais il est vide pour l'instant
    private string nomGameObjet;        //Cette propri�t� va garder en m�moire le nom du gameObjet dans la scene 

    [SerializeField] private Camera mainCamera;    //Pour acc�der aux donn�es de la camera, il faut se cr�er une propri�t� de type Camera, mais il est vide pour l'instant...

    // Start is called before the first frame update
    void Start()
    {
        scriptManager = gameManager.GetComponent<GameManager>();       //Va chercher le script du gameobjet "GameManager" pour acceder a ses fonctions publiques
        gestionnairePeripherique.cliquer.AddListener(ProduireClick);    //Il fdaut ajouter un �couteur depuis l'Unity Event "cliquer" depuis le script "gestionnairePeripherique". L'�couteur dera la m�thode "ProduireClick". Apr�s avoir cliqu�, la m�thode "ProduireClick" va �x�cut�
    }

    private void ProduireClick()
    {
        //Debug.Log("Click");     //Indique de le joueur � appuy� sur une touche pour cliquer via la console

        Vector2 milieuEcran = new Vector2(Screen.width / 2, Screen.height / 2);     //Cr�er une propri�t� de type vecteur 2 qui repr�sentera le millieu de l'�cran en divisant la longueur et largeur de l'�cran en 2. C'est la m�me position ou sera la mire
        GameObject objetCollision;      //Cr�er une propri�t� de type GameObject pour v�rifier quel Gameobject sera en collision avec le rayon, mais il est vide pour l'instant...



        Ray rayon = mainCamera.ScreenPointToRay(milieuEcran);  //Cr�er une propri�t� de type ray. Renvoi un rayon de la main camera jusqu'au millieu de l'�cran
        RaycastHit hit;     //Cr�er une propri�t� de type RaycastHit. R�cup�re des informations � partir d'un raycast

        if (Physics.Raycast(rayon, out hit, 20))     //Si il y a une collision entre le rayon et un gameobjet...  (distance maximale de 6 du rayon)
        {
            if (hit.collider != null)       //si le rayon a touch� un collider...
            {
                objetCollision = hit.transform.gameObject;  //La variable "objetCollision" contient maintenant une r�f�rence du gameobjet qui est en collision avec le rayon

                //Debug.Log(objetCollision.name);   //Indique les noms des gameobjets qui ont �t� en collision avec le rayon

                nomGameObjet = objetCollision.name;     //La propri�t� "nomGameObjet" va prendre en compte le nom du gameObjet avec un collider qui a �t� cliqu� dans la scene 



                //---------LE JEU COMMENCE------\\

                switch (nomGameObjet)   //Selon le nom du gameobjet cliqu�...
                {

                    //*-----NIVEAU1-----*\\

                    case "Disjoncteur_manette":     //Si le nom du gameobjet cliqu� est la manette du disjoncteur...

                        scriptManager.animDisjoncteurManette.SetBool("actionner", true);      //Active cette bol�enne pour activer l'animation du DisjoncteurManette
                        scriptManager.animpanneauCtrl.SetBool("activation", true);      //Active cette bol�enne pour activer l'animation du DisjoncteurManette

                        scriptManager.ApparitionEnemies();

                        scriptManager.etape1 = true;    //l'�tape 1 est maintenant r�alisable

                        break;


                    case "1-Manette":       //Si le nom du gameobjet cliqu� est la manette du panneau de CTRL...

                        if (scriptManager.etape1 == true)    //Si l'�tape 1 est r�alisable...
                        {
                            scriptManager.animCaissonHaut.SetBool("activer", true);     //Joue l'animation du caisson haut
                            scriptManager.animCaissonBas.SetBool("activer", true);     //Joue l'animation du caisson bas
                            scriptManager.animPanneauPlaqueChauffante.SetBool("tomber", true);      //Joue l'animation du panneau de la plaque chauffante
                            scriptManager.etape2 = true;    //l'�tape 2 est maintenant r�alisable
                        }

                        break;


                    case "le_panneau_plaque_chauffante":       //Si le nom du gameobjet cliqu� est la manette du panneau de la plaque chauffante

                        if (scriptManager.etape2 == true)    //Si l'�tape 2 est r�alisable...
                        {
                            scriptManager.animGlace.SetBool("sachauffe", true);     //Joue l'animation du panneau de la glace qui fond
                            scriptManager.etape3 = true;    //l'�tape 3 est maintenant r�alisable
                        }

                        break;


                    case "cle_coffre":       //Si le nom du gameobjet cliqu� est la manette du panneau de la plaque chauffante

                        if (scriptManager.etape3 == true)    //Si l'�tape 3 est r�alisable...
                        {
                            Destroy(scriptManager.gCleJaune);   //D�truit la cl� jaune
                            scriptManager.cleJaune = true;      //Vous poss�der la cl� jaune
                            scriptManager.etape4 = true;    //l'�tape 3 est maintenant r�alisable
                        }

                        break;


                    case "leCoffre":       //Si le nom du gameobjet cliqu� est la manette du panneau de la plaque chauffante

                        if (scriptManager.etape4 == true)    //Si l'�tape 4 est r�alisable...
                        {
                            if (scriptManager.cleJaune == true)     //Si vous poss�dez la cl� jaune
                            {
                                scriptManager.animSoutienTopCoffre.SetBool("ouvre", true);      //Joue l'animation de l'ouverture du coffre
                                scriptManager.animmanetteRobots.SetBool("leve", true);      //Joue l'animation de la d�couverte de la manette
                                scriptManager.etape5 = true;    //l'�tape 5 est maintenant r�alisable
                                
                            }
                        }

                        break;

                    case "manette_robot":   //Si le nom du gameobjet cliqu� est la manette

                        if (scriptManager.etape5 == true)    //Si l'�tape 5 est r�alisable...
                        {
                            scriptManager.deplacementEnemis.SetActive(false);
                            Destroy(scriptManager.enemies);     //D�truit les ennemies
                            Destroy(scriptManager.manetteRobots);   //D�truit la manette qui d�truit les robots
                            scriptManager.gCleRouge.SetActive(true);    //Fait apparaitre la cl� rouge
                            scriptManager.etape6 = true;    //l'�tape 6 est maintenant r�alisable
                        }

                        break;


                    case "cle_sortie_Cube":

                        if (scriptManager.etape6 == true)    //Si l'�tape 6 est r�alisable...
                        {
                            Destroy(scriptManager.gCleRouge);     //D�truit la cl� rouge
                            scriptManager.cleRouge = true; //Vous poss�der maintenant la cl� rouge
                            scriptManager.etape7 = true;   //l'�tape 7 est maintenant r�alisable 
                        }

                        break;

                    case "panneau_code":

                        if (scriptManager.etape7 == true)    //Si l'�tape 7 est r�alisable...
                        {
                            if (scriptManager.cleRouge == true)     //Si vous poss�dez la cl� rouge
                            {
                                scriptManager.lumi�reSortie.SetActive(true);
                                scriptManager.etape8 = true;   //l'�tape 8 est maintenant r�alisable
                            }
                        }

                        break;


                    case "sortie":

                        if (scriptManager.etape8 == true)    //Si l'�tape 8 est r�alisable...
                        {
                            changementScene.GetComponent<ChangementScene>().FinNiveau1();   //Change la scene vers fin de Niveau1
                        }

                        break;




                    //***-----NIVEAU2-----***//

                    case "Casque_lumiere":

                        Destroy(scriptManager.casque_lumiereSol);   //D�truit le casque au Sol si le joueur click dessus
                        scriptManager.casque_lumiereJoueur.SetActive(true);     //Active le gameobjet casque lumi�re joueur, un casque va appara�tre sur sa t�te

                        break;


                    case "radio":

                        Destroy(scriptManager.radio);   //D�truit la radio si le joueur click dessus
                        //Debug.Log("Gagne 150 points");
                        scriptManager.nbPoint = scriptManager.nbPoint + 150;    //Le joueur gagne 150 points
                        scriptManager.nbObjetsRamasser++;   //Augmente de 1 le nombres d'objets ramass�s
                        //Debug.Log(scriptManager.nbObjetsRamasser);

                        break;


                    case "telephone":

                        Destroy(scriptManager.telephone);   //D�truit le t�l�phone si le joueur click dessus
                        //Debug.Log("Gagne 300 points");
                        scriptManager.nbPoint = scriptManager.nbPoint + 300;    //Le joueur gagne 300 points
                        scriptManager.nbObjetsRamasser++;   //Augmente de 1 le nombres d'objets ramass�s
                        //Debug.Log(scriptManager.nbObjetsRamasser);

                        break;


                    case "horloge":

                        Destroy(scriptManager.horloge);   //D�truit la radio si le joueur click dessus
                        //Debug.Log("Gagne 1000 points");
                        scriptManager.nbPoint = scriptManager.nbPoint + 1000;   //Le joueur gagne 1000 points
                        scriptManager.nbObjetsRamasser++;   //Augmente de 1 le nombres d'objets ramass�s
                        //Debug.Log(scriptManager.nbObjetsRamasser);

                        break;

                }

            }
        }


    }

    
}
