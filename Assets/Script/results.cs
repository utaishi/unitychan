using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class results : MonoBehaviour {
    Animator _anims;

	// Use this for initialization
	void Start () {
        _anims = GetComponent<Animator>();
        _anims.Play("result");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
