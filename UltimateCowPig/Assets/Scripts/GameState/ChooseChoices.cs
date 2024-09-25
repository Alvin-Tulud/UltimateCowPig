using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ChooseChoices : MonoBehaviour
{
    public SpawnObstacle spawner;
    public GameObject[] obstacle;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddTime(){
        //add time


        //add barrier
        Random rnd = new Random();
        int rndBuff=rnd.Next(0,obstacle.Length-1); 
        spawner.spawnObstacle(obstacle[rndBuff]);
    }
    void RemoveTime(){
        //remove time
    }
    void addSpeed(){
         float currentBuff=Player.GetComponent<PlayerController>().GetSpeedBuff();
            Player.GetComponent<PlayerController>().SetSpeedBuff(currentBuff+0.25f);
    }
    void addJump(){
        Player.GetComponent<PlayerController>().jumpCount++;
    }

    //this one will choose a random buff to add 
    public void addBuff(){
        Random rnd = new Random();
        int rndBuff=rnd.Next(0,3); 
        switch(rndBuff){
            case 0:
                addSpeed();
                break;
            case 1:
                addJump();
                break;
        }
        RemoveTime();
        //remove time 
    }
}
