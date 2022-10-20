using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeplacementEnemies : MonoBehaviour
{

    [SerializeField] private GameObject gameManager;     //Pour accéder au script "gamemanager", il faut créer une propriété qui est visible dans l'inspecteur. On va prendre le gameobjet "gameManager", mais on a pas encore accès au script
    private GameManager scriptManager;      //Grâce a cette propriété, on aura accès au script du gamemanager, mais il est vide pour l'instant

    public float vitesseDeplacement = 1f;

    private Vector3 pointDepartBleu;
    private Vector3 pointDepartRouge;
    private Vector3 pointDepartJaune;

    private Vector3 pointArriverBleu;
    private Vector3 pointArriverRouge;
    private Vector3 pointArriverJaune;




    // Start is called before the first frame update
    void Start()
    {
        scriptManager = gameManager.GetComponent<GameManager>();

        pointDepartBleu = new Vector3(24.5f, -18f, -35.8f);
        pointArriverBleu = new Vector3(-10.29f, -18f, -42.7f);

        pointDepartRouge = new Vector3(5.45f, -20f, 15.18f);
        pointArriverRouge = new Vector3(-27.05f, -20f, 31.5f);

        pointDepartJaune = new Vector3(6.98f, -18f, 18.03f);
        pointArriverJaune = new Vector3(3.87f, -18f, -21.89f);
    }

    // Update is called once per frame
    void Update()
    {
        if (scriptManager.etape1 == true)
        {
            DeplacerEnemies();
        }
    }



    public void DeplacerEnemies()
    {
        float temps = Mathf.PingPong(Time.time * vitesseDeplacement, 1);

        scriptManager.enemiBleu.transform.position = Vector3.Lerp(pointDepartBleu, pointArriverBleu, temps);
        scriptManager.enemiRouge.transform.position = Vector3.Lerp(pointDepartRouge, pointArriverRouge, temps);
        scriptManager.enemiJaune.transform.position = Vector3.Lerp(pointDepartJaune, pointArriverJaune, temps);


    }


}
