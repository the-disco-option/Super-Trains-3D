using UnityEngine;
using System.Collections;

public interface IGrid {

    Node NodeFromWorldPoint(Vector3 worldPosition);
}

public abstract class NavGrid : MonoBehaviour
{
    public abstract Node NodeFromWorldPoint(Vector3 worldPosition);
}