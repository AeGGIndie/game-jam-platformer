using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject welcome;
    public Collider2D col;

    public void MsgDisplay()
    {
        welcome.gameObject.SetActive(true);
    }

    public void MsgDel()
    {
        welcome.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(welcome.gameObject.activeInHierarchy == true && col.gameObject.tag != "Player")
        {
            Invoke("MsgDel", 2);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("I got triggered");
            Invoke("MsgDisplay", 0.5f);
        }
    }
}
