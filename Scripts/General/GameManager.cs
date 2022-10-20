using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public string nomScene; //Cette propri�t� repr�sente le nom de la scene
    public ChangementScene changementScene;  //Cette propri�t� me permetera d'appeler ses fonctions pour changer de scene

    //***------NIVEAU 1------***\\
    public bool etape1 = false;  //etape1 donne la possibilit� d'interragir avec le panneau de CTRL
    public bool etape2 = false;  //etape2 donne la possibilit� d'interragir avec le panneau de la plaque chauffante
    public bool etape3 = false;  //etape3 donne la possibilit� de prendre la cl� jaune
    public bool etape4 = false;  //etape4 donne la possibilit� d'ouvrir le coffre
    public bool etape5 = false;  //etape5 donne la possibilit� de d�truire les robots et de faire apparaitre la cl� rouge
    public bool etape6 = false;  //etape1 donne la possibilit� 
    public bool etape7 = false;  //etape2 donne la possibilit� 
    public bool etape8 = false;  //etape3 donne la possibilit� 
    public bool etape9 = false;  //etape4 donne la possibilit�
    public bool etape10 = false;  //etape5 va donner la possibilit� de sortir du niveau1


    public bool cleJaune = false;   //cleJaune donne la possibilit� d'ouvrir le coffre
    public bool cleRouge = false;   //cleRouge donne la possibilit� d'allumer l'ordinateur

    //GAMEOBJETS\\
    public GameObject disjoncteurManette;  //Pour acc�der au Animator du disjoncteurManette, il faut cr�er une propri�t� qui est visible dans l'inspecteur. On va prendre le gameobjet "Disjoncteur_manette", mais on a pas encore acc�s � l'animator   
    public GameObject panneauCtrl;  //Pour acc�der au Animator du PanneauCtrl, il faut cr�er une propri�t� qui est visible dans l'inspecteur. On va prendre le gameobjet "PanneauCtrl", mais on a pas encore acc�s � l'animator
    public GameObject enemiBleu;  //Pour manipuler enemiBleu, il faut cr�er une propri�t� qui est visible dans l'inspecteur. On va prendre le gameobjet "enemiBleu"
    public GameObject enemiRouge;  //Pour manipuler enemiBleu, il faut cr�er une propri�t� qui est visible dans l'inspecteur. On va prendre le gameobjet "enemiBleu"
    public GameObject enemiJaune;  //Pour manipuler enemiBleu, il faut cr�er une propri�t� qui est visible dans l'inspecteur. On va prendre le gameobjet "enemiBleu"
    public GameObject caissonHaut;  //Pour acc�der au Animator du caissonHaut, il faut cr�er une propri�t� qui est visible dans l'inspecteur. On va prendre le gameobjet "caissonHaut", mais on a pas encore acc�s � l'animator
    public GameObject caissonBas;  //Pour acc�der au Animator du caissonBas, il faut cr�er une propri�t� qui est visible dans l'inspecteur. On va prendre le gameobjet "caissonBas", mais on a pas encore acc�s � l'animator
    public GameObject panneauPlaqueChauffante;  //Pour acc�der au Animator du panneauPlaqueChauffante, il faut cr�er une propri�t� qui est visible dans l'inspecteur. On va prendre le gameobjet "panneauPlaqueChauffante", mais on a pas encore acc�s � l'animator
    public GameObject glace;  //Pour acc�der au Animator de Glace, il faut cr�er une propri�t� qui est visible dans l'inspecteur. On va prendre le gameobjet "Glace", mais on a pas encore acc�s � l'animator
    public GameObject gCleJaune;  //pour detruire la cl� jaune quand on va la prendre, il faut avoir acc�s au gameobjet "cle_coffre" en le mettant directement dans l'inspecteur.
    public GameObject soutienTopCoffre;  //Pour acc�der au Animator du soutienTopCoffre, il faut cr�er une propri�t� qui est visible dans l'inspecteur. On va prendre le gameobjet "soutienTopCoffre", mais on a pas encore acc�s � l'animator
    public GameObject manetteRobots;  //Pour acc�der au Animator du manetteRobots, il faut cr�er une propri�t� qui est visible dans l'inspecteur. On va prendre le gameobjet "manetteRobots", mais on a pas encore acc�s � l'animator
    public GameObject enemies;  //Pour acc�der au gameobjet "Enemies", il faut cr�er une propri�t� qui est visible dans l'inspecteur. On va prendre le gameobjet "Enemies", mais on a pas encore acc�s
    public GameObject gCleRouge;  //pour detruire la cl� rouge quand on va la prendre, il faut avoir acc�s au gameobjet "cle_coffre" en le mettant directement dans l'inspecteur.
    public GameObject lumi�reSortie;
    public GameObject deplacementEnemis;

    //ANIMATORS\\
    public Animator animDisjoncteurManette;    //Gr�ce a cette propri�t�, on aura acc�s � l'animator du DisjoncteurManette, mais il est vide pour l'instant
    public Animator animpanneauCtrl;    //Gr�ce a cette propri�t�, on aura acc�s � l'animator du panneauCtrl, mais il est vide pour l'instant
    public Animator animCaissonHaut;    //Gr�ce a cette propri�t�, on aura acc�s � l'animator du animmanivellePanneauCtrl, mais il est vide pour l'instant
    public Animator animCaissonBas;    //Gr�ce a cette propri�t�, on aura acc�s � l'animator du animmanivellePanneauCtrl, mais il est vide pour l'instant
    public Animator animPanneauPlaqueChauffante;    //Gr�ce a cette propri�t�, on aura acc�s � l'animator du animmanivellePanneauCtrl, mais il est vide pour l'instant
    public Animator animGlace;    //Gr�ce a cette propri�t�, on aura acc�s � l'animator du animmanivellePanneauCtrl, mais il est vide pour l'instant
    public Animator animSoutienTopCoffre;    //Gr�ce a cette propri�t�, on aura acc�s � l'animator du soutienTopCoffre, mais il est vide pour l'instant
    public Animator animmanetteRobots;    //Gr�ce a cette propri�t�, on aura acc�s � l'animator du animmanetteRobots, mais il est vide pour l'instant

    public float positionYEnemiBleu;   
    public float positionYEnemiRouge;
    public float positionYEnemiJaune;





    //***------NIVEAU 2------***\\
    public int nbObjetsRamasser = 0;  //cette propri�t� va bient�t incr�menter quand on va ramasser les objets, sa valeur sera aussi affich� su le UI du jeu.
    public int nbPoint = 0; //Cette propri�t� repr�sente le nombre de points accumul� par le joueur. quand on rammasse des items de qu�te, le nombre de points va augmenter


    //GAMEOBJETS\\
    public GameObject casque_lumiereSol; //Gr�ce � cette propri�t�, on pourra manipuler le casque au sol, comme le faire dispara�tre par exemple
    public GameObject casque_lumiereJoueur; //Gr�ce � cette propri�t�, on pourra manipuler le casque sur le joueur, comme le faire apparaitre par exemple
    public GameObject radio; //Gr�ce � cette propri�t�, on pourra manipuler la radio, comme le faire dispara�tre par exemple
    public GameObject horloge;  //Gr�ce � cette propri�t�, on pourra manipuler l'horloge, comme le faire dispara�tre par exemple
    public GameObject telephone;  //Gr�ce � cette propri�t�, on pourra manipuler le telephone, comme le faire dispara�tre par exemple

    public TextMeshProUGUI textPoints;   //Cette propri�t� repr�sente le texte de nombre de points
    public TextMeshProUGUI textitems;   //Cette propri�t� repr�sente le texte de nombre d'objets ramas�s

    //public GameObject tele;  //Gr�ce � cette propri�t�, on pourra manipuler la t�l�, comme le faire dispara�tre par exemple




    // Start is called before the first frame update
    void Start()
    {

        nomScene = SceneManager.GetActiveScene().name;


        if (nomScene == "TP-1_Integration3D 1")
        {
            animDisjoncteurManette = disjoncteurManette.GetComponent<Animator>();   //Prends le component Animator du disjoncteurManette pour acc�der � ces animations
            animpanneauCtrl = panneauCtrl.GetComponent<Animator>();   //Prends le component Animator du panneauCtrl pour acc�der � ces animations
            animCaissonHaut = caissonHaut.GetComponent<Animator>();   //Prends le component Animator du caissonHaut pour acc�der � ces animations
            animCaissonBas = caissonBas.GetComponent<Animator>();   //Prends le component Animator du caissonBas pour acc�der � ces animations
            animPanneauPlaqueChauffante = panneauPlaqueChauffante.GetComponent<Animator>();     //Prends le component Animator du panneauPlaqueChauffante pour acc�der � ces animations
            animGlace = glace.GetComponent<Animator>();     //Prends le component Animator de glace pour acc�der � ces animations
            animSoutienTopCoffre = soutienTopCoffre.GetComponent<Animator>();     //Prends le component Animator de animSoutienTopCoffre pour acc�der � ces animations
            animmanetteRobots = manetteRobots.GetComponent<Animator>();     //Prends le component Animator de animmanetteRobots pour acc�der � ces animations

            gCleRouge.SetActive(false);  //D�sactive la cl�Rouge, elle sera activ�e apr�s que les enemis seront �limin�s (voir le script du gestionnaire de click)
            lumi�reSortie.SetActive(false); //D�sactive la cl�Rouge, elle sera activ�e apr�s que l'ordinateur � �t� d�v�rouill� (voir le script du gestionnaire de click)
        }

        if(nomScene == "TP-2_Integration3D")    //Si le nom de la scene est le niveau 2
        {
            casque_lumiereJoueur.SetActive(false); //D�sactive la cl�Rouge, elle sera activ�e apr�s que le joueur click sur le casque lumi�re au sol (voir le script du gestionnaire de click)
        }

        
    }

    // Update is called once per frame
    void Update()
    {

        if (nomScene == "TP-1_Integration3D 1")
        {
            Cursor.lockState = CursorLockMode.Locked;       //Quand le Niveau1 va d�marrer, la souris ne pourra pas quitter l'�cran et il va dispara�tre
        }

        else if (nomScene == "TP-2_Integration3D")
        {
            Cursor.lockState = CursorLockMode.Locked;       //Quand le Niveau1 va d�marrer, la souris ne pourra pas quitter l'�cran et il va dispara�tre
        }

        else 
        {
            Cursor.lockState = CursorLockMode.None;     //Si le jeu commence ailleur que sur le niveau 1 ou 2, la souri peut naviguer librement
        }


        if (nomScene == "TP-2_Integration3D")   //Si le nom de la scene est le niveau 2
        {

            AfficherPoints();   //Apelle cette m�thode pour afficher le nombre de points
            AfficherNBObjet();  //Apelle cette m�thode pour afficher le nombre d'objets ramass�s

            if (nbObjetsRamasser >= 3)  //Si le joueur a ramass�s 3 objets
            {
                changementScene.FinNiveau2();   //Appelle la m�thode FinNiveau2() dans le script changementScene pour charger la scene de fin
            }
        }
    }


     public void ApparitionEnemies()
    {

        if (nomScene == "TP-1_Integration3D 1")
        {
            positionYEnemiBleu = enemiBleu.transform.position.y + 17;   //C'est la position de l'enemi bleu par d�faut en y quand il se lib�rera de ses pinces 
            positionYEnemiRouge = enemiBleu.transform.position.y + 17;  //C'est la position de l'enemi rouge par d�faut en y quand il se lib�rera de ses pinces
            positionYEnemiJaune = enemiBleu.transform.position.y + 17;  //C'est la position de l'enemi jaune par d�faut en y quand il se lib�rera de ses pinces

            enemiBleu.transform.position -= new Vector3(0, positionYEnemiBleu, 0);    //D�place l'enemie bleu en y selon la variable positionYEnemiBleu
            enemiRouge.transform.position -= new Vector3(0, positionYEnemiRouge, 0);  //D�place l'enemie rouge en y selon la variable positionYEnemiBleu
            enemiJaune.transform.position -= new Vector3(0, positionYEnemiJaune, 0);  //D�place l'enemie jaune en y selon la variable positionYEnemiBleu
        }

    }

    public void AfficherPoints()
    {
        textPoints.text = nbPoint + "";  //le nombre de points va s'accumer et sera affich� au cours du jeu
    }

    public void AfficherNBObjet()
    {
        textitems.text = nbObjetsRamasser + "/3";   //le nombre d'objets ramass�s va s'accumuler et sera affich� au cours du jeu
    }

}
