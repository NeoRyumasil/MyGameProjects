using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailMovement : MonoBehaviour
{
    private SpriteRenderer Snail;
    private Transform CurrentPoint;
    private Rigidbody2D SnailBody;

    [SerializeField] private float Speed;
    [SerializeField] private GameObject WaypointA;
    [SerializeField] private GameObject WaypointB;

    void Start()
    {
        Snail = GetComponent<SpriteRenderer>();
        CurrentPoint = GetComponent<Transform>();
        SnailBody = GetComponent<Rigidbody2D>();
        CurrentPoint = WaypointA.transform;
    }

    void Update()
    {
        Vector2 Point = CurrentPoint.position - transform.position;

        if (CurrentPoint == WaypointA.transform)
        {
            SnailBody.velocity = new Vector2(0, Speed);
        }
        else if (CurrentPoint == WaypointB.transform)
        {
            SnailBody.velocity = new Vector2(0, -Speed);
        }

        if (Vector2.Distance(transform.position, CurrentPoint.position) < 0.5 && CurrentPoint == WaypointA.transform)
        {
            CurrentPoint = WaypointB.transform;
            Snail.flipX = false;
        }

        if (Vector2.Distance(transform.position, CurrentPoint.position) < 0.5 && CurrentPoint == WaypointB.transform)
        {
            CurrentPoint = WaypointA.transform;
            Snail.flipX = true;
        }

    }
}
