using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementPersonnage : MonoBehaviour
{
    [SerializeField] private GestionnairePeripherique gestionnairePeripherique; //Pour acc�der au script "gestionnairePeripherique", il faut cr�er une propri�ter qui est visible dans l'inspecteur. On peut impl�menter le script gestionnairePeripherique directement dans l'inspecteur.
    [SerializeField] private CharacterController characterController;   //Pour manipuler le personnage, nous avons besoin du "CharacterController" du personnage et l'impl�menter dans ce script, mais il est vide pour l'instant...
    [SerializeField] private ChangementScene changementScene;   

    [SerializeField] private Camera mainCamera;     //J'ai besoin de la main cam�ra car le personnage doit se d�placer selon la position de la cam�ra

    [SerializeField] private GestionnaireCamera gestionnaireCamera; //Pour acc�der au script "gestionnaireCamera", il faut cr�er une propri�ter qui est visible dans l'inspecteur. On peut impl�menter le script gestionnairePeripherique directement dans l'inspecteur.

    [SerializeField] private Animator animationPersonnage;  //Pour acc�der � l'animator "animationPersonnage", il faut cr�er une propri�ter qui est visible dans l'inspecteur. On peut impl�menter le script gestionnairePeripherique directement dans l'inspecteur. 

    [SerializeField] private float vitesseMarche = 10f; //Cette propri�t� repr�sente la vitesse normale du personnage
    [SerializeField] private float vitesseCourse = 20f; //Cette propri�t� repr�sente la vitesse en course du personnage
    [SerializeField] private float hauteurSaut = 6f;    //Cette propri�t� repr�sente la hauteur maximale du personnage

    [SerializeField] private float gravite = -9.81f;    //Cette propri�t� repr�sente la vitesse du personnage en tombant
    [SerializeField] private Transform verifToucheSol;  //// Pour v�rifier si le personnage touche au sol, nous avons besoin du Gameobjet empty "verifToucheSol" et l'impl�menter dans ce script. Vue que la propri�t� est de type transform, il va prendre seulement les donn�s de sa position, rotation et scale. Cette propri�t� est vide pour l'instant. Nous avons besoin de la position du gameobjet "verifToucheSol" pour v�rifier si sa position est proche du sol
    [SerializeField] private float distanceDuSol = 0.1f;    //Cette propri�t� repr�sente la distance entre le personnage et le sol
    [SerializeField]private LayerMask layerSol;  //Cette propri�t� va garder en m�moire le layerMask "Sol"

    private bool toucheSol; //Cette propri�t� de type bol�enne va d�terminer si le personnage touche au sol
    private Vector3 vitesseVertical;    //Cette propri�t� repr�sente la position du personnage en x,y,z. Ce qui m'int�resse c'est la position en z, c'est-�-dire la hauteur du personnage


    // Start is called before the first frame update
    void Start()
    {
        gestionnairePeripherique.sauter.AddListener(ProduireSaut);      //Ajoute un �couteur sur la m�thode ProduireSaut pour faire Sauter le personnage (Voir la ligne 126)
    }

    // Update is called once per frame
    void Update()
    {
        //V�rification si le personnage touche le sol avec un GameObject qui est au pied du personnage.
        toucheSol = Physics.CheckSphere(verifToucheSol.position, distanceDuSol, layerSol);

        //Comme le personnage tombe toujours,
        //la vitesse de descente verticale diminue toujours (pour tomber).
        //Si la vitesse verticale descend au-dessous de z�ros,
        //nous r�initialisons la vitesse verticale � 0.
        if (toucheSol && vitesseVertical.y < 0)
        {
            vitesseVertical.y = 0;
        }

        Deplacement();  //Appele la m�thode Deplacement pour faire d�placer le personnage
        AppliqueGravite();  //Appele la m�thode AppliqueGravite pour que le personnage tombe quand il est dans les airs
    }

    private void Deplacement()
    {
        float x = gestionnairePeripherique.mouvementDeplacementHorizontal; //Cette variable repr�sente les valeurs des touche de deplacement horizontal
        float y = gestionnairePeripherique.mouvementDeplacementVertical;    //Cette variable repr�sente les valeurs des touche de deplacement horizontal

        float vitesseDeplacement = vitesseMarche;    //Cette variable repr�sente la valeur de vitesseMarche

        if (gestionnairePeripherique.courrirActif)  //Si le joueur se d�place en appuyant sur le bouton pour courrir...
        {
            animationPersonnage.SetBool("Cours", true); //Joue l'animation de course du personnage
            animationPersonnage.speed = 1.5f;   //La vitesse de l'animation est 50% plus rapide
            vitesseDeplacement = vitesseCourse; //Cette variable repr�sente la valeur de vitesseCourse

        }

        else   //Sinon...
        {
            animationPersonnage.SetBool("Cours", false);    //Ne joue pas l'animation de course du personnage    
            animationPersonnage.speed = 1f; //La vitesse la l'animation du personnage reviens � la normale
        }


        Vector3 move = mainCamera.transform.right * x + mainCamera.transform.forward * y;   //Le personnage va se d�placer par raport � la cam�ra
        move.y = 0; //Le personnage ne sautera plus tout seul

        characterController.Move(move * vitesseDeplacement * Time.deltaTime);   //D�place le caracter controller du personnage selon sa vitesse et selon la cam�ra


        if (gestionnaireCamera.cameraFPSActive) //Si la cam�ra fps est active...
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, mainCamera.transform.eulerAngles.y, transform.eulerAngles.z); //Utilise euler comme rotation du personnage selon la cam�ra
        }

        else
        {
            if (move.magnitude >= 0.1f) { //si le personnage commence a bouger
                float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg;    //Calcul de la rotation
                Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 6 * Time.deltaTime);
            }   //Utilise Quaternion comme rotation du personnage selon la cam�ra
        }

        if (move != Vector3.zero) { //Si le personnage se d�place...

            animationPersonnage.SetBool("Deplacement", true);   //Active l'animation de d�placement du personnage

        }

        else
        {
            animationPersonnage.SetBool("Deplacement", false);  //d�sactive l'animation de d�placement du personnage
        }

    }

    // Le personnage va continuellement tomber.
    // Il va s'arr�ter sur les GameObject qui ont un collider.
    private void AppliqueGravite()
    {
        vitesseVertical.y += gravite * Time.deltaTime * 2;

        characterController.Move(vitesseVertical * Time.deltaTime);
    }

    //Le saut est produit en lui donnant une vitesse verticale plus grande
    //que la gravit� qui est appliqu�e pour tomber.
    private void ProduireSaut()
    {
        if (toucheSol)
        {
            vitesseVertical.y = Mathf.Sqrt(hauteurSaut * -3.0f * gravite);
            animationPersonnage.SetTrigger("Saut");
            animationPersonnage.speed = 1f;
        }
    }


    public void Meurt()
    {
        animationPersonnage.SetBool("Meurt", true);
        gestionnairePeripherique.OnDisable();
        gestionnaireCamera.CameraMeurt();
        changementScene.DelayAcceuil();
        
    }

}
