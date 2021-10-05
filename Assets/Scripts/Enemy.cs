using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // For Enemy AI
    public float speed;
    public Rigidbody2D rb;
    public Vector2 direction;
    // Player damage
    public Player grabScript;
    public int playerDamage;
    // AI Damage;
    public int enemyHealth = 5;

    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            grabScript.health -= playerDamage;
        }
    }

    // AI Damage
    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
        if(enemyHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
