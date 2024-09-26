using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    [SerializeField]
    private LayerMask playerMask;
    public GameStateManager manager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag=="Player")
        {
            Time.timeScale = 0;
            manager.WinState();
            //winstate function call
             

        }
        
    }
}
