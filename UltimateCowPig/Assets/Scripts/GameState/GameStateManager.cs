using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer;
    public string timerText;
    void Start()
    {
        timer=60.0f;
    }

    // Update is called once per frame
    void Update()
    {
        updateTime();
    }
    private void updateTime(){
        timer-=Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer/60);
        int seconds = Mathf.FloorToInt(timer%60);
        int milliseconds = Mathf.FloorToInt(timer*1000);
        milliseconds=milliseconds%1000;

        timerText= string.Format("{0:00}:{1:00}:{2:000}",minutes,seconds,milliseconds);
    }
}
