using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roboSpawn : MonoBehaviour {
    public GameObject Rprefab;
    private int spawnTime = 0;
    private int interval=300;
    public bool isTrue = false;
    public bool allend = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isTrue == true)
        {
            if (spawnTime >= interval)
            {
                GameObject instance = GameObject.Instantiate(Rprefab) as GameObject;
                instance.transform.position = transform.position;
                Invoke("ChangeInt", 1f);
                spawnTime = 0;
            }
            else
            {
                spawnTime++;
            }
        }
        if (allend == false)
        {
            if (transform.root.gameObject.GetComponent<Animator>().GetBool("At3"))
            {
                isTrue = true;
            }
            else
            {
                isTrue = false;
            }
        }
       
    }

    void ChangeInt()
    {
        interval = (int)Random.Range(150,500);
    }
}
