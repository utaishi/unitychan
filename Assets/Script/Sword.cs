using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {
    private bool on = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(2, 0, 0);
        if (on == false)
        {
            Invoke("Des", 1.5f);
            on = true;
        }
	}

    private void Des()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.transform.root.gameObject.GetComponent<EnemyCon>().Damage();
        }
        else if (col.gameObject.tag == "Respawn")
        {
            col.gameObject.GetComponent<damageR>().Damage();
        }
    }
}
