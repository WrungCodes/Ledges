using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayGameStart : MonoBehaviour {

    public GameObject CountDown;
    public GameObject pausebutton;
    public GameObject scorebar;

    public Animator countDownAnim;

	// Use this for initialization
	void Start () {
        
        
      //  timebar.gameObject.SetActive(false);
        scorebar.gameObject.SetActive(false);
        pausebutton.gameObject.SetActive(false);

        StartCoroutine("DelayFromBegin");

	}
	
	// Update is called once per frame
	void Update () {

     
	}

    IEnumerator StartDelay()
    {
        
        FindObjectOfType<AudioManager>().Stop("Theme");
        Time.timeScale = 0;
       
        float pauseTime = Time.realtimeSinceStartup + 0.01f;

        

        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;
       // CountDown.gameObject.SetActive(false);
       // timebar.gameObject.SetActive(true);
        scorebar.gameObject.SetActive(true);
        pausebutton.gameObject.SetActive(true);
        Time.timeScale = 1.1f;
        FindObjectOfType<AudioManager>().VolumeDown("Theme");
        FindObjectOfType<AudioManager>().Play("Theme");
    }

    IEnumerator DelaySounds()
    {

        yield return new WaitForSecondsRealtime(0.3f);
        FindObjectOfType<AudioManager>().Play("Countdown");
        yield return new WaitForSecondsRealtime(1f);
        FindObjectOfType<AudioManager>().Play("Countdown");
        yield return new WaitForSecondsRealtime(1f);
        FindObjectOfType<AudioManager>().Play("Countdown");
        yield return new WaitForSecondsRealtime(1f);
        FindObjectOfType<AudioManager>().Play("Countdown");
    }

    IEnumerator DelayFromBegin()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1.5f);
       // countDownAnim.SetTrigger("playCountDown");
        StartCoroutine("StartDelay");
       // StartCoroutine("DelaySounds");
        FindObjectOfType<AudioManager>().Stop("Theme");
    }
}
