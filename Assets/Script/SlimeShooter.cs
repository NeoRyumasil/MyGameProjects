using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeShooter : MonoBehaviour
{
    public float ShootRange;
    private float Distance;

    public GameObject Bullet;
    public GameObject BulletParent;

    [SerializeField] private GameObject Player;
    void Update()
    {
        Distance = Vector2.Distance(transform.position, Player.transform.position);
        Vector2 direction = Player.transform.position - transform.position;

        if (Distance <= ShootRange)
        {
            Instantiate(Bullet, BulletParent.transform.position, Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ShootRange);
    }
}
