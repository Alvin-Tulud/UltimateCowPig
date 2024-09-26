using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer;
    public string timerText;
    private static GameObject WinScreen;

    public GameObject player;

    private static CameraFollow camera;
    private static int roundCount;

    private int lifeCount;

    void Start()
    {
        WinScreen = GameObject.FindWithTag("Overlay").transform.GetChild(1).gameObject;
        camera = Camera.main.GetComponent<CameraFollow>();

        timer=60.0f;
        roundCount=0;
        lifeCount=6;
    }

    // Update is called once per frame
   void FixedUpdate()
    {
        if (timer <= 0.0f){
            timerText= string.Format("{0:00}:{1:00}:{2:000}",0,0,0);
            //kill player
        }else{
            updateTime();
        }
    }
    public float getTimer(){
        return timer;
    }
    public void setTimer(float input){
        timer=input;
    }
    public void addTimer(float input){
        timer+=input;
    }
    private void updateTime(){

        
        int minutes = Mathf.FloorToInt(timer/60);
        int seconds = Mathf.FloorToInt(timer%60);
        int milliseconds = Mathf.FloorToInt(timer*1000);
        milliseconds=milliseconds%1000;
        timerText= string.Format("{0:00}:{1:00}:{2:000}",minutes,seconds,milliseconds);
        timer-=Time.deltaTime;
    }
    public static void WinState(){
        roundCount++;
        //increase screen on multiples of 5
        
        if (roundCount%5==0){
            camera.currentScreen++;
            Debug.Log("camera:"+camera.currentScreen);
        }
        PlayerController.ResetToSpawn();
        resetEnemies();
        WinScreen.SetActive(true);
    }

    public static void DeadState()
    {
        PlayerController.ResetToSpawn();
        resetEnemies();
    }

    private static void resetEnemies()
    {
        List<GameObject> enemies = new List<GameObject>();
        GameObject.FindGameObjectsWithTag("Enemy", enemies);

        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyAI>().resetPosition();
        }
    }
}
