using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exploded : MonoBehaviour {
    [SerializeField] private GameObject explode;
    new AudioSource  audio;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.root.gameObject.transform.position += new Vector3(-1, 0, 0);
        if (transform.position.x < 0)
        {
            dead();
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.root.gameObject.GetComponent<cotroller>().damage = true;
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector3(-3,2,0)*10,ForceMode2D.Impulse);
            audio.Play();
            explode.SetActive(true);
            Invoke("dead",2f);
        }
    }

    void dead()
    {
        Destroy(transform.root.gameObject);
    }
}
