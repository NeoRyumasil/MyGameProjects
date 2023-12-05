using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSpikeRespawnManager : MonoBehaviour
{
    Rigidbody2D Fspike;

    void Start()
    {
        Fspike = GetComponent<Rigidbody2D>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Spawner.Instance.StartCoroutine("SpawnTheObject", new Vector2 (transform.position.x , transform.position.y));
            Destroy(gameObject, 2f);

        }
    }
}
