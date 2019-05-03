using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class player : MonoBehaviour {

    public Collider2D objectCollider;
    public Collider2D platformCollider;



    float pressTime, startTime, endTime;
    public bool isGrounded;

    public bool bpressed = false;

    public float dashSpeed;
    public float dashTime;
    public float startDashTime;

    public bool isDashing;

    public float timeToNext;
      
    Rigidbody2D rb;

    TrailRenderer tr;

    public GameObject dashEffect;

    public GameObject deadEffect;

    public Transform timeImageBar;

    float hueValue;

    int score;

    GameManager gameManager;

    public GameObject CoverPanel;


    public Slider slider;
    public Image backgroundslider;
    public Image fillslider;


   public float pressTimeSlider = 0; 
   // public Transform SliderBarImage;

   public bool startSlide = false;

   public SpriteRenderer CircleColor;
   public float circleColor;

//public AudioClip JumpSound;

 //  public AudioClip LandSound;

 //  public AudioClip ReleaseSound;

 //  private AudioSource Audio;



	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();


        objectCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        platformCollider = GameObject.FindGameObjectWithTag("Ground").GetComponent<Collider2D>();


       // Audio = GetComponent<AudioSource>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        CircleColor = GetComponent<SpriteRenderer>();

        circleColor = PlayerPrefs.GetFloat("CircleColor", circleColor);

        CircleColor.color = Color.HSVToRGB(circleColor, 0.5f, 0.8f, true);

        tr.startColor = Color.HSVToRGB(circleColor, 0.5f, 0.8f, true);

        fillslider.color = Color.HSVToRGB(circleColor, 0.8f, 0.9f, true);

        backgroundslider.color = Color.HSVToRGB(circleColor, 0.2f, 0.8f, true);
		
        dashTime = startDashTime;

        timeToNext = 13;

        hueValue = Random.Range(0, 10) / 10f;
       // SetBackgroundColor();   

	}

    private void UY()
    {
        if (objectCollider.IsTouching(platformCollider))
        {

            Debug.Log("stop");
            //StopRewind();
        }
    }

	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0) && isGrounded == true && isDashing == false && !IsPointerOverUIObject() && !EventSystem.current.IsPointerOverGameObject())
        {
            //Audio.PlayOneShot(ReleaseSound, 0.7f);
            // pressTimeSlider += Time.deltaTime;
            // pressTimeSlider++;
            startSlide = true;
            //StartCoroutine(SliderMove());

            //pressTimeSlider = Time.deltaTime; 

            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            startTime = Time.time;
            bpressed = true;
        }

        if (Input.GetMouseButtonUp(0) && bpressed == true && isGrounded == true && isDashing == false && isGrounded == true && !IsPointerOverUIObject() && !EventSystem.current.IsPointerOverGameObject())
        {
            // Audio.PlayOneShot(JumpSound, 0.7f);
            FindObjectOfType<AudioManager>().Play("Jump");
            startSlide = false;
            isDashing = true;
            bpressed = false;

            if (isDashing == true)
            // {
            //     GameObject dashEffectObj = Instantiate(dashEffect, transform.position, Quaternion.identity);
            //     Destroy(dashEffectObj, 2);
            //}
            endTime = Time.time;

            // to calculate the preesed time
            CalTimePressed();

            //rb.AddForce(Vector2.up * 600 * pressTime );
            //rb.AddForce(Vector2.right * 50);
            //rb.velocity = Vector2.up * 4* pressTime;
            // rb.velocity = Vector2.right * dashSpeed * pressTime;
            rb.velocity = new Vector2(dashSpeed * (pressTime / 2.1f), 20 * (pressTime / 2.1f));

            //print(pressTime);
            // this is to shake the camera when taking off
//            StartCoroutine(Camera.main.gameObject.GetComponent<CameraShake>().Shake());
        }
        else
        {
            if (dashTime <= 0)
            {
                isDashing = false;
                dashTime = startDashTime;
                //rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;
            }
        }      
          
        if (gameManager.isReverse == false)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

        if (gameManager.isReverse == true)
        {
            timeToNext = 13f;
            timeToNext -= Time.deltaTime;
        }

        if (isGrounded == false)
        {
         
        }

        slider.value = pressTimeSlider;

        if (startSlide == true)
        {
            pressTimeSlider += Time.deltaTime/1.2f;
        }
        else
        {
            pressTimeSlider = 0;
        }
              
       // timeImageBar.GetComponent<Image>().fillAmount = timeToNext / 13;

        if (gameManager.isCounting == true)
        {
            // this is to reduce the time to next
           // timeToNext -= Time.deltaTime;
        }

       
        //to check if time is up
       //  if (timeToNext <= 0)
       //  {
            // Audio.PlayOneShot(GameOverSound, 0.7f);
             //Destroy(this.gameObject);
             // Dead();
         //    rb.bodyType = RigidbodyType2D.Static;
         //    timeToNext = 0;
             //Debug.Log("GameOver");

         //    gameManager.SetTimeUp();
         //    gameManager.GameOver();
             
            
       //  }

       //  if (timeToNext >= 13)
        // {
        //     timeToNext = 13;
        // }
        //to check if time is up
     


       // StopWhenGrounded();
      
       

	}

    void CalTimePressed()
    {
        //to check for the maximum press time

        if(isGrounded == true)
        {
            pressTime = endTime - startTime;
            
            if (pressTime > 1.2f)
        {
            pressTime = 1.2f;
            //Debug.Log(pressTime);
        }
        else if (pressTime < 0f)
	    {
            pressTime = 0f;
	    }
        else
        {
            pressTime = endTime - startTime;
        }

        }

       
        
    }


    // void PlayRandSound()
    // {
    //     int voiceSound = Random.Range(10, 1);

    //     switch (voiceSound)
    //     {
    //         case 1:
    //             FindObjectOfType<AudioManager>().Play("Comeon");
    //             break;
    //         case 2:
    //             FindObjectOfType<AudioManager>().Play("YouGot");
    //             break;
    //         case 3:
    //             FindObjectOfType<AudioManager>().Play("Bagit");
    //             break;
    //         case 4:
    //             FindObjectOfType<AudioManager>().Play("Nicework");
    //             break;
    //         case 5:
    //            // FindObjectOfType<AudioManager>().Play("Awesome");
    //             break;
    //         case 6:
    //            // FindObjectOfType<AudioManager>().Play("Awesome");
    //             break;
    //         case 7:
    //            // FindObjectOfType<AudioManager>().Play("Awesome");
    //             break;
    //         case 8:
    //            // FindObjectOfType<AudioManager>().Play("Awesome");
    //             break;
    //         case 9:
    //            // FindObjectOfType<AudioManager>().Play("Awesome");
    //             break;
    //         case 10:
    //            // FindObjectOfType<AudioManager>().Play("Awesome");
    //             break;
    //     }
    // }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            //Audio.PlayOneShot(LandSound, 0.7f);
            FindObjectOfType<AudioManager>().Play("Bounce");
            
           // FindObjectOfType<AudioManager>().Play("Awesome");
            
            isGrounded = true;

            //rb.constraints = RigidbodyConstraints2D.FreezePositionX;

            tr.time = 0;
            // this is to shake the camera when landing
