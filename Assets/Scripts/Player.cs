using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Player health
    public int health;

    // Horizontal Movement
    public float speed;
    private Rigidbody2D rb;
    public Vector2 Hdirection;
    public float inputH;
    private bool isFacingRight = false;
    // Vertical Movement
    public float jumpPower;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    // Death/Respawn
    public GameObject thePlayer;
  

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Horizontal Movement
        inputH = Input.GetAxisRaw("Horizontal");
            Hdirection = new Vector2(inputH * speed * Time.deltaTime, rb.velocity.y);
            rb.velocity = Hdirection;
        // Vertical Movement
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        // Jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpPower;
        }
        // Flip
            // If the player is not facing right, but the input is greater than 0, flip
        if (inputH > 0 && isFacingRight == false)
        {
            FlipRight();
            Debug.Log("I am pressing right");
        }
            // If the player is facing right, but input is less than 0, flip
        else if (inputH < 0 && isFacingRight == true)
        {
            FlipLeft();
            Debug.Log("I am pressing left");
        }
        
        
        
    }
    void Update()
    {
        // Death
        if(health <= 0)
        {
            Die();
        }

    } 
    void Die()
    {
        Destroy(thePlayer);
    }

    void FlipLeft()
    {
        isFacingRight = !true;
        transform.Rotate(0f, 180f, 0f);
    }
    void FlipRight()
    {
        isFacingRight = !false;
        transform.Rotate(0f, 180f, 0f);
    }
}
