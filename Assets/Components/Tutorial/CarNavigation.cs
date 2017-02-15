using UnityEngine;
using System.Collections;

public class CarNavigation : MonoBehaviour {

    public Pathfinding pathfinder;
    public CarGrid grid;
    public Vector3 target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    //grid.NodeFromWorldPoint(transform.position)
	}

     void GoTo(Vector3 worldPosition)
    {
        
    }
}
