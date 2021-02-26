using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Waypoint : MonoBehaviour
{
    public static Waypoint Instance { get; private set; }
    private List<Transform> waypoints;

    public List<Transform> WayPoints
    {
        get { return waypoints; }
    }

    private void Awake()
    {
        if (Instance != null) return;
        else Instance = this;
        Init();
    }

    public void Init()
    {
        waypoints = new List<Transform>
        {
            gameObject.transform
        };
    }

    public void AddPoint(Transform _point)
    {
        waypoints.Add(_point);
    }
}
