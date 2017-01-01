using UnityEngine;
using System.Collections;

public class BackgroundCars : MonoBehaviour {
    public float carsPerUnit;
    public OffsetTransform[] points;
    [System.Serializable]
    public struct OffsetTransform
    {
        public Transform position;
        public Vector3 offset;
        public Vector3 full
        {
            get { return position.position + offset; }
        }
        public OffsetTransform( Transform _position, Vector3 _offset)
        {
            position = _position;
            offset = _offset;
        }
    }
    
    public float totalDistance;
    public int cars;
	// Use this for initialization
	void OnValidate()
    {
        totalDistance = 0f;

        for (int i = 0; i < points.Length; i++)
        {
            if (i+1 < points.Length)
            {
                totalDistance += Vector3.Distance(points[i].full, points[i + 1].full);
            }
        }

        cars = Mathf.FloorToInt(totalDistance * carsPerUnit);
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < points.Length; i++)
        {
            if (i+1 < points.Length)
            {
                var thisPos = points[i].full;
                var nextPos = points[i + 1].full;
                Gizmos.DrawLine(thisPos, nextPos);
            }
            
        }

    }
}
