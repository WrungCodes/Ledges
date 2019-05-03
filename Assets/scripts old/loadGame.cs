using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadGame : MonoBehaviour {


    public Slider slider;




	// Use this for initialization
	void Start () {
        StartCoroutine(LoadGame());

        

	}
	
	// Update is called once per frame
	void Update () {
        slider.value += Time.deltaTime/5;
	}

    IEnumerator LoadGame()
    {
       

        yield return new WaitForSeconds(5.3f);

        SceneManager.LoadScene(2);

        yield break;
    }
}
