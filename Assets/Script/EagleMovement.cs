using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleMovement : MonoBehaviour
{

    private Animator Animator;
    private SpriteRenderer Eagle;
    private Transform CurrentPoint;
    private Rigidbody2D EagleBody;

    [SerializeField] private float Speed;
    [SerializeField] private GameObject WaypointA;
    [SerializeField] private GameObject WaypointB;
    
    void Start()
    {
        Animator = GetComponent<Animator>();
        Eagle = GetComponent<SpriteRenderer>();
        EagleBody = GetComponent<Rigidbody2D>();
        CurrentPoint = WaypointA.transform;
    }

    private void Update()
    {
        Vector2 point = CurrentPoint.position - transform.position;

        if (CurrentPoint == WaypointA.transform)
        {
            EagleBody.velocity = new Vector2(Speed, 0);
        }
        else
        {
            EagleBody.velocity = new Vector2(-Speed, 0);
        }

        if (Vector2.Distance(transform.position, CurrentPoint.position) < 0.5 && CurrentPoint == WaypointA.transform)
        {
            CurrentPoint = WaypointB.transform;
            Eagle.flipX = false;
        }
        else if (Vector2.Distance(transform.position, CurrentPoint.position) < 0.5 && CurrentPoint == WaypointB.transform)
        {
            CurrentPoint = WaypointA.transform;
            Eagle.flipX = true;
        }
    }
  
}
