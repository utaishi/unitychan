using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KCManeger : MonoBehaviour {
    private GameObject UI;
    private GameObject killcnt;
    public static int kill = 0;
    public Animator playanims;
    // Use this for initialization
    public static int getkillcnt()
    {
        return kill;
    }

    void Start () {
        killcnt = GameObject.FindGameObjectWithTag("killcount");
        UI = GameObject.FindGameObjectWithTag("canvas");
        kill = 0;
    }
	
	// Update is called once per frame
	void Update () { 
    }

    public void killP()
    {
        kill++;
        killcnt.GetComponent<Text>().text = kill.ToString();
        if (playanims.GetBool("At3") == false)
        {
            UI.GetComponent<Animator>().Play("plusKill");
        }
    }
}
