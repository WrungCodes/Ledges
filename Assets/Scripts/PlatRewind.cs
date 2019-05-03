using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlatRewind : MonoBehaviour
{
    GameManager gameManager;

    public bool isRewinding = false;

    List<Vector2> positions;

    Rigidbody2D rb;

    public Button RewindButton;

    // Use this for initialization
    void Start()
    {
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

    }

    void FixedUpdate()
    {
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
        if(positions.Count > Mathf.Round(5f/ Time.fixedDeltaTime))
        {
            positions.RemoveAt(positions.Count - 1);
        }
        positions.Insert(0, transform.position);
    }

    public void StartRewind()
    {
        rb.isKinematic = true;
        isRewinding = true;
    }

    public void StopRewind()
    {
        StartCoroutine("StartDelay");
        isRewinding = false;
      
    }

    IEnumerator StartDelay()
    {
       float pauseTime = Time.realtimeSinceStartup + 3f;
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;
    }
    IEnumerator ButtonDelay()
    {
       
        yield return new WaitForSecondsRealtime(.3f);
        
        StartRewind();
       

    }



}
