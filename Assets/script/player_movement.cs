using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D rb;
    public Animator pc_animator;
    public float moveSpeed = 1;
    public Dialogue_Manager Dialoguem;
    public bool cutscene = false;
    void Start()
    {
        Dialoguem = FindObjectOfType<Dialogue_Manager>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        //pc_animator = GetComponent<Animator>();

    }

    void Update()
    {
        if (Dialoguem == null || !Dialoguem.speaking)
        {
                movement.x = Input.GetAxisRaw("Horizontal");
                movement.y = Input.GetAxisRaw("Vertical");
        }


        //character moving animation
        /*if (movement.x != 0 || movement.y != 0)//if moving, play animation
        {
            //pc_animator.enabled = true;
            pc_animator.speed = 0.5f;
            pc_animator.SetBool("idle", false);


            if (movement.x == 0)
            {
                pc_animator.SetInteger("left", 0);
                if (movement.y <= 0)
                {
                    pc_animator.SetInteger("up", -1);
                }
                else
                {
                    pc_animator.SetInteger("up", 1);
                }
            }
            else if (movement.x <= 0)
            {
                pc_animator.SetInteger("left", 1);
                pc_animator.SetInteger("up", 0);
            }
            else
            {
                pc_animator.SetInteger("left", -1);
                pc_animator.SetInteger("up", 0);
            }
        }
        else
        {
            pc_animator.SetBool("idle", true);
            pc_animator.SetInteger("left", 0);
            pc_animator.SetInteger("up", 0);
            //pc_animator.enabled = false;
        }*/

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); //move player
    }
}
