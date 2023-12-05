using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    public GameObject Player;

    public float force;
    private float Timer;

    private Rigidbody2D BulletBody;

    private void Start()
    {
        BulletBody = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = Player.transform.position - transform.position;
        BulletBody.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float Rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, Rotation + 90);
  
    }

    private void Update()
    {
        Timer += Time.deltaTime;

        if(Timer > 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Terrain"))
        {
            Destroy(gameObject);
        }
    }
}
