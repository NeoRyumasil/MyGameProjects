using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    public GameObject Bullet;
    [SerializeField] private Transform BulletPos;
    [SerializeField] private float Parameter;
    [SerializeField] private AudioSource ShootSFX;

    private float timer;
    private GameObject Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); 
    }

    private void Update()
    {
        
        float distance = Vector2.Distance(transform.position, Player.transform.position);

        if (distance < Parameter)
        {
            timer += Time.deltaTime;

            if (timer > 1)
            {
                timer = 0;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Instantiate(Bullet, BulletPos.position, Quaternion.identity);
        ShootSFX.Play();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Parameter);
    }

}
