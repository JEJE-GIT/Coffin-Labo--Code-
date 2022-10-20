
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestonnaireClick : MonoBehaviour
{
    
    [SerializeField] private GestionnairePeripherique gestionnairePeripherique;     //Pour accéder au script "gestionnairePeripherique", il faut créer une propriété qui est visible dans l'inspecteur. On peut implémenter le script gestionnairePeripherique directement dans l'inspecteur
    [SerializeField] private GameObject gameManager;     //Pour accéder au script "gamemanager", il faut créer une propriété qui est visible dans l'inspecteur. On va prendre le gameobjet "gameManager", mais on a pas encore accès au script
    [SerializeField] private GameObject changementScene;     //Pour accéder au script "changementScene", il faut créer une propriété qui est visible dans l'inspecteur. On va prendre le gameobjet "gameManager", mais on a pas encore accès au script

    private GameManager scriptManager;      //Grâce a cette propriété, on aura accès au script du gamemanager, mais il est vide pour l'instant
    private string nomGameObjet;        //Cette propriété va garder en mémoire le nom du gameObjet dans la scene 

    [SerializeField] private Camera mainCamera;    //Pour accéder aux données de la camera, il faut se créer une propriété de type Camera, mais il est vide pour l'instant...

    // Start is called before the first frame update
    void Start()
    {
        scriptManager = gameManager.GetComponent<GameManager>();       //Va chercher le script du gameobjet "GameManager" pour acceder a ses fonctions publiques
        gestionnairePeripherique.cliquer.AddListener(ProduireClick);    //Il fdaut ajouter un écouteur depuis l'Unity Event "cliquer" depuis le script "gestionnairePeripherique". L'écouteur dera la méthode "ProduireClick". Après avoir cliqué, la méthode "ProduireClick" va éxécuté
    }

    private void ProduireClick()
    {
        //Debug.Log("Click");     //Indique de le joueur à appuyé sur une touche pour cliquer via la console

        Vector2 milieuEcran = new Vector2(Screen.width / 2, Screen.height / 2);     //Créer une propriété de type vecteur 2 qui représentera le millieu de l'écran en divisant la longueur et largeur de l'écran en 2. C'est la même position ou sera la mire
        GameObject objetCollision;      //Créer une propriété de type GameObject pour vérifier quel Gameobject sera en collision avec le rayon, mais il est vide pour l'instant...



        Ray rayon = mainCamera.ScreenPointToRay(milieuEcran);  //Créer une propriété de type ray. Renvoi un rayon de la main camera jusqu'au millieu de l'écran
        RaycastHit hit;     //Créer une propriété de type RaycastHit. Récupère des informations à partir d'un raycast

        if (Physics.Raycast(rayon, out hit, 20))     //Si il y a une collision entre le rayon et un gameobjet...  (distance maximale de 6 du rayon)
        {
            if (hit.collider != null)       //si le rayon a touché un collider...
            {
                objetCollision = hit.transform.gameObject;  //La variable "objetCollision" contient maintenant une référence du gameobjet qui est en collision avec le rayon

                //Debug.Log(objetCollision.name);   //Indique les noms des gameobjets qui ont été en collision avec le rayon

                nomGameObjet = objetCollision.name;     //La propriété "nomGameObjet" va prendre en compte le nom du gameObjet avec un collider qui a été cliqué dans la scene 



                //---------LE JEU COMMENCE------\\

                switch (nomGameObjet)   //Selon le nom du gameobjet cliqué...
                {

                    //*-----NIVEAU1-----*\\

                    case "Disjoncteur_manette":     //Si le nom du gameobjet cliqué est la manette du disjoncteur...

                        scriptManager.animDisjoncteurManette.SetBool("actionner", true);      //Active cette boléenne pour activer l'animation du DisjoncteurManette
                        scriptManager.animpanneauCtrl.SetBool("activation", true);      //Active cette boléenne pour activer l'animation du DisjoncteurManette

                        scriptManager.ApparitionEnemies();

                        scriptManager.etape1 = true;    //l'étape 1 est maintenant réalisable

                        break;


                    case "1-Manette":       //Si le nom du gameobjet cliqué est la manette du panneau de CTRL...

                        if (scriptManager.etape1 == true)    //Si l'étape 1 est réalisable...
                        {
                            scriptManager.animCaissonHaut.SetBool("activer", true);     //Joue l'animation du caisson haut
                            scriptManager.animCaissonBas.SetBool("activer", true);     //Joue l'animation du caisson bas
                            scriptManager.animPanneauPlaqueChauffante.SetBool("tomber", true);      //Joue l'animation du panneau de la plaque chauffante
                            scriptManager.etape2 = true;    //l'étape 2 est maintenant réalisable
                        }

                        break;


                    case "le_panneau_plaque_chauffante":       //Si le nom du gameobjet cliqué est la manette du panneau de la plaque chauffante

                        if (scriptManager.etape2 == true)    //Si l'étape 2 est réalisable...
                        {
                            scriptManager.animGlace.SetBool("sachauffe", true);     //Joue l'animation du panneau de la glace qui fond
                            scriptManager.etape3 = true;    //l'étape 3 est maintenant réalisable
                        }

                        break;


                    case "cle_coffre":       //Si le nom du gameobjet cliqué est la manette du panneau de la plaque chauffante

                        if (scriptManager.etape3 == true)    //Si l'étape 3 est réalisable...
                        {
                            Destroy(scriptManager.gCleJaune);   //Détruit la clé jaune
                            scriptManager.cleJaune = true;      //Vous posséder la clé jaune
                            scriptManager.etape4 = true;    //l'étape 3 est maintenant réalisable
                        }

                        break;


                    case "leCoffre":       //Si le nom du gameobjet cliqué est la manette du panneau de la plaque chauffante

                        if (scriptManager.etape4 == true)    //Si l'étape 4 est réalisable...
                        {
                            if (scriptManager.cleJaune == true)     //Si vous possédez la clé jaune
                            {
                                scriptManager.animSoutienTopCoffre.SetBool("ouvre", true);      //Joue l'animation de l'ouverture du coffre
                                scriptManager.animmanetteRobots.SetBool("leve", true);      //Joue l'animation de la découverte de la manette
                                scriptManager.etape5 = true;    //l'étape 5 est maintenant réalisable
                                
                            }
                        }

                        break;

                    case "manette_robot":   //Si le nom du gameobjet cliqué est la manette

                        if (scriptManager.etape5 == true)    //Si l'étape 5 est réalisable...
                        {
                            scriptManager.deplacementEnemis.SetActive(false);
                            Destroy(scriptManager.enemies);     //Détruit les ennemies
                            Destroy(scriptManager.manetteRobots);   //Détruit la manette qui détruit les robots
                            scriptManager.gCleRouge.SetActive(true);    //Fait apparaitre la clé rouge
                            scriptManager.etape6 = true;    //l'étape 6 est maintenant réalisable
                        }

                        break;


                    case "cle_sortie_Cube":

                        if (scriptManager.etape6 == true)    //Si l'étape 6 est réalisable...
                        {
                            Destroy(scriptManager.gCleRouge);     //Détruit la clé rouge
                            scriptManager.cleRouge = true; //Vous posséder maintenant la clé rouge
                            scriptManager.etape7 = true;   //l'étape 7 est maintenant réalisable 
                        }

                        break;

                    case "panneau_code":

                        if (scriptManager.etape7 == true)    //Si l'étape 7 est réalisable...
                        {
                            if (scriptManager.cleRouge == true)     //Si vous possédez la clé rouge
                            {
                                scriptManager.lumièreSortie.SetActive(true);
                                scriptManager.etape8 = true;   //l'étape 8 est maintenant réalisable
                            }
                        }

                        break;


                    case "sortie":

                        if (scriptManager.etape8 == true)    //Si l'étape 8 est réalisable...
                        {
                            changementScene.GetComponent<ChangementScene>().FinNiveau1();   //Change la scene vers fin de Niveau1
                        }

                        break;




                    //***-----NIVEAU2-----***//

                    case "Casque_lumiere":

                        Destroy(scriptManager.casque_lumiereSol);   //Détruit le casque au Sol si le joueur click dessus
                        scriptManager.casque_lumiereJoueur.SetActive(true);     //Active le gameobjet casque lumière joueur, un casque va apparaître sur sa tête

                        break;


                    case "radio":

                        Destroy(scriptManager.radio);   //Détruit la radio si le joueur click dessus
                        //Debug.Log("Gagne 150 points");
                        scriptManager.nbPoint = scriptManager.nbPoint + 150;    //Le joueur gagne 150 points
                        scriptManager.nbObjetsRamasser++;   //Augmente de 1 le nombres d'objets ramassés
                        //Debug.Log(scriptManager.nbObjetsRamasser);

                        break;


                    case "telephone":

                        Destroy(scriptManager.telephone);   //Détruit le téléphone si le joueur click dessus
                        //Debug.Log("Gagne 300 points");
                        scriptManager.nbPoint = scriptManager.nbPoint + 300;    //Le joueur gagne 300 points
                        scriptManager.nbObjetsRamasser++;   //Augmente de 1 le nombres d'objets ramassés
                        //Debug.Log(scriptManager.nbObjetsRamasser);

                        break;


                    case "horloge":

                        Destroy(scriptManager.horloge);   //Détruit la radio si le joueur click dessus
                        //Debug.Log("Gagne 1000 points");
                        scriptManager.nbPoint = scriptManager.nbPoint + 1000;   //Le joueur gagne 1000 points
                        scriptManager.nbObjetsRamasser++;   //Augmente de 1 le nombres d'objets ramassés
                        //Debug.Log(scriptManager.nbObjetsRamasser);

                        break;

                }

            }
        }


    }

    
}
