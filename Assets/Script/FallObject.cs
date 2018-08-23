using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallObject : MonoBehaviour {
    [SerializeField] private GameObject explode;
    new AudioSource audio;
    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(0, -0.6f, 0);
        if(transform.position.y < -200)
        {
            Dead();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<cotroller>().damage = true;
            audio.Play();
            explode.SetActive(true);
            Invoke("Dead", 3);
        }
    }
    void Dead()
    {
        Destroy(transform.root.gameObject);
    }
}
