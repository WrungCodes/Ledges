using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform targetPosition;

    public float smoothSpeed = 0.125f;

    public Vector3 offset;

	// Use this for initialization 
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (targetPosition != null)
        {
            Vector3 desiredPosition = new Vector3(targetPosition.position.x + offset.x, transform.position.y, targetPosition.position.z + offset.z);

            // Vector3 desiredPosition = targetPosition.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.position = smoothedPosition;
        }
        else
        {
            transform.position = this.transform.position;
        }

      

        

	}
}
