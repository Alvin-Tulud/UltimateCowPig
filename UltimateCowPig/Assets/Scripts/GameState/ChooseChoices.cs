using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseChoices : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AddTime(){
        //add time
        //add barrier
    }
    void RemoveTime(){
        //add time
    }
    void addSpeed(){
         float currentBuff=Player.GetComponent<PlayerController>().GetSpeedBuff();
            Player.GetComponent<PlayerController>().SetSpeedBuff(currentBuff+0.25f);
    }
    void addJump(){
        Player.GetComponent<PlayerController>().jumpCount++;
    }

    //this one will choose a random buff to add 
    void addBuff(){
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
