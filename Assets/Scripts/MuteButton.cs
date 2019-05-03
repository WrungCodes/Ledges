using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class MuteButton : MonoBehaviour {

    public static MuteButton instance;
	
    public GameObject audioOnIcon;
    public GameObject audioOffIcon;
 
    // Use this for initialization
    void Start () {

    }
 
    // Update is called once per frame
    void Update () {
 
    }
 
    public void ToggleSound()
    {
        if (PlayerPrefs.GetInt ("Muted", 0) == 0) {
            PlayerPrefs.SetInt ("Muted", 1);
        }
        else
        {
 
            PlayerPrefs.SetInt ("Muted", 0);
        }
 
        SetSoundState ();
    }

    void Awake()
    {
       
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
 

