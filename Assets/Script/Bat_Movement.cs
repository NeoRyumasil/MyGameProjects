using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat_Movement : MonoBehaviour
{
    private Animator AnimT;
    private SpriteRenderer Bat;
    private Rigidbody2D BatBody;
    private Transform CurrentPoint;

    [SerializeField] private float Speed;
    [SerializeField] private GameObject WaypointA;
    [SerializeField] private GameObject WaypointB;

    void Start()
    {
        AnimT = GetComponent<Animator>();
        Bat = GetComponent<SpriteRenderer>();
        BatBody = GetComponent<Rigidbody2D>();
        CurrentPoint = GetComponent<Transform>();

    }

    
    void Update()
    {
        Vector2 point = CurrentPoint.position - transform.position;

        if (CurrentPoint == WaypointA.transform)
        {
            BatBody.velocity = new Vector2(Speed, 0);
        }
        else
        {
            BatBody.velocity = new Vector2(-Speed, 0);
        }

        if (Vector2.Distance(transform.position, CurrentPoint.position) < 0.5 && CurrentPoint == WaypointA.transform)
        {
            CurrentPoint = WaypointB.transform;
            Bat.flipX = false;
        }
        else if (Vector2.Distance(transform.position, CurrentPoint.position) < 0.5 && CurrentPoint == WaypointB.transform)
        {
            CurrentPoint = WaypointA.transform;
            Bat.flipX = true;
        }
    }
}
