using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Pri Insp Var
    [SerializeField]private float speed = 10.0f;
    [SerializeField]private float jumpForce = 500.0f;
    [SerializeField]private Transform groundCheckPos; //checkground Overlapcircle position 
    [SerializeField]private float groundCheckRadius; //check ground Overlap radius
    [SerializeField]private LayerMask WhatisGround; // Ground Layer Mask 

    //Pri Var
    private Rigidbody2D rBody;
    private Animator anim;
    private bool isGrounded  = false;
    private bool isFacingRight = true;
    private bool isDucking = false;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    //Physics 
    void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");

        //Check ground
        isGrounded = GroundCheck();

        //Jump code
        if(isGrounded && Input.GetAxis("Jump") > 0)
        {
            //JUMPING
            rBody.AddForce(new Vector2(0.0f, jumpForce));
        }

        //Debug Hor
        rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);


        //Check if sprite needs to be flipped
        if(isFacingRight && rBody.velocity.x < 0)
        {
            Flip();
        }
        else if(!isFacingRight && rBody.velocity.y > 0)
        {
            Flip();
        }

        //send value to anim
        anim.SetFloat("xSpeed", Mathf.Abs(rBody.velocity.x));
        anim.SetFloat("ySpeed", Mathf.Abs(rBody.velocity.y));
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isDucking", isDucking);
    }

    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheckPos.position, groundCheckRadius, WhatisGround);
    }

    private void Flip()
    {
        Vector3 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;

        isFacingRight = !isFacingRight;
    }
}

