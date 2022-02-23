using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelscreen : MonoBehaviour
{

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("level select", LoadSceneMode.Single);
    }
}
