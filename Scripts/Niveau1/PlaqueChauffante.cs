using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaqueChauffante : MonoBehaviour
{
    private Collider colliderPlaque;

    [SerializeField] private GameObject gameManager;     //Pour accéder au script "gamemanager", il faut créer une propriété qui est visible dans l'inspecteur. On va prendre le gameobjet "gameManager", mais on a pas encore accès au script
    private GameManager scriptManager;      //Grâce a cette propriété, on aura accès au script du gamemanager, mais il est vide pour l'instant

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
