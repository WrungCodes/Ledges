using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class socialScript : MonoBehaviour {

    public bool mIsAppLeft ;	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SocialButton(string url) {  }

    void OnApplicationPause(bool inIsPause)
        {
        this.mIsAppLeft = true;
        }
    public void Facebook(){
        StartCoroutine(OpenFacebook());
    }
    public void Twitter(){
        StartCoroutine(OpenTwitter());
    }
    public void Instagram(){
        StartCoroutine(OpenInstagram());
    }
    public void Youtube(){
        StartCoroutine(OpenYoutube());
    }
    
    public IEnumerator OpenFacebook()
    {
        Application.OpenURL("fb://profile/################");//replace #'s w/ fb profile id
        yield return new WaitForSeconds(1f);
        if (this.mIsAppLeft)
            this.mIsAppLeft = false;
        else
            Application.OpenURL("http://www.facebook.com/mypage");//replace mypage
    }
    
    public IEnumerator OpenTwitter()
    {
        Application.OpenURL("twitter:///user?screen_name=username");//repace username
        yield return new WaitForSeconds(1f);
        if (this.mIsAppLeft)
            this.mIsAppLeft = false;
        else
            Application.OpenURL("http://www.twitter.com/username");//replace username
    }

    public IEnumerator OpenInstagram()
    {
        Application.OpenURL("instagram://user?username=USERNAME");//repace username
        yield return new WaitForSeconds(1f);
        if (this.mIsAppLeft)
            this.mIsAppLeft = false;
        else
            Application.OpenURL("http://www.instagram.com/username");//replace username
    }
    public IEnumerator OpenYoutube()
    {
        Application.OpenURL("youtube://user?username=USERNAME");//repace username
        yield return new WaitForSeconds(1f);
        if (this.mIsAppLeft)
            this.mIsAppLeft = false;
        else
            Application.OpenURL("http://www.youtube.com/username");//replace username
    }
    public void Rate()
    {
        #if UNITY_ANDROID

         Application.OpenURL("market://details?id=YOUR_ID");
        
        #elif UNITY_IOS

         Application.OpenURL("itms-apps://itunes.apple.com/app/idYOUR_ID");
        
        #endif
    }
}
