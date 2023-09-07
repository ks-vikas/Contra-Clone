using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim; 
    private SpriteRenderer sr;
    private BoxCollider2D bc;

    [SerializeField] private LayerMask Ground;      //"Terrain" Layer is used to detect Ground which is passed as serial input

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
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Xval = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(Xval * speed, rb.velocity.y);
        
        if (Input.GetButtonDown("Jump") && Grounded() )
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


    //Grounded() is used to detect that the player is grounded or not
    private bool Grounded()
    {
         // BoxCast create a box around the box collider of the player
         // arguments:-
         // origin of boxcast = origin of player's box collider
         // size of boxcast = size of player's box collider
         // rotation of box = 0 (NO rotation)
         // Vector2.down & 0.1f: shifting boxcast little bit below to the player boxcollider, so that it can overlap to the ground and detect it, also it wil not detect it when player collide the ground from sides.

        return Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0, Vector2.down, 0.1f, Ground);
    }
}
