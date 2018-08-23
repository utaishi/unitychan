using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagego : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("attack!");
        if (col.gameObject.tag == "Enemy")
        {
            transform.root.GetComponent<SpAtt>().EPup();
            transform.root.GetComponent<SpAtt>().EPup();
            transform.root.GetComponent<SpAtt>().EPup();
            col.transform.root.gameObject.GetComponent<EnemyCon>().Damage();
        }
        else if (col.gameObject.tag == "Respawn")
        {
            transform.root.GetComponent<SpAtt>().EPup();
            transform.root.GetComponent<SpAtt>().EPup();
            transform.root.GetComponent<SpAtt>().EPup();
            col.gameObject.GetComponent<damageR>().Damage();
        }
       
    }
}
