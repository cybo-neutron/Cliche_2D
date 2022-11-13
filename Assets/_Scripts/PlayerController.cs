using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : DestructibleObject
{
    Rigidbody2D rb;

    [Header("Movement")]
    [SerializeField] float speed;
    bool facingRight = true;

    [Header("Jump")]
    [SerializeField] float jumpVelocity;
    [SerializeField] float jumpHeight;
    [SerializeField] float fallingGravity = 1f;
    [SerializeField] float normalGravity = 1f;
    [SerializeField] int totalJumps = 1;
    [SerializeField] int jumpsLeft;

    [SerializeField] float variableJumpTime = 0.1f;
    float variableJumpTimer = 0f;
    bool isJumping;

    [SerializeField] Transform groundDetection;
    [SerializeField] float groundDetectionRadius;
    [SerializeField] LayerMask groundLayer;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = normalGravity;
        jumpsLeft = totalJumps;
    }

    void Update()
    {
        //TODO : use GetAxisRaw("Jump) for variable jump height
        if (Input.GetButtonDown("Jump"))
        {
            if (canJump())
                Jump();
        }
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        //Handle flip
        if (horizontalInput > 0 && !facingRight)
            Flip();
        if (horizontalInput < 0 && facingRight)
            Flip();

        rb.velocity = new Vector2(horizontalInput * speed * Time.deltaTime, rb.velocity.y);


    }

    void Jump()
    {
        if (!isJumping)
        {
            //TODO : Start coroutine jumpCoolDown for Variable Jump Height and maybe Coyote jump
            isJumping = true;

        }

        rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
        jumpsLeft--;
    }

    bool onGround()
    {
        //Check if on Ground
        // if on ground and !isJumping jumpsLeft = totalJumps
        if (Physics2D.OverlapCircle(groundDetection.position, groundDetectionRadius, groundLayer))
        {

            jumpsLeft = totalJumps;
            isJumping = false;
            return true;
        }

        return false;
    }

    bool canJump()
    {
        if (onGround() || jumpsLeft > 0)
            return true;

        return false;
    }

    void Flip()
    {
        facingRight = !facingRight;

        // Vector3 localScale = transform.localScale;
        // localScale.x *= -1;
        // transform.localScale = localScale;
        float rotationY = facingRight ? 0f : 180f;
        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
    }




}
