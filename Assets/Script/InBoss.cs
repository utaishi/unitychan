using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBoss : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ddd()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Animator>().Play("goboss");
            collision.gameObject.GetComponent<cotroller>().bossCheck = true;
            Invoke("ddd", 1);
        }
    }
}
