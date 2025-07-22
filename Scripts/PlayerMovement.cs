using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpSpeed = 2;
    public float doubleJumpSpeed = 1.5f;
    private bool canDoubleJump;

    Rigidbody2D rb2D;

    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;

    public SpriteRenderer SpriteRenderer;

    public Animator animator;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        //Solo te deja saltar si estás en el suelo
        if (Input.GetKey("space"))
        {
            if (CheckGround.isGrounded)
            {
                canDoubleJump = true;
                rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpSpeed);
            }
            else
            {
                if (Input.GetKeyDown("space"))
                {
                    if (canDoubleJump)
                    {
                        animator.SetBool("DoubleJump", true);
                        rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, doubleJumpSpeed);
                        canDoubleJump = false;
                    }
                }
            }
            
        }

        if (CheckGround.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }

        if (CheckGround.isGrounded == true)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("DoubleJump", false);
            animator.SetBool("Falling", false);
        }

        if (rb2D.linearVelocity.y < 0)
        {
            animator.SetBool("Falling", true);
        }
        else if (rb2D.linearVelocity.y > 0)
        {
            animator.SetBool("Falling", false);
        }


    }




    void FixedUpdate()
    {
        //Para moverse derecha
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.linearVelocity = new Vector2(runSpeed, rb2D.linearVelocity.y);
            //Cuando pulso d o right el personaje no se gira
            SpriteRenderer.flipX = false;
            //Animacion de correr cuando pulsamos
            animator.SetBool("Run", true);
        }
        
        //Para moverse derecha
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.linearVelocity = new Vector2(-runSpeed, rb2D.linearVelocity.y);
            //Para que cuando pulse la izquierda se gire el personaje
            SpriteRenderer.flipX = true;
            //Animacion de correr cuando pulsamos
            animator.SetBool("Run", true);
        }
        
        //Cuando estoy quieto no se mueve
        else
        {
            rb2D.linearVelocity = new Vector2(0, rb2D.linearVelocity.y);
            //Cuando no pulso tecla no hace la animación de correr
            animator.SetBool("Run", false);
        }


        if (betterJump)
        {
            if (rb2D.linearVelocity.y < 0) 
            {
                rb2D.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }

            if (rb2D.linearVelocity.y > 0 && !Input.GetKey("space"))
            {
                rb2D.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }


    }

}
