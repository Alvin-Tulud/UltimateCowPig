using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Vector3 startingPos;

    // Start is called before the first frame update
    void Awake()
    {
        startingPos = transform.position;
        GetComponent<AIDestinationSetter>().target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetPosition()
    {
        transform.position = startingPos;
    }
}
