using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pausebutton;

    public GameObject PausePanel;

    public GameObject CountDown;

    public Transform countDownTrans;

    public Vector3 positin;

    public Image PanelRay;

    public GameObject CoverPanel;
    public GameObject audioOnIcon;
    public GameObject audioOffIcon;
	// Use this for initialization
	void Start () {
        Camera camera = Camera.main;

        positin = camera.ScreenToWorldPoint(new Vector3(Screen.width / 4, Screen.height / 4));
	}

    void OnApplicationPause(bool _bool)
    {
        if (_bool)
        {
           // Pause();
        }
    }

	
	// Update is called once per frame
	void Update () {
		
        SetSoundState();

	}

   public void Resume()
    {

        StartCoroutine("ButtonDelay");
       // Time.timeScale = 1.1f;
       
    }

   public void Pause()
    {
        FindObjectOfType<AudioManager>().Stop("ThemeSong");
        PausePanel.SetActive(true);
        //CoverPanel.SetActive(false);
        Time.timeScale = 0f;

    }

   public void Exit()
   {
      // FindObjectOfType<AudioManager>().VolumeUp("ThemeSong");
     //  FindObjectOfType<AudioManager>().Play("ThemeSong");
       SceneManager.LoadScene(0);
       Time.timeScale = 1f;
       FindObjectOfType<AudioManager>().Play("ThemeSong");
       Advertisement.Banner.Hide();
   }

   IEnumerator StartDelay()
   {
      // PausePanel.SetActive(false);
       PanelRay.raycastTarget = true;
       pausebutton.gameObject.SetActive(false);
       //CountDown.gameObject.SetActive(true);
       //GameObject clone = (GameObject)Instantiate(CountDown, countDownTrans);
       Time.timeScale = 0;
      // float pauseTime = Time.realtimeSinceStartup + 3f;
      // while (Time.realtimeSinceStartup < pauseTime)
           yield return 0;
      //GameObject.DestroyImmediate(clone);
     // CountDown.gameObject.SetActive(false);
       // timebar.gameObject.SetActive(true);
      // scorebar.gameObject.SetActive(true);
       pausebutton.gameObject.SetActive(true);
       Time.timeScale = 1.1f;
       PanelRay.raycastTarget = false;
       //FindObjectOfType<AudioManager>().VolumeDown("ThemeSong");
       FindObjectOfType<AudioManager>().Play("ThemeSong");

   }
   IEnumerator DelaySounds()
   {
    //    FindObjectOfType<AudioManager>().Play("Countdown");
       yield return new WaitForSecondsRealtime(1f);
    //    FindObjectOfType<AudioManager>().Play("Countdown");
       yield return new WaitForSecondsRealtime(1f);
    //    FindObjectOfType<AudioManager>().Play("Countdown");
       yield return new WaitForSecondsRealtime(1f);
   }

   IEnumerator ButtonDelay()
   {
       yield return new WaitForSecondsRealtime(0f);
       PausePanel.SetActive(false);
       StartCoroutine("StartDelay");
    //    StartCoroutine("DelaySounds");
   }
    private void SetSoundState()
    {
        if (PlayerPrefs.GetInt ("Muted", 0) == 0)
        {
     
            AudioListener.volume = 1;
            audioOnIcon.SetActive (true);
            audioOffIcon.SetActive (false);
        }
                else
        {
     
            AudioListener.volume = 0;
            audioOnIcon.SetActive (false);
            audioOffIcon.SetActive (true);            
        }
    }

}
