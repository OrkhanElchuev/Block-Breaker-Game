using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Loading Start Menu in case of pressing Home button
    public void HomeButton()
    {
        SceneManager.LoadScene("Start Menu");
    }

    // Loading the same level in case of pressing retry button 
    public void RetryGameButton()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("levelIndex", 1));
    }
}
