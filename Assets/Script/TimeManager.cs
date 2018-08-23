using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {
    public static float timeScale=0.8f;
    public static float slowTime = 0.3f;
    public static float elapsedTime=0f;
    public static bool isSlowDown = false;
	// Use this for initialization
	void Start () {
        timeScale = 0.8f;
        slowTime = 0.3f;
        elapsedTime = 0f;
        isSlowDown = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (isSlowDown)
        {
            elapsedTime += Time.unscaledDeltaTime;
            if (elapsedTime >= slowTime)
            {
                SetNormalTime();
            }
        }
	}

    public void SlowDown()
    {
        elapsedTime = 0;
        Time.timeScale = timeScale;
        isSlowDown = true;
    }
    public static void SuperSlowdown()
    {
        timeScale = 0.3f;
        slowTime = 5f;
        elapsedTime = 0;
        Time.timeScale = timeScale;
        isSlowDown = true;
    }
    public static void SetNormalTime()
    {
        Time.timeScale = 1f;
        timeScale = 0.8f;
        slowTime = 0.3f;
        isSlowDown = false;
    }
}
