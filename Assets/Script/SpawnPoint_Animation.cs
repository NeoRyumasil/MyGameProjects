using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint_Animation : MonoBehaviour
{
    private Animator AnimT;

    [SerializeField] AudioSource CheckSFX;

    private bool tagged;
    void Start()
    {
        AnimT = GetComponent<Animator>();
        tagged = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && tagged == false)
        {
            AnimT.SetTrigger("Collide");
            Invoke("Flagging", 1);
            CheckSFX.Play();
            tagged = true;
        }

        else if (collision.gameObject.CompareTag("Player") && tagged == true)
        {
            tagged = true;
        }
    }

    void Flagging()
    {
        AnimT.SetTrigger("Flag");
    }
}
