using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class eyeballcount : MonoBehaviour
{
    public TextMeshProUGUI Ecount;
    public int eyeballc = 0;
    public bool cantalk;
    private GameObject col;
    public int apple = 0;
    public GameObject ending;
    void Update()
    {
        Ecount.text = "Eyeballs talked to:" + eyeballc.ToString();

        if (cantalk)
        {
            if (Input.GetKeyDown(KeyCode.Space) && col != null)
            {
                if (col.CompareTag("eyeball"))
                {
                    eyeballc += 1;
                    col.tag = "Untagged";
                }
            }
        }

        if (apple == 3)
        {
            transform.position = ending.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        cantalk = true;
        col = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        cantalk = false;
        col = null;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Apple"))
        {
            if (eyeballc == 3)
            {
                col.gameObject.SetActive(false);
                apple += 1;
            }
        }
    }
}
