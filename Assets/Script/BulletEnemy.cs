using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField] private GameObject Player;

    [SerializeField] private float force;

    private Rigidbody2D bulletbody;
    private float timer;
    void Start()
    {
        bulletbody = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = Player.transform.position - transform.position;
        bulletbody.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    
   // void Update()
   // {
   //     timer += Time.deltaTime;

   //     if (timer > 5)
   //     {
   //         Destroy(gameObject);
   //     }
   // }

    //private void OnTriggerEnter2D(Collider2D collision)
   // {
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Destroy(gameObject);
      //  }
   // }
}
