using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour {

   // public bool isRewinable = false;

    public GameObject RewindButton;

    public GameObject WatchAdsButton;
    //public GameObject adButton;


    public int GameOverCount = 0;
    public GameObject GameOverPanelObj;
    public GameObject time;
    public GameObject score;
    public GameObject sliderPan;
    public GameObject pauseButton;
    public GameObject timeupimage;
    public Text scoreText;
    public Text bestScoreText;
    public Text ScoreText1;
    public GameObject TimeUpPanel;
    public Text TimeUpText;
    public GameObject Circle;

    public bool isGameOver;
    public bool isCounting;
    public bool isReverse;

    public bool playrewind;

    public TextMeshProUGUI hint;

    public string[] words;

    public Animator transAnim;
   
    int currentScore;
    public int highScore;
    public float circleColor;

    public Text pausescoreText;
    public Text pausebestScoreText;

    public SpriteRenderer CircleColor;

    public GameObject pressHoldJumpObj;

    public GameObject CoverPanel;

    public int addedScore;

    // For showing ads
    public int gameover_count;
    public bool play_video_ad;
    public bool play_rewardedvideo_ad;
    public bool play_banner_ad;
	// Use this for initialization

    #if UNITY_IOS
    [SerializeField]public const string store_ID = "3115179";
#elif UNITY_ANDROID
    [SerializeField]public const string store_ID = "3115179";
#elif UNITY_EDITOR
    [SerializeField]public const string store_ID = "3115179";
#endif

    //  private string store_ID = "3115179";
	void Start () {

        Advertisement.Initialize (store_ID, false);
        StartCoroutine (ShowBannerWhenReady ());

        FindObjectOfType<AudioManager>().Play("ThemeSong");
        Time.timeScale = 1.1f;
        isGameOver = false;
        isCounting = true;
        isReverse = false;
        currentScore = 0;

        CircleColor = GameObject.Find("Circle").GetComponent<SpriteRenderer>();

        highScore = PlayerPrefs.GetInt("BestScore", highScore);
       
        
        circleColor = PlayerPrefs.GetFloat("CircleColor", circleColor);

       // CircleColor = GetComponent<SpriteRenderer>();

        CircleColor.color = Color.HSVToRGB(circleColor, 0.5f, 0.8f, true);

        SetScore();
        
       // SetHint();

        
        StartCoroutine("PressHoldJumpInfo");
        RewindButton.SetActive(false);
        gameover_count = PlayerPrefs.GetInt("Gameover_count", gameover_count);
        play_video_ad = false;
        play_rewardedvideo_ad = false;
        play_banner_ad = true; 
	}
    
    IEnumerator ShowBannerWhenReady () {
        while (!Advertisement.IsReady ("BannerAd")) {
            yield return new WaitForSeconds (0.5f);
        }
        Advertisement.Banner.Show ("BannerAd");
    }
	
	// Update is called once per frame
	void Update () {

        if (PlayerPrefs.GetInt("Gameover_count", gameover_count) >= 15)
        {
            play_video_ad = true;
            PlayerPrefs.SetInt("Gameover_count", 0);
        }

        pausebestScoreText.text = highScore.ToString();

        if (GameOverCount > 1)
        {
           RewindButton.SetActive(false);
           WatchAdsButton.SetActive(false);
        }

        if (currentScore > highScore)
        {
            
            highScore = currentScore;
            PlayerPrefs.SetInt("BestScore", highScore);
            bestScoreText.text = highScore.ToString();
        }
        if(isGameOver == true)
        {
            // GameOverCount = GameOverCount + 1;

           // Time.timeScale = 0;
           // FindObjectOfType<AudioManager>().Play("Gameoversound");
        }
	}

   // public void Rewind()
   // {
   //     isGameOver = false;

   //     GameOn();

   // } 
   
    public void GameOver()
    {
        isGameOver = true;
        //StartCoroutine(GameOverCo());
        gameover_count++;
        GameOff();
        GameOverCount = GameOverCount + 1;
    }

    public void GameOff()
    {
       
        PlayerPrefs.SetInt("Gameover_count", gameover_count);

        isCounting = false;
        FindObjectOfType<AudioManager>().Stop("ThemeSong");
        FindObjectOfType<AudioManager>().Play("GameOver");
        FindObjectOfType<AudioManager>().Play("BlahBlah");
        // TimeUpPanel.SetActive(false);
        // TimeUpText.text = null;
        // timeupimage.SetActive(false);
        pressHoldJumpObj.SetActive(false);

        bestScoreText.text = highScore.ToString();
        ScoreText1.text = currentScore.ToString();
        //SetHint();
        // hint.text = words[Random.Range(0, words.Length)];

        GameOverPanelObj.SetActive(true);

       // time.SetActive(false);
        score.SetActive(false);
        sliderPan.SetActive(false);
        pauseButton.SetActive(false);

        //CoverPanel.SetActive(false);
    }

    public void GameOn()
    {
        // TimeUpPanel.SetActive(true);
        // TimeUpText.text = null;
        // timeupimage.SetActive(false);

       // GameOverPanelObj.SetActive(false);

       // time.SetActive(true);
        score.SetActive(true);
        sliderPan.SetActive(true);
        pauseButton.SetActive(true);
        // TimeUpPanel.SetActive(false);
       // CoverPanel.SetActive(false);
    }

    IEnumerator GameOverCo()
    {
        yield return new WaitForSeconds(0.5f);

        
        TimeUpPanel.SetActive(false);
        TimeUpText.text = null;
        timeupimage.SetActive(false);

        bestScoreText.text = highScore.ToString();
        ScoreText1.text = currentScore.ToString();
       // SetHint();
        hint.text = words[Random.Range(0, words.Length)];

        Debug.Log("GameOver");
        FindObjectOfType<AudioManager>().VolumeDown("ThemeSong");
        GameOverPanelObj.SetActive(true);
       
       // time.SetActive(false);
        score.SetActive(false);
        sliderPan.SetActive(false);
        pauseButton.SetActive(false);


       
        yield break;

    }

    IEnumerator GameOverCo1()
    {
        yield return new WaitForSeconds(0.7f);
        
        TimeUpPanel.SetActive(false);

        bestScoreText.text = highScore.ToString();
        ScoreText1.text = currentScore.ToString();
       // SetHint();
        hint.text = words[Random.Range(0, words.Length)];

        Debug.Log("GameOver");
        FindObjectOfType<AudioManager>().VolumeDown("ThemeSong");

        GameOverPanelObj.SetActive(true);
       // time.SetActive(false);
        score.SetActive(false);

        yield break;

    }


    public void SetTimeUp()
    {
        TimeUpPanel.SetActive(true);

      //  StartCoroutine(GameOverCo1());

    }

    public void Restart()
    {
        StartCoroutine("ButtonDelay");
    }

    

    public void AddScore()
    {
        if (circleColor == 1.2f)
        {
            Debug.Log("3");
            //addedScore = 3;
            currentScore++;
            currentScore++;
            //currentScore++;
        }
        else
        {
            // Debug.Log("1");
            //addedScore = 1;
            // currentScore += addedScore;
            currentScore++;
        } 

        SetScore();
    }

    void SetScore()
    {

        
        scoreText.text = currentScore.ToString();
       // pausescoreText.text = currentScore.ToString();
    }

    // void SetHint()
    // {
        
        

    //     words[0] = "Hint: You can skip over a platform but you wasting time";
    //     words[1] = "Hint: Only touching the platform can give you point and additional time";
    //     words[2] = "Hint: Press hold and release the screen to project ball";
    //     words[3] = "Hint: You can go higher if you hold and release immediately after a jump it's simple physics";
    //     words[4] = "Hint: Never forget your mistakes";
    //     words[5] = "Hint: This is not your everyday gravity......maybe we in mars";
    //     words[6] = "Hint: don't anticipate that perfect curve";
    //     words[7] = "Hint: Failure is for mortals";
    //     words[8] = "Hint: Try Try Try Harder";
    //     words[9] = "Hint: Get the perfect timing";
    //     words[10] = "Hint:Don't worry You can never score a Zero";

        

    // }

    public void LoadSceneByIndex(int SceneIndex)
    {
        //FindObjectOfType<AudioManager>().VolumeUp("Theme");
        FindObjectOfType<AudioManager>().Play("ThemeSong");
        SceneManager.LoadScene(SceneIndex);
    }

    public void LoadHomeScene()
    {
        Advertisement.Banner.Hide();
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSecondsRealtime(.3f);
        transAnim.SetTrigger("end");
        Time.timeScale = 1f;
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 1f;
       // FindObjectOfType<AudioManager>().Stop2("Theme");
        SceneManager.LoadScene(1);
       // FindObjectOfType<AudioManager>().VolumeUp("ThemeSong");
        FindObjectOfType<AudioManager>().Play("ThemeSong");
    }

    public void ButtonSound()
    {
       // FindObjectOfType<AudioManager>().Play("Click");
    }

    IEnumerator PressHoldJumpInfo()
    {
        pressHoldJumpObj.SetActive(true);
        yield return new WaitForSeconds(7f);
        pressHoldJumpObj.SetActive(false);
    }

    IEnumerator ButtonDelay()
    {
        yield return new WaitForSecondsRealtime(.3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Debug.Log("Restart");
        FindObjectOfType<AudioManager>().Play("ThemeSong");
       
    }

}
