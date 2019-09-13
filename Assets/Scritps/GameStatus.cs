using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    // Configuration parameters
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 21;
    [SerializeField] TextMeshProUGUI scoreText;
    
    // Variables
    [SerializeField] int currentScore = 0;
    private int currentLevelIndex;
    private int health = 3;

    // Handling health decrementing
    public int DecreaseHealth()
    {
        health--;
        return health;
    }

    // Start is called before the first frame update
    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    // Adding points to current score of level converting value to String
    public void AddToScore()
    {
        currentScore += pointsPerBlock;
        scoreText.text = currentScore.ToString();
    }

    // Destroying GameStatus object
    public void ResetGame()
    {
        Destroy(gameObject);
    }

    // Setter for current Score
    public void SetCurrentScore(int currentScore)
    {
        this.currentScore = currentScore;
    }

    // Getter for current Score
    public int GetCurrentScore()
    {
        return this.currentScore;
    }
}
