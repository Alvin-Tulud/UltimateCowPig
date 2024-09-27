using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesText : MonoBehaviour
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
        timeDisplay.text = "Lives:" + manager.lifeCount.ToString();
    }
}
