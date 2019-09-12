using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void HomeButton()
    {
        SceneManager.LoadScene("Start Menu");
    }

    public void RetryGameButton()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("levelIndex", 1));
    }
}
