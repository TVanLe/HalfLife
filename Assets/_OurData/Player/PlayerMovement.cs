using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rbPlayer;
    [SerializeField] private Animator animator;
    
    [Header("Run")]
    [SerializeField] private float speedRun;

    [Header("Jump")]
    [SerializeField] private float jumpForce;
    
    [Header("Double Jump")] 
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool doubleJump;

    [Header("Wall Slide")] 
    [SerializeField] private float countTouchWallToSlide;
    [SerializeField] private bool isWallSliding;
    [SerializeField] private float wallSlidingSpeed = 2f;
    [SerializeField] private Transform walCheck;
    [SerializeField] private float nextFaceDirection;
    
    [Header("Wall Jump")]
    [SerializeField] private float wallJumpingTime = 0.2f;
    [SerializeField] private float wallJumpingCounter;
    private void Update()
    {
        Jumping();
        WallSlide();
        WallJump();

        if (IsOnGround())
        {
            countTouchWallToSlide = 0;
        }
    }

    private void FixedUpdate()
    {
        Moving();
    }


    protected virtual void Moving()
    {
        float x = InputManger.Instance.horizontal;
        animator.SetFloat("Speed" , Mathf.Abs(x));
        rbPlayer.velocity = new Vector2(x * speedRun, rbPlayer.velocity.y);
    }

    protected virtual void Jumping()
    {
        if (InputManger.Instance.jump)
        {
            if (IsOnGround())
            {
                animator.SetTrigger("IsJumping");
                rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, jumpForce);
                doubleJump = true;
            }
            else if(doubleJump)
            {
                animator.SetTrigger("IsJumping");
                rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, jumpForce);
                doubleJump = false;
            }
        }
        
    }

    protected virtual bool IsOnGround()
    {
        return Physics2D.OverlapBox(groundCheck.position, new Vector2(0.5f, 0.2f), 0, groundLayer);
    }

    protected virtual bool IsWalled()
    {
        return Physics2D.OverlapCircle(walCheck.position, 0.2f, groundLayer);
    }

    protected virtual void WallSlide()
    {
        bool canSlide = false;
        if (countTouchWallToSlide == 0) canSlide = true;
        else
        {
            if (transform.parent.localScale.x != nextFaceDirection)
            {
                canSlide = false;
            }
            else
            {
                canSlide = true;
            }
        }
        
        if (canSlide && IsWalled() && !IsOnGround() && InputManger.Instance.horizontal != 0)
        {
            isWallSliding = true;
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x,
                Mathf.Clamp(rbPlayer.velocity.y, -wallSlidingSpeed, float.MaxValue));
            
            animator.SetBool("IsWallSlide" ,true);
        }
        else
        {
            isWallSliding = false;
            
            animator.SetBool("IsWallSlide" ,false);
        }
    }
    
    protected virtual void WallJump()
    {
        if (isWallSliding)
        {
            wallJumpingCounter = wallJumpingTime;
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if (InputManger.Instance.jump && wallJumpingCounter > 0f)
        {
            countTouchWallToSlide++;
            nextFaceDirection = -transform.parent.localScale.x; 
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x , jumpForce);
            wallJumpingCounter = 0f;
        }
    }

    
}
