using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{

    public GameStateManager manager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag=="Player")
        {
            //Time.timeScale = 0;
            if (collision.gameObject.GetComponent<PlayerController>().isGhost==true){
                 manager.LossState();
            }else if(collision.gameObject.GetComponent<PlayerController>().isGhost==false){
                 manager.WinState();
            }
            
        
            //winstate function call
        }
    }
}
