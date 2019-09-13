using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{

    private int levelIndex; 

    private void Start()
    {
        levelIndex = PlayerPrefs.GetInt("levelIndex", 1);
        if (PlayerPrefs.GetInt("levelIndex") == 0)
        {
            PlayerPrefs.SetInt("levelIndex", 1);
            PlayerPrefs.SetInt("level1", 0);
        }
    }

    // Loading playing Scene
    public void LoadPlayScene()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("levelIndex"));
        Debug.Log(PlayerPrefs.GetInt("levelIndex"));
    }

    // Loading Info Scene
    public void LoadInformationScene()
    {
        SceneManager.LoadScene("Information Menu");
    }

    public void LoadLevelSelectionMenu()
    {
        SceneManager.LoadScene("Level Selector");
    }

    // Ingame hard reset button, deleting all saved data in player preferences: levels, scores, etc.
    public void ResetButton()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("levelIndex", 1);
        PlayerPrefs.SetInt("level" + PlayerPrefs.GetInt("levelIndex"), 0);
    }

    // Quitting game
    public void QuitGame()
    {
        Application.Quit();
    }
}
