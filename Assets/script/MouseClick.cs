using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    Camera mainCamera;
    public GameObject score;

    // public bool isClicked;


    void Start()
    {
        // isClicked = false;
        mainCamera = Camera.main;
    }

    void Update()
    {

        Vector3 mousePos = Input.mousePosition;

        if (Input.GetKey(KeyCode.Mouse0)) //LEFT MOUSE BUTTON PRESSED
        {
            RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            if (hit)
            {
                if (hit.transform.gameObject.GetComponent<ClickButton>() != null)
                {
                    print("hit");
                    hit.transform.gameObject.GetComponent<ClickButton>().SelectButton(0);
                    FindObjectOfType<ClickScore>().LeftClick();
                }
            }
        }

        if (Input.GetKey(KeyCode.Mouse1)) //RIGHT MOUSE BUTTON PRESSED
        {
            RaycastHit2D hit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            if (hit)
            {
                if (hit.transform.gameObject.GetComponent<ClickButton>() != null)
                {
                    print("hit");
                    hit.transform.gameObject.GetComponent<ClickButton>().SelectButton(0);
                    FindObjectOfType<ClickScore>().RightClick();
                }
            }
        }
    }


}