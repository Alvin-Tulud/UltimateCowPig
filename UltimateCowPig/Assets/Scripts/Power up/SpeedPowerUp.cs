using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpeedPowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private ScriptableStats _stats;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag=="Player"){
            float currentBuff=col.gameObject.GetComponent<PlayerController>().GetSpeedBuff();
            Debug.Log("speedbuff:"+currentBuff);
            col.gameObject.GetComponent<PlayerController>().SetSpeedBuff(currentBuff+0.25f);
            Destroy(gameObject);
        }
    }
}
