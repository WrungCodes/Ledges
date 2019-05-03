using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerRewinding : MonoBehaviour
{
    public Collider2D objectCollider;
    public Collider2D platformCollider;

    GameManager gameManager;

    public bool isRewinding = false;

    List<Vector2> positions;

    Rigidbody2D rb;

    public Button RewindButton;

    public GameObject pausebutton;

    public GameObject CountDown;

    public Transform countDownTrans;

    public GameObject tapInfo;

    public GameObject GameOverPanelObj;

    // Use this for initialization
    void Start()
    {
        objectCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        platformCollider = GameObject.FindGameObjectWithTag("Ground").GetComponent<Collider2D>();
        

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        positions = new List<Vector2>();

        rb = GetComponent<Rigidbody2D>();

        RewindButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        StartCoroutine("ButtonDelay");
    }

    // Update is called once per frame
    void Update()
    {

        // Debug.Log(Time.timeScale = 1.06f);

    }

    void FixedUpdate()
    {
      //  if (isRewinding == true && objectCollider.IsTouching(platformCollider))
      //  {

        //    Debug.Log("stop");
        //    StopRewind();
       // }

       if (Input.GetMouseButtonDown(0) && isRewinding == true && !EventSystem.current.IsPointerOverGameObject())
       {
            StopRewind();
       }

        if (isRewinding == true)
        {
            Rewind();
        }
        else if (isRewinding == false && gameManager.isGameOver == false)
        {
            Record();
        }
    }

    void Rewind()
    {
        pausebutton.gameObject.SetActive(false);
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

    void Record()
    {
        positions.Insert(0, transform.position);
    }

    public void StartRewind()
    {

        gameManager.GameOverCount++;
        isRewinding = true;

        tapInfo.gameObject.SetActive(true);
        Time.timeScale = 0.9f;

        rb.isKinematic = true;
        gameManager.isReverse = true;
        gameManager.isGameOver = false;

        gameManager.GameOn();
    }

    public void StopRewind()
    {
        tapInfo.gameObject.SetActive(false);
        StartCoroutine("StartDelay");
        StartCoroutine("DelaySounds");
        isRewinding = false;
        gameManager.isReverse = false;
        //Time.timeScale = 1.06f;
    }

    IEnumerator StartDelay()
    {
        // PausePanel.SetActive(false);
        //pausebutton.gameObject.SetActive(false);
        //CountDown.gameObject.SetActive(true);
        GameObject clone = (GameObject)Instantiate(CountDown, countDownTrans);
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 3f;
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;
        GameObject.DestroyImmediate(clone);
        // CountDown.gameObject.SetActive(false);
        // timebar.gameObject.SetActive(true);
        // scorebar.gameObject.SetActive(true);
        pausebutton.gameObject.SetActive(true);
        Time.timeScale = 1.1f;
        FindObjectOfType<AudioManager>().VolumeDown("Theme");
        FindObjectOfType<AudioManager>().Play("Theme");
    }

    IEnumerator DelaySounds()
    {
        FindObjectOfType<AudioManager>().Play("Countdown");
        yield return new WaitForSecondsRealtime(1f);
        FindObjectOfType<AudioManager>().Play("Countdown");
        yield return new WaitForSecondsRealtime(1f);
        FindObjectOfType<AudioManager>().Play("Countdown");
        yield return new WaitForSecondsRealtime(1f);
    }

    IEnumerator ButtonDelay()
    {
        RewindButton.interactable = false;
        yield return new WaitForSecondsRealtime(.3f);
        GameOverPanelObj.SetActive(false);
        StartRewind();
        RewindButton.interactable = true;

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Ground" )
        {
            if (isRewinding == true)
            {
                Debug.Log("yesss");
                StopRewind();
            }
            //Audio.PlayOneShot(LandSound, 0.7f);

           // gameManager.playrewind = true;

           // 


        }
    }


}
