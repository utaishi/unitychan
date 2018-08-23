using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class retry : MonoBehaviour {
    public GameObject returnPos;
    public GameObject returnPosBoss;
    private Animator _anim;
    public static int deadnum = 0;

    public static int getdeadcnt()
    {
        return deadnum;
    }
	// Use this for initialization
	void Start () {
        _anim = GetComponent<Animator>();
        deadnum = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void retrystart()
    {
        GetComponent<cotroller>().HP = 100;
        GetComponent<cotroller>().SP = 100;
        deadnum++;
        Debug.Log(deadnum);
        GetComponent<cotroller>().dead = false;
        if (GetComponent<cotroller>().bossCheck)
        {
            transform.position = returnPosBoss.transform.position;
            GetComponent<AEs>().BossApBar();
            _anim.Play("Idle");
        }
        else
        {
            transform.position = returnPos.transform.position;
            GetComponent<AEs>().ApBar();
            _anim.Play("Idle");
        }
    }
}
