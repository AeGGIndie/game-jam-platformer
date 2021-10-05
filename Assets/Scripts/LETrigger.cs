using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LETrigger : MonoBehaviour
{
    public Enemy grabEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            grabEnemy.direction = new Vector2(grabEnemy.speed, 0);
            grabEnemy.rb.velocity = grabEnemy.direction;
            Debug.Log("work n o u");
        }


    }
}
