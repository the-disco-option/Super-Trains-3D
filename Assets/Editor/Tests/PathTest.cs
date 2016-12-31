using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Collections.Generic;

public class PathTest {

    [Test]
    public void simplePathObj()
    {
        //Prep
        string path = null;
        var one = new GameObject();
        var ein = one.AddComponent<Junction>();
        var two = new GameObject();
        var zwei = one.AddComponent<Junction>();
        var three = new GameObject();
        var drei = one.AddComponent<Junction>();
        var four = new GameObject();
        var vier = one.AddComponent<Junction>();
        //connect nodes
        ein.nodes.Add(two);
        zwei.nodes.Add(three);
        drei.nodes.Add(four);
        vier.nodes.Add(two);
        //add to list
        List<GameObject> nodes = new List<GameObject>();
        nodes.Add(one);
        nodes.Add(two);
        nodes.Add(three);
        nodes.Add(four);
        
        //Path
        /* 
         * Start at 1, target is 4
         *    [1]-[2]-[3]
         *          `-[4]
         */
        
        // Do stuff

        //Assert
        Assert.AreEqual(path, new GameObject[] {one, two, four});
    }

}
