using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag=="Player")
        {
            Time.timeScale = 0;
            GameStateManager.WinState();
            //winstate function call
             

        }
        
    }
}
