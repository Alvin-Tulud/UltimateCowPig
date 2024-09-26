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
       
        Debug.Log("ddddd"+collision.gameObject.layer.CompareTo(playerMask));
        if (collision.gameObject.layer.CompareTo(playerMask) == 0)
        {
            Debug.Log("triggerr aAAAAAAAAA");
            Time.timeScale = 0;
            manager.WinState();
            //winstate function call
             

        }
        
    }
}
