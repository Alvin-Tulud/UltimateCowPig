using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    [SerializeField]
    private LayerMask playerMask;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer.CompareTo(playerMask) == 0)
        {
            //winstate function call
        }
    }
}
