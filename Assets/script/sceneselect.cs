using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneselect : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1")) SceneManager.LoadScene("lv1", LoadSceneMode.Single);
        if (Input.GetKeyDown("2")) SceneManager.LoadScene("lv2", LoadSceneMode.Single);
        if (Input.GetKeyDown("3")) SceneManager.LoadScene("Eyeball", LoadSceneMode.Single);
    }
}
