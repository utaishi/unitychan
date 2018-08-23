using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revent : MonoBehaviour {
    AudioSource deadExp;
    AudioSource slash;
	// Use this for initialization
	void Start () {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        slash = audioSources[0];
        deadExp = audioSources[1];
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void deadSE()
    {
        deadExp.Play();
    }
}
