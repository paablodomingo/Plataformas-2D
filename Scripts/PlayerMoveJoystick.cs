using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class PlayerMoveJoystick : MonoBehaviour 
{
    private float horizontalMove = 0f;
    private float verticalMove = 0f;
    public Joystick joystick;


    public float runSpeed = 1.25f;
    public float runSpeedHorizontal = 2;


    public float jumpSpeed = 4;

    public float doubleJumpSpeed = 2.5f;
    private bool canDoubleJump;

    Rigidbody2D rb2D;

    public SpriteRenderer SpriteRenderer;

    public Animator animator;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        //Para moverse derecha
        if (horizontalMove > 0)
        {
            //Cuando pulso d o right el personaje no se gira
            SpriteRenderer.flipX = false;
            //Animacion de correr cuando pulsamos
            animator.SetBool("Run", true);
        }

        //Para moverse derecha
        else if (horizontalMove < 0)
        {
            //Para que cuando pulse la izquierda se gire el personaje
            SpriteRenderer.flipX = true;
            //Animacion de correr cuando pulsamos
            animator.SetBool("Run", true);
        }

        //Cuando estoy quieto no se mueve
        else
        {
            //Cuando no pulso tecla no hace la animación de correr
            animator.SetBool("Run", false);
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
        horizontalMove = joystick.Horizontal * runSpeedHorizontal;
        transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime * runSpeed;

    }

    public void Jump()
    {
        if (CheckGround.isGrounded)
        {
            canDoubleJump = true;
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpSpeed);
        }
        else
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
