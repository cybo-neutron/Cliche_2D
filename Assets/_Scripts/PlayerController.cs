using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class PlayerController : DestructibleObject
{
    Rigidbody2D rb;

    [Header("Movement")]
    [SerializeField]
    float speed;

    bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InitialiseJumpProperties();
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        //Handle flip
        if (horizontalInput > 0 && !facingRight) Flip();
        if (horizontalInput < 0 && facingRight) Flip();

        rb.velocity =
            new Vector2(horizontalInput * speed * Time.deltaTime,
                rb.velocity.y);
    }

    void Update()
    {
        //TODO : use GetAxisRaw("Jump) for variable jump height
        HandleJump();
    }




#region Jump
    [Header("Jump")]
    [SerializeField] float jumpHeight = 5f;
    [SerializeField] float jumpVelocity = 0f;
    [SerializeField] float timeToReachApex = 2f;
    float _gravity = 0f;
    [SerializeField] bool _onGround = false;
    public Transform[] groundDetectionPoints;
    public LayerMask groundLayer;
    [SerializeField] float _groundDetectionRayLength = 0.2f;

    //Coyote 
    float _lastTimeOnGround = 0f;
    [SerializeField] float coyoteTime = 0.1f;



    void InitialiseJumpProperties(){
        CalculateJumpVelocity();
        rb.gravityScale = _gravity;
    }
    void HandleJump(){

        checkGrounded();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //TODO : check if it can jump
            if(Input.GetKeyDown(KeyCode.Space) && canJump()){
                Jump();
            }
        }
    }

    void CalculateJumpVelocity()
    {
        _gravity = (2 * jumpHeight) / (timeToReachApex * timeToReachApex);
        jumpVelocity = (float)System.Math.Sqrt(2 * _gravity*jumpHeight);
    }

    void Jump(){
        rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
    }

    bool canJump(){

        //Coyote jump
        if(!_onGround && Time.time < _lastTimeOnGround + coyoteTime)
            return true;

        if(_onGround)
            return true;
        return false;
    }

    void checkGrounded(){
        
        // Debug the rays to check ground status
        foreach (var point in groundDetectionPoints)
        {
            Debug.DrawRay(groundDetectionPoints[0].position,-Vector2.up*_groundDetectionRayLength,Color.white);
        }

        //Raycast to check ground
        _onGround = groundDetectionPoints.Any(point=>Physics2D.Raycast(point.position, -Vector2.up,_groundDetectionRayLength,groundLayer));


        if (_onGround)
            _lastTimeOnGround = Time.time;
    }


#endregion


    void Flip()
    {
        facingRight = !facingRight;

        float rotationY = facingRight ? 0f : 180f;
        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
    }

    #region Death
    public static event Action DeathEvent;

    public override void Die()
    {
        DeathEvent?.Invoke();
        base.Die();
    }


    #endregion
}
