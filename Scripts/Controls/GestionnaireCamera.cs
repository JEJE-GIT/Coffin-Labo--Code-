using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class GestionnaireCamera : MonoBehaviour
{

    [SerializeField] private GestionnairePeripherique gestionnairePeripherique;     //J'ai besoin du gestionnairePeripherique pour �couter le bouton d'action pour changer de cam�ras


    [SerializeField] private CinemachineVirtualCamera cameraFPS;    //J'ai besoin de la cam�ra 1e personne modifier sa priorit� lors de l'action du chamgement de cam�ra
    [SerializeField] private CinemachineFreeLook cameraTPS;     //J'ai besoin de la cam�ra 3e personne modifier sa priorit� lors de l'action du chamgement de cam�ra

    public bool cameraFPSActive = false;        //Par d�faut, la cam�ra fps n'est pas actif

    // Start is called before the first frame update
    void Start()
    {

        gestionnairePeripherique.changementCamera.AddListener(ProduireChangementCamera);    //Ajoute un �couteur � la m�thode ProduireChangementCamera pour que le bouton pour changer de camera se fasse entendre 

    }

    private void ProduireChangementCamera()
    {
        cameraFPSActive = !cameraFPSActive;     //Le r�sultat de cameraFPSActive sera l'inverse de celui-ci, c'est � dire que si on appelle la fonction ProduireChangementCamera, le r�sultat sera contraire a chaque fois qu'on l'appele
        ChangementCamera();     //Appelle la m�thode ChangementCamera
    }

    private void ChangementCamera()
    {

        if (cameraFPSActive)    //Si cameraFPSActive est true...
        {
            cameraFPS.Priority = 1;   //Met la priorit� sur la cam�ra fps
        }

        else   //sinon...
        {
            cameraFPS.Priority = 0;     //Ce n'est plus la cam�ra fps qui a la priorit�
        }

    }

    public void CameraMeurt()
    {
        cameraFPS.Priority = 0;     //Ce n'est plus la cam�ra fps qui a la priorit�
    }
}
