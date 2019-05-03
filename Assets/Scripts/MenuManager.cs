using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public Animator transAnim;

    public Animator MainM;
    public Animator MainS;


    public GameObject audioOnIcon;
    public GameObject audioOffIcon;

    public int highScore;
    public Text bestScoreText;
   // public TextMeshProUGUI bestScoreText1;
    float hueValue;

    public Image ballImage;

    public int soundState;
    public SpriteRenderer CircleColor;
    public float circleColor;

    public GameObject startGamePanel;
    public GameObject idlePanel;

    public GameObject MainMenuPanel;
     public GameObject CircleBall;

   // public Dropdown dropdown;
    


    TrailRenderer tr;
    // Start is called before the first frame update
    void Start()
    {
        SetSoundState();
        CircleColor = GameObject.Find("Circle").GetComponent<SpriteRenderer>();
        FindObjectOfType<AudioManager>().Play("ThemeSong");
        //FindObjectOfType<AudioManager>().VolumeUp("ThemeSong");
        //dropdown = GetComponent<Dropdown>();
        SetScore();
        
    }

    // Update is called once per frame
    void Update()
    {
        SetBallColor();
        SetScoreColor();
        TapToStart();
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

    void SetScore()
    {
        highScore = PlayerPrefs.GetInt("BestScore", highScore);
        bestScoreText.text = highScore.ToString();
       // bestScoreText1.text = highScore.ToString();
    }

    void SetScoreColor()
    {
        bestScoreText.color = Color.HSVToRGB(circleColor, 0.5f, 0.8f, true);
    }

    void SetBallColor()
    {
              
        circleColor = PlayerPrefs.GetFloat("CircleColor");
        CircleColor.color = Color.HSVToRGB(circleColor, 0.5f, 0.8f, true);
    }

    void TapToStart()
    {
          if (Input.GetMouseButton(0) && !IsPointerOverUIObject() )
        {
            // MainMenuPanel.SetActive(false);
           
            StartCoroutine(StartBtn());
            // startGamePanel.SetActive(true);
           // idlePanel.SetActive(true);
        }
    }

    public void BackStart()
    {   
        // startGamePanel.SetActive(false);
        // MainMenuPanel.SetActive(true);
        
        StartCoroutine(BackBtn());
    }

IEnumerator LoadScene()
    {
        transAnim.SetTrigger("end");
        startGamePanel.SetActive(false);
       // idlePanel.SetActive(false);
        yield return new WaitForSeconds(1.5f);
    //    FindObjectOfType<AudioManager>().Stop("ThemeSong");
        SceneManager.LoadScene(1);
        //StartPanel.SetActive(false);
       // startPanel.SetActive(false);
    }

IEnumerator StartBtn()
    {
       // CircleBall.SetActive(false);
        yield return new WaitForSeconds(0f);
        MainM.SetTrigger("StartTrigger");
        MainS.SetTrigger("StartTrigger");       
       
    }
IEnumerator BackBtn()
    {
        MainM.SetTrigger("BackTrigger");
        MainS.SetTrigger("BackTrigger");       
        yield return new WaitForSeconds(0f);
       // CircleBall.SetActive(true);
    }

    public void LoadSceneBtn()
    {
        StartCoroutine(LoadScene());
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
