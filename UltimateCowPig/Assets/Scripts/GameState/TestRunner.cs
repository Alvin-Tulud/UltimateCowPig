using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRunner : MonoBehaviour
{
    [SerializeField]
    private GameObject runner;

    private GameObject runnerObj;
    Path runnerPath;
    bool canCompleteLevel;

    private GameObject start;
    private GameObject end;

    public List<GraphNode> paths = new List<GraphNode>();
    private List<Vector3> pathNodes = new List<Vector3>();
    private bool outState;

    public bool startRunnerCheck()
    {
        start = GameObject.FindWithTag("Start");
        end = GameObject.FindWithTag("End");


        runnerObj = Instantiate(runner, start.transform.position, start.transform.rotation);
        runnerObj.GetComponent<AIDestinationSetter>().target = end.transform;

        StartCoroutine(waitRunner());

        runnerObj.GetComponent<AIPath>().GetRemainingPath(pathNodes, out outState);
        canCompleteLevel = pathNodes[pathNodes.Count - 1].Equals(end.transform.position);

        Destroy(runnerObj);

        return canCompleteLevel;
    }

    private IEnumerator waitRunner()
    {
        yield return new WaitForSeconds(0.25f);
    }
}
