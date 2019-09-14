using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLevel : MonoBehaviour
{
    private int lastLevelScore = 9178;

    // On destroy of last level load "Congratulations" scene
    private void OnDestroy()
    {
        // Check if level is passed (9178) is the score for the last level
        if(PlayerPrefs.GetInt("passedLevelScore") >= lastLevelScore)
        {
            SceneManager.LoadScene("Final Level Menu");
        }
    }
}
