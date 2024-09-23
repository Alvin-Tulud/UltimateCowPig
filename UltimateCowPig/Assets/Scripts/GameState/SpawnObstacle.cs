using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    [SerializeField]
    private Grid PlacementGrid;
    [SerializeField]
    private LayerMask ObstacleMask;

    private TestRunner TestRunnerScript;

    private List<Vector3> playerPosLog = new List<Vector3>();
    private bool startLog;
    private const int LogTimerMax = 25;
    private int LogTimerCount;

    // Start is called before the first frame update
    void Start()
    {
        PlacementGrid = FindAnyObjectByType<Grid>();

        TestRunnerScript = GetComponent<TestRunner>();

        startLog = false;
        LogTimerCount = 0;

    }

    private void FixedUpdate()
    {
        if (startLog)
        {
            LogTimerCount++;

            if (LogTimerCount >= LogTimerMax)
            {
                LogTimerCount = 0;
                LogPlayerPos();
            }
        }
    }

    public void spawnObstacle(GameObject obstacle)
    {
        int RandomSpotInPlayerPath = Random.Range(0, playerPosLog.Count);
        Vector3 ObstaclePlacementSpot = PlacementGrid.LocalToCell(playerPosLog[RandomSpotInPlayerPath]);


        RaycastHit2D CheckIfObstacleThere;
        CheckIfObstacleThere = Physics2D.CircleCast(ObstaclePlacementSpot, 0.1f, Vector2.zero, 0.0f, ObstacleMask);


        while (CheckIfObstacleThere && TestRunnerScript.startRunnerCheck())
        {
            RandomSpotInPlayerPath = Random.Range(0, playerPosLog.Count);
            ObstaclePlacementSpot = PlacementGrid.LocalToCell(playerPosLog[RandomSpotInPlayerPath]);


            CheckIfObstacleThere = Physics2D.CircleCast(ObstaclePlacementSpot, 0.1f, Vector2.zero, 0.0f, ObstacleMask);
        }
        

        Instantiate(obstacle, ObstaclePlacementSpot, Quaternion.identity);


        clearPlayersPosLog();
    }

    public void setStartLog(bool startLog)
    {
        this.startLog = startLog;
    }

    public void LogPlayerPos()
    {
        playerPosLog.Add(GameObject.FindWithTag("Player").transform.position);
    }

    public void clearPlayersPosLog()
    {
        playerPosLog.Clear();
    }
}
