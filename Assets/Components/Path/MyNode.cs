using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;
[AddComponentMenu("Path/Node")]
public class MyNode : MonoBehaviour
{
    public GameObject next;

    public void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 0.05F);
        if (next != null)
        {
            Gizmos.DrawLine(transform.position, next.transform.position);
        }
    }

    public GameObject GetEndPoint()
    {
        MyNode target = next.GetComponent<MyNode>();
        if (next.GetComponent<MyNode>() is MyNode)
        {
            return target.GetEndPoint();
        }

        else
        {
            return next;
        }
    }
}
