using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    private int doesLevelExist;
    private int levelScore;

    [SerializeField] GameStatus gameStatus;
    [SerializeField] TextMeshProUGUI levelScoreText;

    // Start is called before the first frame update
    void Start()
    {
        levelScore = PlayerPrefs.GetInt("passedLevelScore");
        levelScoreText.text = levelScore.ToString();
    }

    public void handleLevelReset()
    {
        // if previous score of level is less than newly passed score,
        //then override new one(set new highest score to the level)
        doesLevelExist = PlayerPrefs.GetInt("level" + PlayerPrefs.GetInt("levelIndex"), 0);
        if (doesLevelExist < PlayerPrefs.GetInt("passedLevelScore"))
        {
            PlayerPrefs.SetInt("level" + PlayerPrefs.GetInt("levelIndex"),
                     PlayerPrefs.GetInt("passedLevelScore"));
        }
        // Reset passed Level score to 0 again
        PlayerPrefs.SetInt("passedLevelScore", 0);
        // Make next level available to play
        PlayerPrefs.SetInt("levelIndex", PlayerPrefs.GetInt("levelIndex") + 1);

        int levelExists = PlayerPrefs.GetInt("level" + PlayerPrefs.GetInt("levelIndex"), -1);
        if (levelExists == -1)
        {
            PlayerPrefs.SetInt("level" + PlayerPrefs.GetInt("levelIndex"), 0);
        }
    }

    // Go to the next level, but first save the data from current
    public void NextLevel()
    {
        handleLevelReset();
        SceneManager.LoadScene(PlayerPrefs.GetInt("levelIndex"));
    }

    // Load the same level again
    public void Retry()
    {
        PlayerPrefs.SetInt("passedLevelScore", 0);
        SceneManager.LoadScene(PlayerPrefs.GetInt("levelIndex"));
    }

    // Load home menu after if needed to save score from current level, then do it
    public void HomeMenu()
    {
        handleLevelReset();
        SceneManager.LoadScene("Start Menu");
    }
}
