using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    [SerializeField] int breakableItems; // Serialized for debugging purposes
    [SerializeField] Ball ball;
    // cached reference
    SceneLoader sceneloader;
    [SerializeField] GameStatus gameStatusObject;

    public void ResetLevelIndex()
    {
        PlayerPrefs.SetInt("levelIndex", SceneManager.GetActiveScene().buildIndex);
    }

    private void Start()
    {
        ResetLevelIndex();
    }

    public void CountItems()
    {
        breakableItems++;
    }
    
    public void LoadWinMenu()
    {
        SceneManager.LoadScene("Win Menu");
    }

    public void DestroyingDelayedBall()
    {
        ball.DestroyMyself();
    }

    public void ItemDestroyed()
    {
        breakableItems--;
        if(breakableItems <= 0)
        {
            PlayerPrefs.SetInt("levelPassed", 1);
            PlayerPrefs.SetInt("passedLevelScore", gameStatusObject.GetCurrentScore());
            Invoke("DestroyingDelayedBall", 0.1f);
            Invoke("LoadWinMenu", 0.5f);
        }
    }
}
