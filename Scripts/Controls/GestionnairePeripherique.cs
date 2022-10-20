using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class GestionnairePeripherique : MonoBehaviour
{
    private PeripheriqueEntree peripheriqueEntree;

    [SerializeField] private Vector2 deplacement;    //Cette propri�t� va contenir les valeurs des touches appuy� et il sera affich� dans l'inspecteur, Cela pourra aider si les touches fonctionnent correctement.

    [SerializeField] private Vector2 regard;    //Cette propri�t� va contenir les valeurs de la position de la souri ou de l'axe du joystick et il sera affich� dans l'inspecteur.

    public float mouvementRegardHorizontal; //Cette propri�t� va repr�senter la position de la vue horizontale du regard du joueur
    public float mouvementRegardVertical;   //Cette propri�t� va repr�senter la position de la vue Vertical du regard du joueur

    public float mouvementDeplacementHorizontal;     //Cette propri�t� va repr�senter la position de d�placement horizontal du joueur
    public float mouvementDeplacementVertical;      //Cette propri�t� va repr�senter la position de d�placement Vertical du joueur

    public bool courrirActif;       //Cette bool�enne va d�terminer si le joueur appui sur le bouton courir

    public UnityEvent sauter;   //Cr�er l'�v�nement sauter qui sera �cout� selon l'�couteur, il sera dans la m�thode LireSaut
    public UnityEvent cliquer;  //Cr�er l'�v�nement cliquer qui sera �cout� selon l'�couteur, il sera dans la m�thode LireClic
    public UnityEvent changementCamera;     //Cr�er l'�v�nement changementCamera qui sera �cout� selon l'�couteur, il sera dans la m�thode LireChangementCamera


    private void Awake()
    {
        peripheriqueEntree = new PeripheriqueEntree();

        peripheriqueEntree.PersonnageAuSol.Marcher.performed += LireMouvementDeplacement;   //En appelant la m�thode LireMouvementDeplacement, la p�riph�rique d'entr� du d�placement du personnage au sol permet d'�tre �cout�. Il va �tre activ�
        peripheriqueEntree.PersonnageAuSol.Marcher.canceled += LireMouvementDeplacement;    //En appelant la m�thode LireMouvementDeplacement, la p�riph�rique d'entr� du d�placement du personnage au sol permet d'�tre �cout�. Il va �tre d�sactiv�

        peripheriqueEntree.PersonnageAuSol.Regarder.performed += LireMouvementRegard;   //En appelant la m�thode LireMouvementRegard, la p�riph�rique d'entr� du Regard du personnage au sol permet d'�tre �cout�. Il va �tre activ�
        peripheriqueEntree.PersonnageAuSol.Regarder.canceled += LireMouvementRegard;    //En appelant la m�thode LireMouvementRegard, la p�riph�rique d'entr� du Regard du personnage au sol permet d'�tre �cout�. Il va �tre d�sactiv�




        peripheriqueEntree.PersonnageAuSol.ChangerCamera.started += LireChangementCamera;   //En appelant la m�thode LireChangementCamera, la p�riph�rique d'entr� pour faire changer la cam�ra du joueur permet d'�tre �cout�. Il va �tre activ�


        peripheriqueEntree.PersonnageAuSol.Sauter.started += LireSaut;  //En appelant la m�thode LireSaut, la p�riph�rique d'entr� pour faire sauter le personnage au sol permet d'�tre �cout�. Il va �tre activ�

        peripheriqueEntree.PersonnageAuSol.Courir.started += LireCourrir;   //En appelant la m�thode LireCourrir, la p�riph�rique d'entr� pour faire courir le personnage permet d'�tre �cout�. Il va �tre activ�
        peripheriqueEntree.PersonnageAuSol.Courir.canceled += LireCourrir;  //En appelant la m�thode LireCourrir, la p�riph�rique d'entr� pour faire courir le personnage permet d'�tre �cout�. Il va �tre d�sactiv�

        peripheriqueEntree.PersonnageAuSol.Cliquer.started += LireClic;     //En appelant la m�thode LireClick, la p�riph�rique d'entr� du click de la souris permet d'�tre �cout�. Il va �tre activ�

    }

    private void LireChangementCamera(InputAction.CallbackContext context)
    {
        changementCamera.Invoke();  //Cet unity Envent se fera appel� dans le script Gestionnaire cam�ra, sans lui, il n'aurait pas d'�couteur lors du changement de cam�ra
    }

    private void OnEnable()
    {
        peripheriqueEntree.PersonnageAuSol.Enable();    //Active les Inputs du personnage au sol, c'est � dire Marche, courir, sauter, etc.
    }
    public void OnDisable()
    {
        peripheriqueEntree.PersonnageAuSol.Disable();   //d�sactive les Inputs du personnage au sol, c'est � dire Marche, courir, sauter, etc.
    }

    private void LireCourrir(InputAction.CallbackContext context)
    {
        courrirActif = context.ReadValueAsButton();     //Cet unity Envent se fera appel� dans le script Deplacement personnage cam�ra, sans lui, il n'aurait pas d'�couteur. Sa valeur bol�enne d�terminera si le bouton courrir est appuy� (true) ou pas (false)
    }

    private void LireClic(InputAction.CallbackContext context)
    {
        cliquer.Invoke();   //Cet unity Envent se fera appel� dans le script Gestionnaire de click, sans lui, il n'aurait pas d'�couteur lors du click 
    }

    private void LireMouvementRegard(InputAction.CallbackContext context)
    {
        regard = Vector2.ClampMagnitude( context.ReadValue<Vector2>(), 1 );     //Transfert les donn�es de la position souris en x et y

        mouvementRegardHorizontal = regard.x;   //Cette propri�t� va contenir la valeur horizontal (x) de la souris
        mouvementRegardVertical = regard.y;  //Cette propri�t� va contenir la valeur horizontal (y) de la souris
    }

    public void LireSaut(InputAction.CallbackContext context)
    {
        sauter.Invoke();    //Cet unity Envent se fera appel� dans le script deplacement personnage, sans lui, il n'aurait pas d'�couteur lors du changement de cam�ra
    }

    private void LireMouvementDeplacement(InputAction.CallbackContext context)
    {
        deplacement = context.ReadValue<Vector2>(); //Transfert les donn�es des boutons de navigations en x et y

        mouvementDeplacementHorizontal = deplacement.x;    //Cette propri�t� va contenir la valeur horizontal (x) des boutons de navigations (gauche et droite)
        mouvementDeplacementVertical = deplacement.y;   //Cette propri�t� va contenir la valeur vertical (y) des boutons de navigations (haut et bas)
    }

}

