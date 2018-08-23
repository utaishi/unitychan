using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPaStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //collision.gameObject.GetComponent<EnemyCon>().enabled = false;
            transform.root.gameObject.GetComponent<Animator>().Play("SpecialAttack");
        }
    }
}
