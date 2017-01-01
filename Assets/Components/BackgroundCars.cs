using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
public class BackgroundCars : MonoBehaviour
{
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
        public OffsetTransform(Transform _position, Vector3 _offset)
        {
            position = _position;
            offset = _offset;
        }
    }

    public float totalDistance;
    public int cars;
    public List<float> distances;
    public AnimationCurve curve;
    public float test;

    // Use this for initialization
    void OnValidate()
    {
        totalDistance = 0f;
        distances = new List<float>();

        for (int i = 0; i < points.Length; i++)
        {
            if (i + 1 < points.Length)
            {
                var dist = Vector3.Distance(points[i].full, points[i + 1].full);
                distances.Add(dist);
                totalDistance += dist;
            }

        }

        cars = Mathf.FloorToInt(totalDistance * carsPerUnit);
        curve = MakeCurve();
        test = GetLerpValue(GetPart(1), 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDrawGizmos()
    {
        for (int i = 0; i < cars; i++)
        {
            var overallDistance = i / totalDistance;
            var currentPart = 0;
            //Gizmos.DrawCube(, 1f);
        }
    }

    AnimationCurve MakeCurve()
    {
        Keyframe[] frames = new Keyframe[points.Length];
        var time = 0f;
        for (int p = 0; p < distances.Count; p++)
        {
            
            time += distances[p];
            var value = 1 + p;
            frames[p] = new Keyframe(time, value);
        }
        var curve = new AnimationCurve(frames);
        curve.AddKey(new Keyframe(0, 0));
        curve.preWrapMode = WrapMode.Loop;
        curve.postWrapMode = WrapMode.Loop;
        SetCurveLinear(curve);
        return curve;
    }

    int GetPart(float distanceTravelled)
    {
        var part = Mathf.FloorToInt(curve.Evaluate(distanceTravelled));
        return part;
    }

    float GetLerpValue(int part, float distanceTravelled)
    {
        var l = curve.Evaluate(distanceTravelled) - part;
        return l;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < points.Length; i++)
        {
            if (i + 1 < points.Length)
            {
                var thisPos = points[i].full;
                var nextPos = points[i + 1].full;
                Gizmos.DrawLine(thisPos, nextPos);
            }

        }
    }

    /// <summary>
    /// from https://forum.unity3d.com/threads/how-to-set-an-animation-curve-to-linear-through-scripting.151683/
    /// </summary>
    /// <param name="curve"></param>
    public static void SetCurveLinear(AnimationCurve curve)
    {
        for (int i = 0; i < curve.keys.Length; ++i)
        {
            float intangent = 0;
            float outtangent = 0;
            bool intangent_set = false;
            bool outtangent_set = false;
            Vector2 point1;
            Vector2 point2;
            Vector2 deltapoint;
            Keyframe key = curve[i];

            if (i == 0)
            {
                intangent = 0; intangent_set = true;
            }

            if (i == curve.keys.Length - 1)
            {
                outtangent = 0; outtangent_set = true;
            }

            if (!intangent_set)
            {
                point1.x = curve.keys[i - 1].time;
                point1.y = curve.keys[i - 1].value;
                point2.x = curve.keys[i].time;
                point2.y = curve.keys[i].value;

                deltapoint = point2 - point1;

                intangent = deltapoint.y / deltapoint.x;
            }
            if (!outtangent_set)
            {
                point1.x = curve.keys[i].time;
                point1.y = curve.keys[i].value;
                point2.x = curve.keys[i + 1].time;
                point2.y = curve.keys[i + 1].value;

                deltapoint = point2 - point1;

                outtangent = deltapoint.y / deltapoint.x;
            }

            key.inTangent = intangent;
            key.outTangent = outtangent;
            curve.MoveKey(i, key);
        }
    }
}
