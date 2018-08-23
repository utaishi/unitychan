using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trexmanger : MonoBehaviour {
    public GameObject fireball;
    public GameObject ice;
    public Transform mazzle;
    public Transform ypos;
    AudioSource explosion;
    AudioSource rexshout;
    AudioSource unari;
    AudioSource flame;
	// Use this for initialization
	void Start () {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        explosion = audioSources[1];
        rexshout = audioSources[2];
        unari = audioSources[3];
        flame = audioSources[4];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void hassya()
    {
        GameObject instance = GameObject.Instantiate(fireball) as GameObject;
        instance.transform.position = mazzle.position;
    }

    void iceattack()
    {
        GameObject instance = GameObject.Instantiate(ice) as GameObject;
        instance.transform.position = ypos.position+new Vector3(Random.Range(0,205),0,0);
    }

    void exp()
    {
        explosion.Play();
    }

    void rexs()
    {
        rexshout.Play();
    }

    void una()
    {
        unari.Play();
    }

    void flameon()
    {
        flame.Play();
    }
    
}
