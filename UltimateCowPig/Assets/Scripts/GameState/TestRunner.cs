using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRunner : MonoBehaviour
{
    [SerializeField]
    private GameObject runner;

    private GameObject start;
    private GameObject end;

    public bool startRunnerCheck()
    {
        start = GameObject.FindWithTag("Start");
        end = GameObject.FindWithTag("End");


        GameObject runnerObj;
        runnerObj = Instantiate(runner, start.transform.position, start.transform.rotation);


        runnerObj.GetComponent<AIDestinationSetter>().target = end.transform;
        Path runnerPath;
        runnerPath = runnerObj.GetComponent<Seeker>().GetCurrentPath();
        List<GraphNode> paths = runnerPath.path;


        Destroy(runnerObj);


        return PathUtilities.IsPathPossible(paths);
    }
}
