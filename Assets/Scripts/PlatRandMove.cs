using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatRandMove : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    Vector2 movement;
    public bool directon;
    public GameManager GameController;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       GameManager GameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>(); 
    }

    // Update is called once per frame
   void Update () {

	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            directon = (Random.value > 0.5f);
            if (directon == false)
            {
                movement = Vector2.up;
                moveSpeed = 3f;
            }
            else if(directon == true)
            {
                movement = Vector2.down;
                moveSpeed = 1f;
            }
            rb.velocity = movement * moveSpeed ;
        }

      
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Topbar")
        {
            rb.bodyType = RigidbodyType2D.Static;
            GameController.GameOver();
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            rb.velocity = Vector2.zero;
        }
    }
}
