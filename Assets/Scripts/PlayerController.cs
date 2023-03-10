using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0, 10)]
    public float Speed = 10f;
    
    [Range(0, 10)]
    public float JumpForce = 10f;
    
    private Rigidbody2D rigidBody;
    private float horizontalMovement;
    private SpriteRenderer sr;
    private GroundChecker groundChecker;
    private Animator animator;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        groundChecker = GetComponent<GroundChecker>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        
        if (horizontalMovement < 0)
        {
            sr.flipX = true;
        }
        else if (0 < horizontalMovement)
        {
            sr.flipX = false;
        }

        if (Input.GetButtonDown("Jump") && groundChecker.IsGrounded)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, JumpForce);
        }
        
        animator.SetBool("isGrounded", groundChecker.IsGrounded);
        animator.SetBool("isMoving", horizontalMovement != 0);
        animator.SetBool("isFalling", rigidBody.velocity.y < 0);
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(horizontalMovement * Speed, rigidBody.velocity.y);
    }
}
