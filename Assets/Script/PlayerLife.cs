using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D RB2D;
    private Animator Animt;
    private Vector3 Spawn;

    [SerializeField] private AudioSource DeathSFX;
    [SerializeField] private AudioSource SpawnSFX;

    // Start is called before the first frame update
    private void Start()
    {
        Animt = GetComponent<Animator>();
        RB2D = GetComponent<Rigidbody2D>();
        Spawn = transform.position;        
    }

    private void OnCollisionEnter2D(Collision2D collision) // Kena Trap = Meninggal
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die() // Animasi Meninggal
    {
        DeathSFX.Play();
        RB2D.bodyType = RigidbodyType2D.Static;
        Animt.SetTrigger("Death");
    }

    private void OnTriggerEnter2D(Collider2D collision) //Respawn Point
    {
        if(collision.tag == "Respawn")
        {
            Spawn = transform.position;
        }
    }

    private void Restart()
    {
        transform.position = Spawn;
        RB2D.bodyType = RigidbodyType2D.Dynamic;
        SpawnSFX.Play();
        Animt.SetTrigger("Spawn");
    }
}
