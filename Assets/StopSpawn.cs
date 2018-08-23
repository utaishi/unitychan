using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSpawn : MonoBehaviour {
    public GameObject spawn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            spawn.GetComponent<roboSpawn>().allend = true;
            spawn.GetComponent<roboSpawn>().isTrue = false;
        }
    }
}
