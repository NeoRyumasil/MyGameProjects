using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D RB2D;
    private Animator Animtr;
    private SpriteRenderer SR;
    private BoxCollider2D coll;
    private bool movement;


    [SerializeField] private LayerMask JumpableGround;
    [SerializeField] private float MoveSpeed = 5;
    [SerializeField] private float JumpForce = 10;

    private enum MovementState { Idle, Running, Jumping, Falling }

    [SerializeField] private AudioSource JumpSFX;
    [SerializeField] private AudioSource SpawnSFX;

    // Start is called before the first frame update
    private void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        Animtr = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        movement = true;
    }

    // Update is called once per frame
    private void Update()
    { 
        float dirX = Input.GetAxisRaw("Horizontal"); // Untuk Jalan
        RB2D.velocity = new Vector2(dirX * MoveSpeed, RB2D.velocity.y); // Untuk Jalan Sambil Loncat

        if (Input.GetButtonDown("Jump") && IsGrounded()) //Untuk Loncat
        {
            JumpSFX.Play();
            RB2D.velocity = new Vector2(RB2D.velocity.x, JumpForce);
        }

        if (movement == true)
        {
            UpdateAnimation();
        }
        

    }

    private void UpdateAnimation()
    { 
        MovementState State;
        float dirX = Input.GetAxisRaw("Horizontal");
  
        if (dirX > 0) //Animasi Lari
        {
           State = MovementState.Running;
            SR.flipX = false;
        }
        else if (dirX < 0)
        {
            State = MovementState.Running;
            SR.flipX = true;
        }
        else
        {
           State = MovementState.Idle; // Animasi Diam
        }

        if (RB2D.velocity.y > .1) //Animasi Loncat
        {
            State = MovementState.Jumping;
        }
        else if (RB2D.velocity.y < -.1) // Animasi Jatuh
        {
           State = MovementState.Falling;
        }

        Animtr.SetInteger("State", (int)State);
    }

    private bool IsGrounded() //Supaya Gk Spam Loncat
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0, Vector2.down, 1, JumpableGround);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            MovementState State;
            State = MovementState.Idle;
            RB2D.bodyType = RigidbodyType2D.Static;
            movement = false;
            Animtr.SetInteger("State", (int)State);
        }
    }
}
