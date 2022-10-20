using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementPersonnage : MonoBehaviour
{
    [SerializeField] private GestionnairePeripherique gestionnairePeripherique; //Pour accéder au script "gestionnairePeripherique", il faut créer une propriéter qui est visible dans l'inspecteur. On peut implémenter le script gestionnairePeripherique directement dans l'inspecteur.
    [SerializeField] private CharacterController characterController;   //Pour manipuler le personnage, nous avons besoin du "CharacterController" du personnage et l'implémenter dans ce script, mais il est vide pour l'instant...
    [SerializeField] private ChangementScene changementScene;   

    [SerializeField] private Camera mainCamera;     //J'ai besoin de la main caméra car le personnage doit se déplacer selon la position de la caméra

    [SerializeField] private GestionnaireCamera gestionnaireCamera; //Pour accéder au script "gestionnaireCamera", il faut créer une propriéter qui est visible dans l'inspecteur. On peut implémenter le script gestionnairePeripherique directement dans l'inspecteur.

    [SerializeField] private Animator animationPersonnage;  //Pour accéder à l'animator "animationPersonnage", il faut créer une propriéter qui est visible dans l'inspecteur. On peut implémenter le script gestionnairePeripherique directement dans l'inspecteur. 

    [SerializeField] private float vitesseMarche = 10f; //Cette propriété représente la vitesse normale du personnage
    [SerializeField] private float vitesseCourse = 20f; //Cette propriété représente la vitesse en course du personnage
    [SerializeField] private float hauteurSaut = 6f;    //Cette propriété représente la hauteur maximale du personnage

    [SerializeField] private float gravite = -9.81f;    //Cette propriété représente la vitesse du personnage en tombant
    [SerializeField] private Transform verifToucheSol;  //// Pour vérifier si le personnage touche au sol, nous avons besoin du Gameobjet empty "verifToucheSol" et l'implémenter dans ce script. Vue que la propriété est de type transform, il va prendre seulement les donnés de sa position, rotation et scale. Cette propriété est vide pour l'instant. Nous avons besoin de la position du gameobjet "verifToucheSol" pour vérifier si sa position est proche du sol
    [SerializeField] private float distanceDuSol = 0.1f;    //Cette propriété représente la distance entre le personnage et le sol
    [SerializeField]private LayerMask layerSol;  //Cette propriété va garder en mémoire le layerMask "Sol"

    private bool toucheSol; //Cette propriété de type boléenne va déterminer si le personnage touche au sol
    private Vector3 vitesseVertical;    //Cette propriété représente la position du personnage en x,y,z. Ce qui m'intéresse c'est la position en z, c'est-à-dire la hauteur du personnage


    // Start is called before the first frame update
    void Start()
    {
        gestionnairePeripherique.sauter.AddListener(ProduireSaut);      //Ajoute un écouteur sur la méthode ProduireSaut pour faire Sauter le personnage (Voir la ligne 126)
    }

    // Update is called once per frame
    void Update()
    {
        //Vérification si le personnage touche le sol avec un GameObject qui est au pied du personnage.
        toucheSol = Physics.CheckSphere(verifToucheSol.position, distanceDuSol, layerSol);

        //Comme le personnage tombe toujours,
        //la vitesse de descente verticale diminue toujours (pour tomber).
        //Si la vitesse verticale descend au-dessous de zéros,
        //nous réinitialisons la vitesse verticale à 0.
        if (toucheSol && vitesseVertical.y < 0)
        {
            vitesseVertical.y = 0;
        }

        Deplacement();  //Appele la méthode Deplacement pour faire déplacer le personnage
        AppliqueGravite();  //Appele la méthode AppliqueGravite pour que le personnage tombe quand il est dans les airs
    }

    private void Deplacement()
    {
        float x = gestionnairePeripherique.mouvementDeplacementHorizontal; //Cette variable représente les valeurs des touche de deplacement horizontal
        float y = gestionnairePeripherique.mouvementDeplacementVertical;    //Cette variable représente les valeurs des touche de deplacement horizontal

        float vitesseDeplacement = vitesseMarche;    //Cette variable représente la valeur de vitesseMarche

        if (gestionnairePeripherique.courrirActif)  //Si le joueur se déplace en appuyant sur le bouton pour courrir...
        {
            animationPersonnage.SetBool("Cours", true); //Joue l'animation de course du personnage
            animationPersonnage.speed = 1.5f;   //La vitesse de l'animation est 50% plus rapide
            vitesseDeplacement = vitesseCourse; //Cette variable représente la valeur de vitesseCourse

        }

        else   //Sinon...
        {
            animationPersonnage.SetBool("Cours", false);    //Ne joue pas l'animation de course du personnage    
            animationPersonnage.speed = 1f; //La vitesse la l'animation du personnage reviens à la normale
        }


        Vector3 move = mainCamera.transform.right * x + mainCamera.transform.forward * y;   //Le personnage va se déplacer par raport à la caméra
        move.y = 0; //Le personnage ne sautera plus tout seul

        characterController.Move(move * vitesseDeplacement * Time.deltaTime);   //Déplace le caracter controller du personnage selon sa vitesse et selon la caméra


        if (gestionnaireCamera.cameraFPSActive) //Si la caméra fps est active...
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, mainCamera.transform.eulerAngles.y, transform.eulerAngles.z); //Utilise euler comme rotation du personnage selon la caméra
        }

        else
        {
            if (move.magnitude >= 0.1f) { //si le personnage commence a bouger
                float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg;    //Calcul de la rotation
                Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 6 * Time.deltaTime);
            }   //Utilise Quaternion comme rotation du personnage selon la caméra
        }

        if (move != Vector3.zero) { //Si le personnage se déplace...

            animationPersonnage.SetBool("Deplacement", true);   //Active l'animation de déplacement du personnage

        }

        else
        {
            animationPersonnage.SetBool("Deplacement", false);  //désactive l'animation de déplacement du personnage
        }

    }

    // Le personnage va continuellement tomber.
    // Il va s'arrêter sur les GameObject qui ont un collider.
    private void AppliqueGravite()
    {
        vitesseVertical.y += gravite * Time.deltaTime * 2;

        characterController.Move(vitesseVertical * Time.deltaTime);
    }

    //Le saut est produit en lui donnant une vitesse verticale plus grande
    //que la gravité qui est appliquée pour tomber.
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
