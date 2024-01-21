using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;

    public Transform getFirstWaypoint() {
        return waypoints[0];
    }

    public int getPathLength() {
        return waypoints.Length;
    }

    public Transform getNextWaypoint(int i) {
        return waypoints[i];
    }
}
