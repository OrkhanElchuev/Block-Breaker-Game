using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    [SerializeField] int breakableItems; // for debugging purposes
    [SerializeField] Ball ball;
    [SerializeField] GameStatus gameStatusObject;
    
    public void ResetLevelIndex()
    {
        PlayerPrefs.SetInt("levelIndex", SceneManager.GetActiveScene().buildIndex);
    }

    // Reset the level index to current index on start of level
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

    public void ItemDestroyed()
    {
        // decrement the amount of breakable items
        breakableItems--;
        // all breakable items are destroyed set levelPassed to true, get current level score
        // load Win menu after short delay
        if(breakableItems <= 0)
        {
            PlayerPrefs.SetInt("levelPassed", 1);
            PlayerPrefs.SetInt("passedLevelScore", gameStatusObject.GetCurrentScore());
            // delay is created for being able to see the animation of last destroyed item
            Invoke("LoadWinMenu", 0.3f);
        }
    }
}
