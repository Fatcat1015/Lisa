using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickScore : MonoBehaviour
{

    public TextMeshProUGUI scoretext;
    public int score = 0;


    void FixedUpdate()
    {
        if (scoretext != null) scoretext.text = "Score:" + score.ToString();

    }

    public void LeftClick()
    {
        score += 1;
    }
    public void RightClick()
    {
        score -= 1;
    }
    
}
