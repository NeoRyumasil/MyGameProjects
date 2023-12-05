using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinLevel : MonoBehaviour
{
    private bool LevelComplete = false;
    private AudioSource WinSFX;

    [SerializeField] private Text Win;
    [SerializeField] private GameObject Panel;
    [SerializeField] private GameObject NextButton;
    [SerializeField] private GameObject MainMenuButton;
   
    private void Start()
    {
        WinSFX = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !LevelComplete)
        {
            WinSFX.Play();
            LevelComplete = true;
            NextButton.gameObject.SetActive(true);
            MainMenuButton.gameObject.SetActive(true);
            Panel.gameObject.SetActive(true);
            Win.text = "Level Complete!";
            Time.timeScale = 0;
        }
    }
}
