using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class At1 : MonoBehaviour {
    AudioSource audio;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<cotroller>().damage = true;
            audio.Play();
            
          
        }
    }
}
