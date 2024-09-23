using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNewObject : MonoBehaviour
{
    public SpawnObstacle spawner;
    public GameObject obstacle;
    // Start is called before the first frame update
    void Start()
    {
        spawner.setStartLog(true);
    }

    // Update is called once per frame
    void Update()
    {
        spawner.setStartLog(true);
    }
    
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag=="Player"){
            spawner.spawnObstacle(obstacle);
        }
    
    }
}
