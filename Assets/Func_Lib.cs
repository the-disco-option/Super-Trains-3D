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
}
