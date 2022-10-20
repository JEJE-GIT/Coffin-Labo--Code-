using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class GestionnairePeripherique : MonoBehaviour
{
    private PeripheriqueEntree peripheriqueEntree;

    [SerializeField] private Vector2 deplacement;    //Cette propriété va contenir les valeurs des touches appuyé et il sera affiché dans l'inspecteur, Cela pourra aider si les touches fonctionnent correctement.

    [SerializeField] private Vector2 regard;    //Cette propriété va contenir les valeurs de la position de la souri ou de l'axe du joystick et il sera affiché dans l'inspecteur.

    public float mouvementRegardHorizontal; //Cette propriété va représenter la position de la vue horizontale du regard du joueur
    public float mouvementRegardVertical;   //Cette propriété va représenter la position de la vue Vertical du regard du joueur

    public float mouvementDeplacementHorizontal;     //Cette propriété va représenter la position de déplacement horizontal du joueur
    public float mouvementDeplacementVertical;      //Cette propriété va représenter la position de déplacement Vertical du joueur

    public bool courrirActif;       //Cette booléenne va déterminer si le joueur appui sur le bouton courir

    public UnityEvent sauter;   //Créer l'évènement sauter qui sera écouté selon l'écouteur, il sera dans la méthode LireSaut
    public UnityEvent cliquer;  //Créer l'évènement cliquer qui sera écouté selon l'écouteur, il sera dans la méthode LireClic
    public UnityEvent changementCamera;     //Créer l'évènement changementCamera qui sera écouté selon l'écouteur, il sera dans la méthode LireChangementCamera


    private void Awake()
    {
        peripheriqueEntree = new PeripheriqueEntree();

        peripheriqueEntree.PersonnageAuSol.Marcher.performed += LireMouvementDeplacement;   //En appelant la méthode LireMouvementDeplacement, la périphérique d'entré du déplacement du personnage au sol permet d'être écouté. Il va être activé
        peripheriqueEntree.PersonnageAuSol.Marcher.canceled += LireMouvementDeplacement;    //En appelant la méthode LireMouvementDeplacement, la périphérique d'entré du déplacement du personnage au sol permet d'être écouté. Il va être désactivé

        peripheriqueEntree.PersonnageAuSol.Regarder.performed += LireMouvementRegard;   //En appelant la méthode LireMouvementRegard, la périphérique d'entré du Regard du personnage au sol permet d'être écouté. Il va être activé
        peripheriqueEntree.PersonnageAuSol.Regarder.canceled += LireMouvementRegard;    //En appelant la méthode LireMouvementRegard, la périphérique d'entré du Regard du personnage au sol permet d'être écouté. Il va être désactivé




        peripheriqueEntree.PersonnageAuSol.ChangerCamera.started += LireChangementCamera;   //En appelant la méthode LireChangementCamera, la périphérique d'entré pour faire changer la caméra du joueur permet d'être écouté. Il va être activé


        peripheriqueEntree.PersonnageAuSol.Sauter.started += LireSaut;  //En appelant la méthode LireSaut, la périphérique d'entré pour faire sauter le personnage au sol permet d'être écouté. Il va être activé

        peripheriqueEntree.PersonnageAuSol.Courir.started += LireCourrir;   //En appelant la méthode LireCourrir, la périphérique d'entré pour faire courir le personnage permet d'être écouté. Il va être activé
        peripheriqueEntree.PersonnageAuSol.Courir.canceled += LireCourrir;  //En appelant la méthode LireCourrir, la périphérique d'entré pour faire courir le personnage permet d'être écouté. Il va être désactivé

        peripheriqueEntree.PersonnageAuSol.Cliquer.started += LireClic;     //En appelant la méthode LireClick, la périphérique d'entré du click de la souris permet d'être écouté. Il va être activé

    }

    private void LireChangementCamera(InputAction.CallbackContext context)
    {
        changementCamera.Invoke();  //Cet unity Envent se fera appelé dans le script Gestionnaire caméra, sans lui, il n'aurait pas d'écouteur lors du changement de caméra
    }

    private void OnEnable()
    {
        peripheriqueEntree.PersonnageAuSol.Enable();    //Active les Inputs du personnage au sol, c'est à dire Marche, courir, sauter, etc.
    }
    public void OnDisable()
    {
        peripheriqueEntree.PersonnageAuSol.Disable();   //désactive les Inputs du personnage au sol, c'est à dire Marche, courir, sauter, etc.
    }

    private void LireCourrir(InputAction.CallbackContext context)
    {
        courrirActif = context.ReadValueAsButton();     //Cet unity Envent se fera appelé dans le script Deplacement personnage caméra, sans lui, il n'aurait pas d'écouteur. Sa valeur boléenne déterminera si le bouton courrir est appuyé (true) ou pas (false)
    }

    private void LireClic(InputAction.CallbackContext context)
    {
        cliquer.Invoke();   //Cet unity Envent se fera appelé dans le script Gestionnaire de click, sans lui, il n'aurait pas d'écouteur lors du click 
    }

    private void LireMouvementRegard(InputAction.CallbackContext context)
    {
        regard = Vector2.ClampMagnitude( context.ReadValue<Vector2>(), 1 );     //Transfert les données de la position souris en x et y

        mouvementRegardHorizontal = regard.x;   //Cette propriété va contenir la valeur horizontal (x) de la souris
        mouvementRegardVertical = regard.y;  //Cette propriété va contenir la valeur horizontal (y) de la souris
    }

    public void LireSaut(InputAction.CallbackContext context)
    {
        sauter.Invoke();    //Cet unity Envent se fera appelé dans le script deplacement personnage, sans lui, il n'aurait pas d'écouteur lors du changement de caméra
    }

    private void LireMouvementDeplacement(InputAction.CallbackContext context)
    {
        deplacement = context.ReadValue<Vector2>(); //Transfert les données des boutons de navigations en x et y

        mouvementDeplacementHorizontal = deplacement.x;    //Cette propriété va contenir la valeur horizontal (x) des boutons de navigations (gauche et droite)
        mouvementDeplacementVertical = deplacement.y;   //Cette propriété va contenir la valeur vertical (y) des boutons de navigations (haut et bas)
    }

}

