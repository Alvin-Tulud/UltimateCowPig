using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLogManager : MonoBehaviour
{
    //flip flop for state
    private bool startPlayerLog;
    private bool playPlayerLog;

    //hold player transforms
    private List<Vector3> playerPos = new List<Vector3>();

    //timer
    private const float maxTime = 25;
    private float currentTime = 0;

    //for playing index
    private int playerPosIndex = 0;
    private void FixedUpdate()
    {
        if (startPlayerLog)
        {
            logPosition();
        }
        else if (playPlayerLog)
        {
            playPosition();
        }
    }

    //flip flop
    public void beginPosLog()
    {
        startPlayerLog = true;
        playPlayerLog = false;
    }

    //flip flop
    public void beginPlayLog()
    {
        startPlayerLog = false;
        playPlayerLog = true;
    }

    //grabs players position at each half second interval
    private void logPosition()
    {
        if (currentTime < maxTime)
        {
            currentTime++;
        }
        else
        {
            playerPos.Add(transform.position);
            currentTime = 0;
        }
    }

    //lerps from index i to i + 1 at each half second interval
        //goes to the next index after each finished lerp
    //deletes the list after playing the whole thing
    private void playPosition()
    {
        if (playerPosIndex < playerPos.Count + 1)
        {
            if (currentTime < maxTime)
            {
                transform.position = Vector3.Lerp(playerPos[playerPosIndex], playerPos[playerPosIndex + 1], currentTime /  maxTime);
                currentTime++;
            }
            else
            {
                transform.position = playerPos[playerPosIndex + 1];
                playerPosIndex++;
                currentTime = 0;
            }
        }
        else
        {
            playerPos.Clear();
        }
    }

    public void clearLog()
    {
        playerPos.Clear();
    }
}
