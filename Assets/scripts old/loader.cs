using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class loader : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if (SplashScreen.isFinished)
        {
            StartCoroutine(LoadGame());
        }	
	}

    IEnumerator LoadGame()
    {


        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(1);

        yield break;
    }
}
