using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpike : MonoBehaviour
{
    private Rigidbody2D FSpike;

    private bool Fallen = false;
    [SerializeField] private Transform Spawnpos;

    void Start()
    {
        FSpike = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Fallen == false)
        {
            FSpike.isKinematic = false;
            Fallen = true;
            Invoke("boom", 5);
        }
    }

    void boom()
    {
        this.transform.position = Spawnpos.transform.position;
        Fallen = false;
        FSpike.isKinematic = true;
    }

}

