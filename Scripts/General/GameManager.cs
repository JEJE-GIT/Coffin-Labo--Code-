using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public string nomScene; //Cette propriété représente le nom de la scene
    public ChangementScene changementScene;  //Cette propriété me permetera d'appeler ses fonctions pour changer de scene

    //***------NIVEAU 1------***\\
    public bool etape1 = false;  //etape1 donne la possibilité d'interragir avec le panneau de CTRL
    public bool etape2 = false;  //etape2 donne la possibilité d'interragir avec le panneau de la plaque chauffante
    public bool etape3 = false;  //etape3 donne la possibilité de prendre la clé jaune
    public bool etape4 = false;  //etape4 donne la possibilité d'ouvrir le coffre
    public bool etape5 = false;  //etape5 donne la possibilité de détruire les robots et de faire apparaitre la clé rouge
    public bool etape6 = false;  //etape1 donne la possibilité 
    public bool etape7 = false;  //etape2 donne la possibilité 
    public bool etape8 = false;  //etape3 donne la possibilité 
    public bool etape9 = false;  //etape4 donne la possibilité
    public bool etape10 = false;  //etape5 va donner la possibilité de sortir du niveau1


    public bool cleJaune = false;   //cleJaune donne la possibilité d'ouvrir le coffre
    public bool cleRouge = false;   //cleRouge donne la possibilité d'allumer l'ordinateur

    //GAMEOBJETS\\
    public GameObject disjoncteurManette;  //Pour accéder au Animator du disjoncteurManette, il faut créer une propriété qui est visible dans l'inspecteur. On va prendre le gameobjet "Disjoncteur_manette", mais on a pas encore accès à l'animator   
    public GameObject panneauCtrl;  //Pour accéder au Animator du PanneauCtrl, il faut créer une propriété qui est visible dans l'inspecteur. On va prendre le gameobjet "PanneauCtrl", mais on a pas encore accès à l'animator
    public GameObject enemiBleu;  //Pour manipuler enemiBleu, il faut créer une propriété qui est visible dans l'inspecteur. On va prendre le gameobjet "enemiBleu"
    public GameObject enemiRouge;  //Pour manipuler enemiBleu, il faut créer une propriété qui est visible dans l'inspecteur. On va prendre le gameobjet "enemiBleu"
    public GameObject enemiJaune;  //Pour manipuler enemiBleu, il faut créer une propriété qui est visible dans l'inspecteur. On va prendre le gameobjet "enemiBleu"
    public GameObject caissonHaut;  //Pour accéder au Animator du caissonHaut, il faut créer une propriété qui est visible dans l'inspecteur. On va prendre le gameobjet "caissonHaut", mais on a pas encore accès à l'animator
    public GameObject caissonBas;  //Pour accéder au Animator du caissonBas, il faut créer une propriété qui est visible dans l'inspecteur. On va prendre le gameobjet "caissonBas", mais on a pas encore accès à l'animator
    public GameObject panneauPlaqueChauffante;  //Pour accéder au Animator du panneauPlaqueChauffante, il faut créer une propriété qui est visible dans l'inspecteur. On va prendre le gameobjet "panneauPlaqueChauffante", mais on a pas encore accès à l'animator
    public GameObject glace;  //Pour accéder au Animator de Glace, il faut créer une propriété qui est visible dans l'inspecteur. On va prendre le gameobjet "Glace", mais on a pas encore accès à l'animator
    public GameObject gCleJaune;  //pour detruire la clé jaune quand on va la prendre, il faut avoir accès au gameobjet "cle_coffre" en le mettant directement dans l'inspecteur.
    public GameObject soutienTopCoffre;  //Pour accéder au Animator du soutienTopCoffre, il faut créer une propriété qui est visible dans l'inspecteur. On va prendre le gameobjet "soutienTopCoffre", mais on a pas encore accès à l'animator
    public GameObject manetteRobots;  //Pour accéder au Animator du manetteRobots, il faut créer une propriété qui est visible dans l'inspecteur. On va prendre le gameobjet "manetteRobots", mais on a pas encore accès à l'animator
    public GameObject enemies;  //Pour accéder au gameobjet "Enemies", il faut créer une propriété qui est visible dans l'inspecteur. On va prendre le gameobjet "Enemies", mais on a pas encore accès
    public GameObject gCleRouge;  //pour detruire la clé rouge quand on va la prendre, il faut avoir accès au gameobjet "cle_coffre" en le mettant directement dans l'inspecteur.
    public GameObject lumièreSortie;
    public GameObject deplacementEnemis;

    //ANIMATORS\\
    public Animator animDisjoncteurManette;    //Grâce a cette propriété, on aura accès à l'animator du DisjoncteurManette, mais il est vide pour l'instant
    public Animator animpanneauCtrl;    //Grâce a cette propriété, on aura accès à l'animator du panneauCtrl, mais il est vide pour l'instant
    public Animator animCaissonHaut;    //Grâce a cette propriété, on aura accès à l'animator du animmanivellePanneauCtrl, mais il est vide pour l'instant
    public Animator animCaissonBas;    //Grâce a cette propriété, on aura accès à l'animator du animmanivellePanneauCtrl, mais il est vide pour l'instant
    public Animator animPanneauPlaqueChauffante;    //Grâce a cette propriété, on aura accès à l'animator du animmanivellePanneauCtrl, mais il est vide pour l'instant
    public Animator animGlace;    //Grâce a cette propriété, on aura accès à l'animator du animmanivellePanneauCtrl, mais il est vide pour l'instant
    public Animator animSoutienTopCoffre;    //Grâce a cette propriété, on aura accès à l'animator du soutienTopCoffre, mais il est vide pour l'instant
    public Animator animmanetteRobots;    //Grâce a cette propriété, on aura accès à l'animator du animmanetteRobots, mais il est vide pour l'instant

    public float positionYEnemiBleu;   
    public float positionYEnemiRouge;
    public float positionYEnemiJaune;





    //***------NIVEAU 2------***\\
    public int nbObjetsRamasser = 0;  //cette propriété va bientôt incrémenter quand on va ramasser les objets, sa valeur sera aussi affiché su le UI du jeu.
    public int nbPoint = 0; //Cette propriété représente le nombre de points accumulé par le joueur. quand on rammasse des items de quête, le nombre de points va augmenter


    //GAMEOBJETS\\
    public GameObject casque_lumiereSol; //Grâce à cette propriété, on pourra manipuler le casque au sol, comme le faire disparaître par exemple
    public GameObject casque_lumiereJoueur; //Grâce à cette propriété, on pourra manipuler le casque sur le joueur, comme le faire apparaitre par exemple
    public GameObject radio; //Grâce à cette propriété, on pourra manipuler la radio, comme le faire disparaître par exemple
    public GameObject horloge;  //Grâce à cette propriété, on pourra manipuler l'horloge, comme le faire disparaître par exemple
    public GameObject telephone;  //Grâce à cette propriété, on pourra manipuler le telephone, comme le faire disparaître par exemple

    public TextMeshProUGUI textPoints;   //Cette propriété représente le texte de nombre de points
    public TextMeshProUGUI textitems;   //Cette propriété représente le texte de nombre d'objets ramasés

    //public GameObject tele;  //Grâce à cette propriété, on pourra manipuler la télé, comme le faire disparaître par exemple




    // Start is called before the first frame update
    void Start()
    {

        nomScene = SceneManager.GetActiveScene().name;


        if (nomScene == "TP-1_Integration3D 1")
        {
            animDisjoncteurManette = disjoncteurManette.GetComponent<Animator>();   //Prends le component Animator du disjoncteurManette pour accéder à ces animations
            animpanneauCtrl = panneauCtrl.GetComponent<Animator>();   //Prends le component Animator du panneauCtrl pour accéder à ces animations
            animCaissonHaut = caissonHaut.GetComponent<Animator>();   //Prends le component Animator du caissonHaut pour accéder à ces animations
            animCaissonBas = caissonBas.GetComponent<Animator>();   //Prends le component Animator du caissonBas pour accéder à ces animations
            animPanneauPlaqueChauffante = panneauPlaqueChauffante.GetComponent<Animator>();     //Prends le component Animator du panneauPlaqueChauffante pour accéder à ces animations
            animGlace = glace.GetComponent<Animator>();     //Prends le component Animator de glace pour accéder à ces animations
            animSoutienTopCoffre = soutienTopCoffre.GetComponent<Animator>();     //Prends le component Animator de animSoutienTopCoffre pour accéder à ces animations
            animmanetteRobots = manetteRobots.GetComponent<Animator>();     //Prends le component Animator de animmanetteRobots pour accéder à ces animations

            gCleRouge.SetActive(false);  //Désactive la cléRouge, elle sera activée après que les enemis seront éliminés (voir le script du gestionnaire de click)
            lumièreSortie.SetActive(false); //Désactive la cléRouge, elle sera activée après que l'ordinateur à été dévérouillé (voir le script du gestionnaire de click)
        }

        if(nomScene == "TP-2_Integration3D")    //Si le nom de la scene est le niveau 2
        {
            casque_lumiereJoueur.SetActive(false); //Désactive la cléRouge, elle sera activée après que le joueur click sur le casque lumière au sol (voir le script du gestionnaire de click)
        }

        
    }

    // Update is called once per frame
    void Update()
    {

        if (nomScene == "TP-1_Integration3D 1")
        {
            Cursor.lockState = CursorLockMode.Locked;       //Quand le Niveau1 va démarrer, la souris ne pourra pas quitter l'écran et il va disparaître
        }

        else if (nomScene == "TP-2_Integration3D")
        {
            Cursor.lockState = CursorLockMode.Locked;       //Quand le Niveau1 va démarrer, la souris ne pourra pas quitter l'écran et il va disparaître
        }

        else 
        {
            Cursor.lockState = CursorLockMode.None;     //Si le jeu commence ailleur que sur le niveau 1 ou 2, la souri peut naviguer librement
        }


        if (nomScene == "TP-2_Integration3D")   //Si le nom de la scene est le niveau 2
        {

            AfficherPoints();   //Apelle cette méthode pour afficher le nombre de points
            AfficherNBObjet();  //Apelle cette méthode pour afficher le nombre d'objets ramassés

            if (nbObjetsRamasser >= 3)  //Si le joueur a ramassés 3 objets
            {
                changementScene.FinNiveau2();   //Appelle la méthode FinNiveau2() dans le script changementScene pour charger la scene de fin
            }
        }
    }


     public void ApparitionEnemies()
    {

        if (nomScene == "TP-1_Integration3D 1")
        {
            positionYEnemiBleu = enemiBleu.transform.position.y + 17;   //C'est la position de l'enemi bleu par défaut en y quand il se libèrera de ses pinces 
            positionYEnemiRouge = enemiBleu.transform.position.y + 17;  //C'est la position de l'enemi rouge par défaut en y quand il se libèrera de ses pinces
            positionYEnemiJaune = enemiBleu.transform.position.y + 17;  //C'est la position de l'enemi jaune par défaut en y quand il se libèrera de ses pinces

            enemiBleu.transform.position -= new Vector3(0, positionYEnemiBleu, 0);    //Déplace l'enemie bleu en y selon la variable positionYEnemiBleu
            enemiRouge.transform.position -= new Vector3(0, positionYEnemiRouge, 0);  //Déplace l'enemie rouge en y selon la variable positionYEnemiBleu
            enemiJaune.transform.position -= new Vector3(0, positionYEnemiJaune, 0);  //Déplace l'enemie jaune en y selon la variable positionYEnemiBleu
        }

    }

    public void AfficherPoints()
    {
        textPoints.text = nbPoint + "";  //le nombre de points va s'accumer et sera affiché au cours du jeu
    }

    public void AfficherNBObjet()
    {
        textitems.text = nbObjetsRamasser + "/3";   //le nombre d'objets ramassés va s'accumuler et sera affiché au cours du jeu
    }

}
