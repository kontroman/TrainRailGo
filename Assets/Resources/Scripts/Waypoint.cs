using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Waypoint : MonoBehaviour
{
    public static Waypoint Instance { get; private set; }
    private GameObject[] waypoints;

    public GameObject[] WayPoints
    {
        get { return waypoints; }
    }

    private void Awake()
    {
        if (Instance != null) return;
        else Instance = this;

    }
    private void Update()
    {
        waypoints = GameObject.FindGameObjectsWithTag("wp");
        SortWayPoints();
    }

    private void SortWayPoints()
    {
        SortedDictionary<string, GameObject> sortedTiles = new SortedDictionary<string, GameObject>();
        for (int i = 0; i < waypoints.Length; i++)
            sortedTiles.Add(waypoints[i].name, waypoints[i]);

        waypoints = sortedTiles.Values.ToArray();
    }
}
