using System;
using System.Collections.Generic;
using UnityEngine;

public class CarNodeC : MonoBehaviour
{
    CarNode node;

    public CarNodeC parent;
    public List<CarNodeC> connections;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(transform.position, 0.5F);
        if (connections != null)
        {
            
            for (int i = 0; i < connections.Count; i++)
            {
                if (connections[i] != null)
                {
                    Gizmos.DrawLine(transform.position, connections[i].transform.position);
                }
                
            }
        }
    }
}