//            StartCoroutine(Camera.main.gameObject.GetComponent<CameraShake>().Shake());
        }
        if (other.collider.tag == "Buttombar")
        {
            Debug.Log("GameOver");
            // Dead();
            gameManager.GameOver();

            if(gameManager.isReverse == true){
                rb.bodyType = RigidbodyType2D.Kinematic;
            }
            else
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
            }
        }       
    }


   
    //this is for trigger collision with the groungTag...
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "GroundTag")
        {
           // Debug.Log("score");

            gameManager.AddScore();

            // PlayRandSound();

            Destroy(other.gameObject);

            timeToNext += 2.0f;

            SetBackgroundColor();
         }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = true;
            //rb.constraints = RigidbodyConstraints2D.FreezePositionX;               
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = false;

            rb.constraints = RigidbodyConstraints2D.FreezeRotation;

            tr.time = 0.5f;            
        }
    }

   
    //set Background colour
    void SetBackgroundColor()
    {
      //  Camera.main.backgroundColor = Color.HSVToRGB(hueValue, 0.5f, 0.8f, true);     
        hueValue += 0.1f;

        if (hueValue >= 1)
        {
            hueValue = 0;
        }
    }
    //destroy the object and the effect
  
    void Dead()
    {
        Destroy(this.gameObject);
        Destroy(Instantiate(deadEffect, transform.position, Quaternion.identity), 2.5f);
    }


    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        return results.Count > 0;
    }
    

}
