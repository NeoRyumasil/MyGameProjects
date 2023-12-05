using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHead : MonoBehaviour
{
    [SerializeField] private GameObject[] Waypoints;
    private int CurrentWaypointIndex = 0;
    private float DelayTime = 2;

    [SerializeField] private float speed;

    // Object Bergerak
    private void Update()
    {
        if (Vector2.Distance(Waypoints[CurrentWaypointIndex].transform.position, transform.position) < .1)
        {
            CurrentWaypointIndex++;
            if (CurrentWaypointIndex >= Waypoints.Length)
            {
                CurrentWaypointIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, Waypoints[CurrentWaypointIndex].transform.position, Time.deltaTime * speed);
        Invoker();
        
    }

    void Invoker()
    {
        if (transform.position == Waypoints[CurrentWaypointIndex].transform.position)
        {
            Invoke("Update", 2);
        }
    }
}
