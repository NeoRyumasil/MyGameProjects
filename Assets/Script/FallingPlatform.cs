using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{

    private float falldelay = 1;
    private bool fallen;

    [SerializeField] private Rigidbody2D platform;
    [SerializeField] private Transform Spawnpos;

    private void Start()
    {
        fallen = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && fallen == false)
        {
            StartCoroutine(Fall());
            fallen = true;
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(falldelay);
        platform.bodyType = RigidbodyType2D.Dynamic;
        Invoke("Spawn", 5);
    }

    void Spawn()
    {
        this.transform.position = Spawnpos.transform.position;
        platform.bodyType = RigidbodyType2D.Static;
        fallen = false;
    }
}
