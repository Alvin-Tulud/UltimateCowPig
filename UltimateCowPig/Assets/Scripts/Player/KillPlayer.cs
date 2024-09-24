using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    [SerializeField]
    private LayerMask obstacleMask;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer.CompareTo(obstacleMask) == 0)
        {
            //create a reset functions for gamestate
        }
    }
}
