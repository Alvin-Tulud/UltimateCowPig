using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SpawnObstacle : MonoBehaviour
{
    [SerializeField]
    private Grid PlacementGrid;
    [SerializeField]
    private LayerMask ObstacleMask;

    private TestRunner TestRunnerScript;

    [SerializeField]
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


        while (!CheckIfObstacleThere && TestRunnerScript.startRunnerCheck())
        {
            RandomSpotInPlayerPath = Random.Range(0, playerPosLog.Count);
            ObstaclePlacementSpot = PlacementGrid.LocalToCell(playerPosLog[RandomSpotInPlayerPath]);


            CheckIfObstacleThere = Physics2D.CircleCast(ObstaclePlacementSpot, 0.1f, Vector2.zero, 0.0f, ObstacleMask);
        }

        Debug.Log(TestRunnerScript.startRunnerCheck());

        GameObject obstacleSpawned;
        obstacleSpawned = Instantiate(obstacle, ObstaclePlacementSpot, Quaternion.identity);

        //recalculate the part of the astar graph under it
        Bounds bounds = obstacleSpawned.GetComponent<Collider2D>().bounds;

        AstarPath.active.UpdateGraphs(bounds);



        clearPlayersPosLog();
    }

    public void setStartLog(bool startLog)
    {
        this.startLog = startLog;
    }

    public void LogPlayerPos()
    {
        if (!playerPosLog.Contains(GameObject.FindWithTag("Player").transform.position))
        {
            playerPosLog.Add(GameObject.FindWithTag("Player").transform.position);
        }
    }

    public void clearPlayersPosLog()
    {
        playerPosLog.Clear();
    }
}
