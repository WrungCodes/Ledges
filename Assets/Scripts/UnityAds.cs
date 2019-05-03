using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Advertisements;
using UnityEngine.Monetization;

public class UnityAds : MonoBehaviour
{
    // public static UnityAds instance;
#if UNITY_IOS
     [SerializeField]public const string store_ID = "3115179";
#elif UNITY_ANDROID
    [SerializeField]public const string store_ID = "3115179";
#elif UNITY_EDITOR
    [SerializeField]public const string store_ID = "3115179";
#endif
    private string Banner_ID = "BannerAd";
    private string Video_ID = "";
    GameManager gameManager;

    public GameObject RewindBtn;
    public GameObject AdsBtn;

    
    // Start is called before the first frame update
    void Start()
    {
        //AdsBtn.SetActive(false);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        // Advertisement.Initialize(store_ID, true);
        Monetization.Initialize(store_ID, false);
        //ShowBanner();
        // ShowVideoAd();
        if(!Monetization.IsReady ("rewardedVideo"))
        {
            AdsBtn.SetActive(false);
        }
        else{

        }
    }

     void Update()
    {
        if(gameManager.play_video_ad == true)
        {
           ShowVideoAd();
           
        }
    }
    

    // public void ShowBanner()
    // {
    //     StartCoroutine(Banner());
    // }

    // public void HideBanner()
    // {
    //     Advertisement.Banner.Hide();
    // }

    // IEnumerator Banner()
    // {
    //     while(!Advertisement.IsReady(Banner_ID));
    //     {
    //         yield return new WaitForSeconds(0.5f);
    //     }
    //     Advertisement.Banner.Show(Banner_ID);
    // }

    public void ShowVideoAd()
    {
        gameManager.gameover_count = 0;
        //  Debug.Log("not showing");
        StartCoroutine(Video());
       
    }

    IEnumerator Video()
    {
        yield return new WaitForSeconds(0.5f);
        //  Debug.Log("sssss0");
        if (Monetization.IsReady("video"))
            {
                ShowAdPlacementContent ad = null;
                ad = Monetization.GetPlacementContent("video") as ShowAdPlacementContent;

                if(ad != null)
                {
                    gameManager.gameover_count = 0;
                    ad.Show();
                    gameManager.gameover_count = 0;                     
                    PlayerPrefs.SetInt("Gameover_count", 0);
                    gameManager.play_video_ad = false;
                }
            }
        gameManager.play_video_ad = false;
    }

     public void ShowAd() {
        StartCoroutine (WaitForAd());
    }

    IEnumerator WaitForAd () {

        while (!Monetization.IsReady ("rewardedVideo")) {
            yield return null;
        }

        ShowAdPlacementContent ad = null;
        ad = Monetization.GetPlacementContent ("rewardedVideo") as ShowAdPlacementContent;

        if (ad != null) {
            ad.Show (AdFinished);
        }
    }

    void AdFinished (ShowResult result) {
        if (result == ShowResult.Finished) {
            // Reward the player
            RewindBtn.SetActive(true);
            AdsBtn.SetActive(false);
        }
    }
    
}
