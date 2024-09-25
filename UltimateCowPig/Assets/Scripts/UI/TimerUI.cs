using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimerUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI timeDisplay;
    public GameStateManager manager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeDisplay.text=manager.timerText;
    }
}
