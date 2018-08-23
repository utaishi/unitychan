using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpAtt : MonoBehaviour {
    Animator _animator;
    [SerializeField]
    public Collider2D Att;
    public Slider EPbar;
    public GameObject Text;
    int EP = 0;
    public bool inAtt=false;
    // Use this for initialization
    void Start () {
        _animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        EPbar.value = EP;
        if (EP >= 100)
        {
            Text.SetActive(true);
            if ((Input.GetKeyDown(KeyCode.S)) || (Input.GetKeyDown(KeyCode.Joystick1Button4)))
            {
                _animator.SetBool("At3", false);
                //_animator.Play("SpecialAttack");
                _animator.Play("SPAstart");
                EP = 0;

            }
        }
        else
        {
            Text.SetActive(false);
        }
    }

    public void EPup()
    {
        if (inAtt == false)
        {
            EP++;
        }
    } 
}
