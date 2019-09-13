using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    private int doesLevelExist;
    private int levelScore;

    [SerializeField] TextMeshProUGUI levelScoreText;

    // Start is called before the first frame update
    void Start()
    {
        levelScore = PlayerPrefs.GetInt("passedLevelScore");
        levelScoreText.text = levelScore.ToString();
        Debug.Log(PlayerPrefs.GetInt("level2"));
    }

    public void handleLevelReset()
    {
        doesLevelExist = PlayerPrefs.GetInt("level" + PlayerPrefs.GetInt("levelIndex"), 0);
        if (doesLevelExist < PlayerPrefs.GetInt("passedLevelScore"))
        {
            PlayerPrefs.SetInt("level" + PlayerPrefs.GetInt("levelIndex"),
                     PlayerPrefs.GetInt("passedLevelScore"));
        }
        PlayerPrefs.SetInt("passedLevelScore", 0);
        PlayerPrefs.SetInt("levelIndex", PlayerPrefs.GetInt("levelIndex") + 1);
        int levelExists = PlayerPrefs.GetInt("level" + PlayerPrefs.GetInt("levelIndex"), -1);
        if (levelExists == -1)
        {
            PlayerPrefs.SetInt("level" + PlayerPrefs.GetInt("levelIndex"), 0);
        }
    }

    public void NextLevel()
    {
        handleLevelReset();
        SceneManager.LoadScene(PlayerPrefs.GetInt("levelIndex"));
    }

    public void Retry()
    {
        PlayerPrefs.SetInt("passedLevelScore", 0);
        SceneManager.LoadScene(PlayerPrefs.GetInt("levelIndex"));
    }

    public void HomeMenu()
    {
        handleLevelReset();
        SceneManager.LoadScene("Start Menu");
    }
}
