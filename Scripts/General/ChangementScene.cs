using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangementScene : MonoBehaviour
{


    public void Acceuil()
    {
        SceneManager.LoadScene("Acceuil");  //Charge la scene d'acceuil
    }

    public void ChangementSceneNiveau1()
    {
        SceneManager.LoadScene("TP-1_Integration3D 1");  //Charge la scene Niveau1
    }

    public void FinNiveau1()
    {
        SceneManager.LoadScene("FinNiveau1");  //Charge la scene fin niveau1
    }

    public void ChangementSceneNiveau2()
    {
        SceneManager.LoadScene("TP-2_Integration3D");  //Charge la scene Niveau2
    }

     public void FinNiveau2()
     {
        Invoke("ChargeSceneFinNiveau2", 3); //Après 3 secondes, appelle la méthode ChargeSceneFinNiveau2 
    }


    private void ChargeSceneFinNiveau2()
    {
         SceneManager.LoadScene("FinNiveau2");  //Charge la scene Niveau2
    }

    public void DelayAcceuil()
    {
        Invoke("Acceuil", 3);
    }



}
