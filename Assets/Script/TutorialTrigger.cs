using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTrigger : MonoBehaviour
{

    [SerializeField] private GameObject TutorialText;
    [SerializeField] private GameObject TutorPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TutorPanel.gameObject.SetActive(true);
        TutorialText.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TutorPanel.gameObject.SetActive(false);
        TutorialText.gameObject.SetActive(false);
    }
}
