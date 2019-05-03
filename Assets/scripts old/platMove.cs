using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platMove : MonoBehaviour {

    public float moveSpeed;
    Rigidbody2D rb;
    Vector2 movement;
    GameManager gameManager;

    public bool directon;
    

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        

       // directon = Random.Range(0, 1);
	}
	
	// Update is called once per frame
	void Update () {

        //Time.timeScale = 1.2f;

        if (gameManager.isGameOver == true)
        {
            rb.bodyType = RigidbodyType2D.Static;
        }

        if(gameManager.isReverse == false)
        {
         //   rb.bodyType = RigidbodyType2D.Kinematic;
        }
        else
        {
          //  rb.bodyType = RigidbodyType2D.Kinematic;
        }

        //directon = Random.Range(0, 1);
        if ( transform.position.y >= 8f)
        {
            //  Audio.Stop();
            //Audio.PlayOneShot(GameOverSound, 0.7f);

        }
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
        if (other.gameObject.tag == "topbar")
        {

            Debug.Log("GameOver");

            rb.bodyType = RigidbodyType2D.Static;

            gameManager.GameOver();

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
