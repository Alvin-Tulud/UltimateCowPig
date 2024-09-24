using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killScreen : MonoBehaviour
{
    private Transform ObjToMove;
    private const int endTime = 50;
    private int currentTime = 0;
    private bool enableScreen = false;

    [SerializeField]
    private Vector3 startPos;
    [SerializeField]
    private Vector3 endPos;

    // Start is called before the first frame update
    void Start()
    {
        ObjToMove = transform.GetChild(0);
        ObjToMove.gameObject.SetActive(enableScreen);
    }

    private void FixedUpdate()
    {
        
    }

    public void startKillScreen()
    {
        enableScreen = true;
    }
}
