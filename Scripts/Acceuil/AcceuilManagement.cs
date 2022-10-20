using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AcceuilManagement : MonoBehaviour
{

    public string nomScene;

    // Start is called before the first frame update
    void Start()
    {
        nomScene = SceneManager.GetActiveScene().name;

        if (nomScene == "Acceuil")
        {
            Cursor.lockState = CursorLockMode.None;       
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
