using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class GestionnaireCamera : MonoBehaviour
{

    [SerializeField] private GestionnairePeripherique gestionnairePeripherique;     //J'ai besoin du gestionnairePeripherique pour écouter le bouton d'action pour changer de caméras


    [SerializeField] private CinemachineVirtualCamera cameraFPS;    //J'ai besoin de la caméra 1e personne modifier sa priorité lors de l'action du chamgement de caméra
    [SerializeField] private CinemachineFreeLook cameraTPS;     //J'ai besoin de la caméra 3e personne modifier sa priorité lors de l'action du chamgement de caméra

    public bool cameraFPSActive = false;        //Par défaut, la caméra fps n'est pas actif

    // Start is called before the first frame update
    void Start()
    {

        gestionnairePeripherique.changementCamera.AddListener(ProduireChangementCamera);    //Ajoute un écouteur à la méthode ProduireChangementCamera pour que le bouton pour changer de camera se fasse entendre 

    }

    private void ProduireChangementCamera()
    {
        cameraFPSActive = !cameraFPSActive;     //Le résultat de cameraFPSActive sera l'inverse de celui-ci, c'est à dire que si on appelle la fonction ProduireChangementCamera, le résultat sera contraire a chaque fois qu'on l'appele
        ChangementCamera();     //Appelle la méthode ChangementCamera
    }

    private void ChangementCamera()
    {

        if (cameraFPSActive)    //Si cameraFPSActive est true...
        {
            cameraFPS.Priority = 1;   //Met la priorité sur la caméra fps
        }

        else   //sinon...
        {
            cameraFPS.Priority = 0;     //Ce n'est plus la caméra fps qui a la priorité
        }

    }

    public void CameraMeurt()
    {
        cameraFPS.Priority = 0;     //Ce n'est plus la caméra fps qui a la priorité
    }
}
