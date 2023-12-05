using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    
    public void Level_1_button()
    {
        SceneManager.LoadScene(2);
    }
    
    public void Level_2_button()
    {
        SceneManager.LoadScene(3);
    }
    
    public void Level_3_button()
    {
        SceneManager.LoadScene(4);
    }
    
    public void Level_4_button()
    {
        SceneManager.LoadScene(5);
    }
    
    public void Level_5_button()
    {
        SceneManager.LoadScene(6);
    }

}
