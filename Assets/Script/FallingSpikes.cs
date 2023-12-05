using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpikes : MonoBehaviour
{
    private Rigidbody2D SpikeBox;
    private Animator AnimtT;

    [SerializeField] private Transform Spawnpos;
    [SerializeField] private AudioSource HitGroundSFX;

    private bool fallen;

    void Start()
    {
        SpikeBox = GetComponent<Rigidbody2D>();
        AnimtT = GetComponent<Animator>();
        fallen = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && fallen == false)
        {
            SpikeBox.isKinematic = false;
            AnimtT.SetBool("Fall", true);
            AnimtT.SetBool("Hit Ground", false);
            HitGroundSFX.Play();
            fallen = true;
            Invoke("Spawn", 3);
        }
    }

    void Spawn()
    {
        this.transform.position = Spawnpos.transform.position;
        SpikeBox.isKinematic = true;
        AnimtT.SetBool("Fall", false);
        fallen = false;
    }

    /**private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            AnimtT.SetBool("Fall", false);
            AnimtT.SetBool("Hit Ground", true);
        }
    }**/
}
