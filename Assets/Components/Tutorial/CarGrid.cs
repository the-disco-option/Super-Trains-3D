using UnityEngine;
using System.Collections;
using System;

public class CarGrid : NavGrid {

    public CarNode nodes;

    CarNodeC[] objects;
    Transform[] transforms;

    void Awake()
    {
        CreateGrid();
    }
    public void CreateGrid()
    {
        objects = GameObject.FindObjectsOfType<CarNodeC>();
        transforms = new Transform[objects.Length];
        for (int i = 0; i < objects.Length; i++)
        {
            transforms[i] = objects[i].transform;
        }
    }
    public override Node NodeFromWorldPoint(Vector3 worldPosition)
    {
        var t = Func_Lib.GetClosestTransform(transforms, worldPosition);
        return t.gameObject.GetComponent<CarNodeC>().node;
    }
}

public class CarNode : Node
{
    static bool _walkable = true;
    public CarNode(Vector3 _worldPos, int _gridX, int _gridY) : base(_walkable, _worldPos, _gridX, _gridY)
    {

    }
}