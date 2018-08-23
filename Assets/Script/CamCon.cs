using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCon : MonoBehaviour {
    public GameObject target;
    Transform firpos;
	// Use this for initialization
	void Start () {
        firpos = transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(target.transform.position.x+20f,target.transform.position.y+15f,firpos.position.z);
	}
}
