using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject CurrentTeleporter;

    [SerializeField] private AudioSource TeleSFX;

    void Update()
    {
        if (CurrentTeleporter != null)
        {
            transform.position = CurrentTeleporter.GetComponent<Teleporter>().GetDestination().position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            CurrentTeleporter = collision.gameObject;
            TeleSFX.Play();
        }
    }
 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == CurrentTeleporter)
            {
                CurrentTeleporter = null;
            }
        }
    }
   
}
