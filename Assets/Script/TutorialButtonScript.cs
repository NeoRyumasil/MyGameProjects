using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialButtonScript : MonoBehaviour
{
    public void Tutorial()
    {
        SceneManager.LoadScene(1);
    }
}
