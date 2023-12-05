using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMovement : MonoBehaviour
{

    private Animator Animator;
    private SpriteRenderer Dog;
    private Transform CurrentPoint;
    private Rigidbody2D DogBody;

    [SerializeField] private float Speed;
    [SerializeField] private GameObject WaypointA;
    [SerializeField] private GameObject WaypointB;

    void Start()
    {
        Animator = GetComponent<Animator>();
        Dog = GetComponent<SpriteRenderer>();
        DogBody = GetComponent<Rigidbody2D>();
        CurrentPoint = WaypointA.transform;
    }

    private void Update()
    {
        Vector2 point = CurrentPoint.position - transform.position;

        if (CurrentPoint == WaypointA.transform)
        {
            DogBody.velocity = new Vector2(Speed, 0);
        }
        else
        {
            DogBody.velocity = new Vector2(-Speed, 0);
        }

        if (Vector2.Distance(transform.position, CurrentPoint.position) < 0.5 && CurrentPoint == WaypointA.transform)
        {
            CurrentPoint = WaypointB.transform;
            Dog.flipX = false;
        }
        else if (Vector2.Distance(transform.position, CurrentPoint.position) < 0.5 && CurrentPoint == WaypointB.transform)
        {
            CurrentPoint = WaypointA.transform;
            Dog.flipX = true;
        }
    }

}
