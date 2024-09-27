using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public GameStateManager manager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(collision.gameObject.GetComponent<PlayerController>().isGhost==true){
                Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(),GetComponent<Collider2D>(),true);
            }else{
                manager = GameObject.FindWithTag("Manager").GetComponent<GameStateManager>();

                manager.DeadState();
            }
            
        }
    }
}
