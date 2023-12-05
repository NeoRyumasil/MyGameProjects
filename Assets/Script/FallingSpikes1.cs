using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpikes1 : MonoBehaviour
{
    private Rigidbody2D FSpike;
    void Start()
    {
        FSpike = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FSpike.isKinematic = false;
        }
    }
}
