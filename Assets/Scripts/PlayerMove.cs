using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float runSpeed = 2;

    public float jumpSpeed = 3;
    //velocidad para el doble salto
    public float doubleJumpSpeed = 2.5f;
    //variable buleana para saber cuando hacer el doble salto
    private bool canDoubleJump;


    Rigidbody2D rb2D;

    public bool betterJump = false;

    public float fallMultiplier = 0.5f;

    public float lowJumpMultiplier = 1f;
    public SpriteRenderer spriteRenderer;

    public Animator animator;

    public int PosicionX;
    public int PosicionY;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        if (Input.GetKey("z"))
        {
            if (CheckGround.isGrounded)
            {
                canDoubleJump = true;
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
                animator.SetBool("Run", false);
            }
            else
            {//si presionamos "z" una segúnda ves, "cuando estamos en el aire"
                if (Input.GetKeyDown("z"))
                {//si canDoubleJump es = true
                    if (canDoubleJump)
                    {
                        // asigno true a la variable DoubleJump para activar la transición de la animación 
                        animator.SetBool("DoubleJump", true);
                        rb2D.velocity = new Vector2(rb2D.velocity.x, doubleJumpSpeed);
                        // paso canDoubleJump a false, ya se iso el doble salto
                        canDoubleJump = false;
                    }
                }
            }
           
        }


        //animación de salto
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
            // animator.SetBool("Run", false);
        }

        if(rb2D.velocity.y<0)
        {
            animator.SetBool("Falling", true);
        }
        else if (rb2D.velocity.y > 0)
        {
            animator.SetBool("Falling", false);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Run", false);
        }
       
        //**********************
        //codigo de salto más realista.
        //controlar con el video para ver que quede aplicado
        //ver video 8 o anteriores
        if (betterJump)
        {
            if(rb2D.velocity.y<0)
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }

            if(rb2D.velocity.y>0 && !Input.GetKey("z"))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }
        //********************************************

        if (rb2D.velocity.y<0)
        {
            rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
        }

        if (rb2D.velocity.y > 0 && !Input.GetKey("z"))
        {
            rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
        }
    }

    public void Posicionar()
    {
        //Vector3 Vec (2.736f, -0.011f,0.0f);

        // rb2D.position( 2.736f, -0.011f); //            (2.736, - 0.011);
        gameObject.GetComponent<Transform>().position = new Vector3(2.736f, -0.011f, 0.0f);
    }
}
