using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_collision : MonoBehaviour
{

    public Lisa_d Dialogue;
    public Dialogue_Manager dm;

    private void Start()
    {
        dm = FindObjectOfType<Dialogue_Manager>();
    }



    private void OnTriggerStay2D(Collider2D col)
    {
            if (Input.GetButton("Dialogue"))
            {
                if (!dm.speaking)
                {
                    FindObjectOfType<player_movement>().cutscene = true;
                    dm.StartDialogue(Dialogue);
                    dm.speaking = true;
                }
        }
    }
}
