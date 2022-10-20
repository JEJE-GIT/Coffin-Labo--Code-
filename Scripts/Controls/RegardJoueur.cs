using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegardJoueur : MonoBehaviour
{
    [SerializeField]
    private GestionnairePeripherique gestionnairePeripherique; //J'ai besoin du gestionnaire de périphérique pour accéder au donnés horizontal et vertical de la souri
    [SerializeField]
    private Transform personnage;   //J'ai besoin de la position du personnage pour le faire trourne en même temps que la caméra

    private float xRotation = 0f;

    // Update is called once per frame
    void Update()
    {
        PlacerRegard();
    }

    private void PlacerRegard()
    {
        float mouseX = gestionnairePeripherique.mouvementRegardHorizontal;     
        float mouseY = gestionnairePeripherique.mouvementRegardVertical;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 50f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        //Vector3.up  c'est egal a new Vector3(0,1,0)
        personnage.Rotate(Vector3.up * mouseX);

    }

}
