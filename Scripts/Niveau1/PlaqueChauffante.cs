using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaqueChauffante : MonoBehaviour
{
    private Collider colliderPlaque;

    [SerializeField] private GameObject gameManager;     //Pour acc�der au script "gamemanager", il faut cr�er une propri�t� qui est visible dans l'inspecteur. On va prendre le gameobjet "gameManager", mais on a pas encore acc�s au script
    private GameManager scriptManager;      //Gr�ce a cette propri�t�, on aura acc�s au script du gamemanager, mais il est vide pour l'instant

    // Start is called before the first frame update
    void Start()
    {
        scriptManager = gameManager.GetComponent<GameManager>();       //Va chercher le script du gameobjet "GameManager" pour acceder a ses fonctions publiques
        colliderPlaque = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {

        if(scriptManager.etape3 == true)
        {

            if (other.transform.tag == "Player")
                {        //Si il y a une collision avec le player...
                    SceneManager.LoadScene("Acceuil");

                }

        }

        

    }
}
