using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsMenu : MonoBehaviour
{
    public void BackToStartMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }

    public void SelectLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
