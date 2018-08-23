using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gattack : MonoBehaviour {
    Animator _anim;

	// Use this for initialization
	void Start () {
        _anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<cotroller>().SP > 10)
        {
            if ((Input.GetKeyDown(KeyCode.C)) || (Input.GetKeyDown(KeyCode.Joystick1Button3)))
            {
                if ((Input.GetKey(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.LeftArrow)) || (Input.GetAxis("Horizontal") > 0.5f) || (Input.GetAxis("Horizontal") < -0.5f))
                {
                    GetComponent<cotroller>().SP -= 10;
                    _anim.Play("Natt");
                }
                else if (Input.GetKey(KeyCode.UpArrow))
                {
                    //GetComponent<cotroller>().SP -= 10;
                    //_anim.Play("Upatt");
                }
                else if ((Input.GetKey(KeyCode.DownArrow)) || (Input.GetAxis("Vertical") < -0.5f))
                {
                    GetComponent<cotroller>().SP -= 10;
                    _anim.Play("Datt");
                }
                else
                {
                    GetComponent<cotroller>().SP -= 10;
                    _anim.Play("N2att");
                }
            }
        }
	}
}
