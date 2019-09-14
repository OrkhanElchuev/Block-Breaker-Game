using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResetMenu : MonoBehaviour
{
    public void BackToStartMenuButton()
    {
        SceneManager.LoadScene("Start Menu");
    }

    // Ingame hard reset button, deleting all saved data in player preferences: levels, scores, etc.
    public void ResetButton()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("levelIndex", 1);
        PlayerPrefs.SetInt("level" + PlayerPrefs.GetInt("levelIndex"), 0);
    }
}
