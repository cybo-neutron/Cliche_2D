using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;

    [Header("Jump")]
    [SerializeField] float jumpVelocity;
    [SerializeField] float jumpHeight;
    [SerializeField] float fallingGravity = 1f;
    [SerializeField] float normalGravity = 1f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = normalGravity;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetAxisRaw("Jump") > 0)
        {
            Jump();
        }
        rb.velocity = new Vector2(horizontalInput * speed * Time.deltaTime, rb.velocity.y);
    }

    void Jump()
    {

    }

}
