using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim; 
    private SpriteRenderer sr;


    private float jumpHeight = 30f;
    private float Xval;
    private float speed = 10f;
    private enum Playerstate { idle, run, jump };


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        Xval = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(Xval * speed, rb.velocity.y);
        
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }

        ChangeAnimations();

    }
    private void ChangeAnimations()
    {
        Playerstate state;

        if (Xval < -0.001f)
        {
            state = Playerstate.run;
            sr.flipX = true;
        }
        else if (Xval > 0.001f)
        {
            state = Playerstate.run;
            sr.flipX = false;
        }
        else
        {
            state = Playerstate.idle;
        }

        if(rb.velocity.y > 0.001f || rb.velocity.y < -0.001f)
        {
            state = Playerstate.jump;
        }

        anim.SetInteger("PlayerState", (int)state);
    }

}
