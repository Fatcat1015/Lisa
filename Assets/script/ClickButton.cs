using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    //bool isClicked;

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();


    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void SelectButton(int x)
    {

        if (x == 0)
        {
            spriteRenderer.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        }

    }
}