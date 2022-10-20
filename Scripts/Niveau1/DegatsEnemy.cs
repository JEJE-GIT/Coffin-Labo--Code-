using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DegatsEnemy : MonoBehaviour
{

    [SerializeField] private DeplacementPersonnage deplacementPersonnage; //Pour acc�der au script "deplacementPersonnage", il faut cr�er une propri�ter qui est visible dans l'inspecteur. On peut impl�menter le script gestionnairePeripherique directement dans l'inspecteur.


    private Collider colliderEnemy;

    // Start is called before the first frame update
    void Start()
    {
        colliderEnemy = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {        //Si il y a une collision avec le player...
            deplacementPersonnage.Meurt();
        }

    }

}
