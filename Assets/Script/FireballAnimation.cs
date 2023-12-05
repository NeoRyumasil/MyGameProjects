using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAnimation : MonoBehaviour
{ 

    private Animator Animator;
    private SpriteRenderer FireBall;
    private Transform CurrentPoint;
    private Rigidbody2D FireBallBody;

    [SerializeField] private float Speed;
    [SerializeField] private GameObject WaypointA;
    [SerializeField] private GameObject WaypointB;

    void Start()
    {
        Animator = GetComponent<Animator>();
        FireBall = GetComponent<SpriteRenderer>();
        FireBallBody = GetComponent<Rigidbody2D>();
        CurrentPoint = WaypointA.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = CurrentPoint.position - transform.position;

        if (CurrentPoint == WaypointA.transform)
        {
            FireBallBody.velocity = new Vector2(Speed, 0);
        }
        else
        {
            FireBallBody.velocity = new Vector2(-Speed, 0);
        }

        if (Vector2.Distance(transform.position, CurrentPoint.position) < 0.5 && CurrentPoint == WaypointA.transform)
        {
            CurrentPoint = WaypointB.transform;
            FireBall.flipY = false;
        }
        else if (Vector2.Distance(transform.position, CurrentPoint.position) < 0.5 && CurrentPoint == WaypointB.transform)
        {
            CurrentPoint = WaypointA.transform;
            FireBall.flipY = true;
        }
    }
}

