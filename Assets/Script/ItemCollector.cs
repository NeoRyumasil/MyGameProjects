using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int Bananas = 0;

    [SerializeField] private Text BananaScore;
    [SerializeField] private AudioSource CollectSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana")) // Score 
        {
            CollectSFX.Play();
            Destroy(collision.gameObject);
            Bananas++;
            BananaScore.text = "Bananas : " + Bananas;
        }
    }
}
