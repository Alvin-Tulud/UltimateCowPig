using Pathfinding.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GameStateManager : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer;
    public string timerText;
    public SpawnObstacle spawner;
    public GameObject[] obstacle;
    private  GameObject WinScreen;
    private  GameObject LossScreen;


    //add loss screen

    public GameObject player;

    public GameObject ghost;

    private  CameraFollow camera;
    private  int roundCount;

    public int lifeCount;

    void Start()
    {
        WinScreen = GameObject.FindWithTag("Overlay").transform.GetChild(1).gameObject;
        LossScreen = GameObject.FindWithTag("Overlay").transform.GetChild(2).gameObject;
        //add lose screen with button that either goes to menu or restarts
        camera = Camera.main.GetComponent<CameraFollow>();

        timer=0.0f;
        roundCount=1;
        lifeCount=6;
    }

    // Update is called once per frame
   void FixedUpdate()
    {
        updateTime();

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
        timer+=Time.deltaTime;
    }
    public void WinState(){
        roundCount++;
        //Add buff every 2 rounds won
       /* if (roundCount%2==0){
            Random rnd = new Random();
            int rndBuff=rnd.Next(0,2); 
            Debug.Log("rnd:"+rndBuff);
            switch(rndBuff){
                case 0:
                    
                    float currentBuff=player.GetComponent<PlayerController>().GetSpeedBuff();
                    player.GetComponent<PlayerController>().SetSpeedBuff(currentBuff+0.25f);
                    float currentBuff2=ghost.GetComponent<PlayerController>().GetSpeedBuff();
                    ghost.GetComponent<PlayerController>().SetSpeedBuff(currentBuff2+0.25f);
                    
                    break;
                case 1:
                    
                    player.GetComponent<PlayerController>().jumpCount++;
                    ghost.GetComponent<PlayerController>().jumpCount++;
                    break;
            }
        }*/
        //add barrier
        if (roundCount%4==0){
            Random rnd = new Random();
            int rndBuff=rnd.Next(0,obstacle.Length-1); 
            spawner.spawnObstacle(obstacle[rndBuff]);
        }
        //total win
        if (roundCount>=6){
            WinScreen.SetActive(true);
        }

        player.GetComponent<PlayerController>().ResetToSpawn();
        ghost.GetComponent<PlayerController>().ResetToSpawn();
        
        if(player.GetComponent<PlayerController>().isGhost==false){
            
            player.GetComponent<MoveLogManager>().resetPlayback();
            

           
        }else{
            
            ghost.GetComponent<MoveLogManager>().resetPlayback();
        }

        //reset timer
        timer=0.0f;
        //reset other stuff
        resetEnemies();
        //switch
        switchPlayers();
    }

    public void DeadState()
    {
        
         timer=0.0f;
        player.GetComponent<PlayerController>().ResetToSpawn();
        ghost.GetComponent<PlayerController>().ResetToSpawn();
        
        //clear log of dead player, reset play of ghost player
        if(player.GetComponent<PlayerController>().isGhost==false){
            ghost.GetComponent<MoveLogManager>().resetPlayback();
            lifeCount--;
            if(lifeCount<=0){
                Time.timeScale=0;
                 LossScreen.SetActive(true);
                 Debug.Log("YOU LOST !");
             }
        }else{
             switchPlayers();
            player.GetComponent<MoveLogManager>().resetPlayback();
        }

       

        resetEnemies();
    }
    public void LossState(){
       
         timer=0.0f;
       // player.GetComponent<PlayerController>().ResetToSpawn();
        //ghost.GetComponent<PlayerController>().ResetToSpawn();

        //clear log of dead player, reset play of ghost player
        if(player.GetComponent<PlayerController>().isGhost==false){
           // player.GetComponent<MoveLogManager>().clearLog();
            ghost.GetComponent<PlayerController>().ResetToSpawn();
            ghost.GetComponent<MoveLogManager>().resetPlayback();
        }else{
           // ghost.GetComponent<MoveLogManager>().clearLog();
             player.GetComponent<PlayerController>().ResetToSpawn();
            player.GetComponent<MoveLogManager>().resetPlayback();
        }

        resetEnemies();
    }
    private void switchPlayers(){
        //player should stop recording and then just use path when ghost 
        if( player.GetComponent<PlayerController>().isGhost == false ){
            //set player to ghost
            player.GetComponent<PlayerController>().isGhost=true;
            player.GetComponent<MoveLogManager>().beginPlayLog();
            ghost.GetComponent<PlayerController>().isGhost=false;
            ghost.GetComponent<MoveLogManager>().beginPosLog();
            //set ghost to player

            //turn on off playing indicator
            ghost.transform.GetChild(1).gameObject.SetActive(true);
            player.transform.GetChild(1).gameObject.SetActive(false);

            //toggle objective text
            GameObject.FindWithTag("GoalText").transform.GetChild(0).gameObject.SetActive(false);
            GameObject.FindWithTag("GoalText").transform.GetChild(1).gameObject.SetActive(true);
        }
        else{
            //set player to player
            //set ghost to ghost
            player.GetComponent<PlayerController>().isGhost=false;
            player.GetComponent<MoveLogManager>().beginPosLog();
            ghost.GetComponent<PlayerController>().isGhost=true;
            ghost.GetComponent<MoveLogManager>().beginPlayLog();

            //turn on off playing indicator
            ghost.transform.GetChild(1).gameObject.SetActive(false);
            player.transform.GetChild(1).gameObject.SetActive(true);

            //toggle objective text
            GameObject.FindWithTag("GoalText").transform.GetChild(0).gameObject.SetActive(true);
            GameObject.FindWithTag("GoalText").transform.GetChild(1).gameObject.SetActive(false);
        }

    }

    private void resetEnemies()
    {
        List<GameObject> enemies = new List<GameObject>();
        GameObject.FindGameObjectsWithTag("Enemy", enemies);

        foreach(GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyAI>().resetPosition();
        }
    }
}
