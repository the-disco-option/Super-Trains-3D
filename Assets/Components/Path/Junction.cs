using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEditor;

public class Junction : MonoBehaviour
{
    public List<GameObject> nodes;
    public GameObject parent;
    public List<PathingJunction> Paths;
    public float drawSize = 0.1F;
    [InspectorButton("Clean")]
    public bool CleanNodes;

    public void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, drawSize);
        
        for (int i = 0; i < nodes.Count; i++)
        {
            GameObject target = nodes[i];
            if (target != null)
            {
                Gizmos.DrawLine(transform.position, target.transform.position);
            }
        }
    }

    public void Clean()
    {
        Debug.Log("CLN Trimming " + nodes.Count + " nodes");
        //nodes.TrimExcess();
        for(var i = nodes.Count - 1; i > -1; i--)
        {
            if (nodes[i] == null)
            {
                nodes.RemoveAt(i);
            }
        }
        Debug.Log("CLN New count: " + nodes.Count);


    }

    public void UpdatePaths()
    {
        for (int i = 0; i < nodes.Count; i++)
        {
            var path = nodes[i];
            //Junction target;
            if (path.GetComponent<MyNode>() is MyNode)
            {

            }
        }
    }

    private void UpdatePathsCallback(GameObject end)
    {
        //do stuff
    }

    public PointLine FindLine<T>(GameObject start, Component end)where T : Component
    {
        return null;
    }
}
[System.Serializable]
public class PointLine
{
    public List<Vector3> points;
}

[System.Serializable]
public class PathingJunction
{
    public GameObject Object;
    public int distance;
}