using UnityEngine;
using System.Collections.Generic;
using System;

public static class Func_Lib {
    public static void CleanArray()
    {
        Func<double, double> f = Math.Sin;
        double y = f(4); //y=sin(4)
        f = Math.Sin;
        y = f(4); //y=exp(4)
    }
    public static GameObject MakeWithC<T>() where T : Component 
    {
        var r = new GameObject();
        r.AddComponent<T>();
        return r;
    }

    public static GameObject MakeJunction(List<GameObject> childNodes = null)
    {
        //var jclass = typeof (Junction);
        var g = MakeWithC<Junction>();
        var c = g.GetComponent<Junction>();
        c.nodes = childNodes;
        return g;
    }

    public static GameObject MakeNode()
    {
        var r = MakeWithC<MyNode>();
        return r;
    }

    public static Vector3 GetClosest(Vector3[] objects, Vector3 source)
    {
        Vector3 bestTarget = Vector3.zero;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = source;
        foreach (Vector3 potentialTarget in objects)
        {
            Vector3 directionToTarget = potentialTarget - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        return bestTarget;
    }

    public static Transform GetClosestTransform(Transform[] enemies, Vector3 source)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = source;
        foreach (Transform potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        return bestTarget;
    }
}
