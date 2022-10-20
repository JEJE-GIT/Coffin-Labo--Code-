using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNiv2 : MonoBehaviour
{

    [SerializeField] private DeplacementPersonnage deplacementPersonnage; //Pour accéder au script "deplacementPersonnage", il faut créer une propriéter qui est visible dans l'inspecteur. On peut implémenter le script gestionnairePeripherique directement dans l'inspecteur.

    [SerializeField] private Transform positionJoueur;
    private float f_RotSpeed = 3.0f, f_moveSpeed = 5f;

    private Collider colliderEnemyNiv2;


    // Start is called before the first frame update
    void Start()
    {
        colliderEnemyNiv2 = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {


        //L'enemy se tourne vers le joueur
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(positionJoueur.position - transform.position), f_RotSpeed * Time.deltaTime);

        //L'enemy se déplace vers le joueur
        transform.position += transform.forward * f_moveSpeed * Time.deltaTime;

    }

    //Quand l'enemy touche au joueur...

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {        //Si il y a une collision avec le player...
            deplacementPersonnage.Meurt();
        }

    }

}
