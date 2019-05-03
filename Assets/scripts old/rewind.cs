using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rewind : MonoBehaviour {

    public bool isRewinding = false;

    List<Vector3> positions;

    Rigidbody2D rb;

	// Use this for initialization
    void Start()
    {

        positions = new List<Vector3>();

        rb = GetComponent<Rigidbody2D>();

    }

        
	
	// Update is called once per frame
	void Update () {

       // if (Input.GetKey(KeyCode.Return))
       // {
       //     StartRewind();
           
       // }

        

	}


    void FixedUpdate()
    {
        if (isRewinding)
        {
            
            Rewind();
        }
        else
        {
           // Debug.Log("rewind");
            Record();
        }
    }

    void Record()
    {
        if (rb.bodyType != RigidbodyType2D.Static)
        {
            positions.Insert(0, transform.position);
        }
        
        
    }

    void Rewind()
    {

        if (positions.Count > 0)
        {
            transform.position = positions[0];
            positions.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }  

            

        

    }

    public void StartRewind()
    {
        isRewinding = true;
       //rb.isKinematic = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
       rb.isKinematic = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            StopRewind();
        }

    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            StopRewind();
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            StopRewind();
        }
    }
}
