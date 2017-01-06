using UnityEngine;
using System.Collections;
using System;

public class CarGrid : NavGrid {

    public CarNode nodes;
    public void CreateGrid()
    {
        nodes = GetComponentInChildren<CarNode>();
    }
    public override Node NodeFromWorldPoint(Vector3 worldPosition)
    {
        throw new NotImplementedException();
    }
}

public class CarNode : Node
{
    static bool _walkable = true;
    public CarNode(Vector3 _worldPos, int _gridX, int _gridY) : base(_walkable, _worldPos, _gridX, _gridY)
    {

    }
}