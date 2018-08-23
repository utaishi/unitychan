using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManeger : MonoBehaviour {
    int killc;
    int deathc;
    int timecnt;
    int score;
    public Text killobj;
    public Text deathobj;
    public Text timeobj;
    public Text scoreobj;
    // Use this for initialization
    void Start () {
        killc = KCManeger.getkillcnt();
        deathc = retry.getdeadcnt();
        timecnt = (int)cotroller.getTime();
        score = 2000+100*killc-1000*deathc+(200-timecnt)*200;
    }
	
	// Update is called once per frame
	void Update () {
        killobj.text = killc.ToString();
        deathobj.text = deathc.ToString();
        timeobj.text = timecnt.ToString();
        scoreobj.text = score.ToString();
	}
}
