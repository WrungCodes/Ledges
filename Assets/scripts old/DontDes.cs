using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DontDes : MonoBehaviour {

    public static DontDes instance;

	// Use this for initialization
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

	void Awake () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        DontDestroyOnLoad(gameObject);
	}
}
