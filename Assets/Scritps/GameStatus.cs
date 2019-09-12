﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 21;
    [SerializeField] TextMeshProUGUI scoreText;
    //[SerializeField] bool isAutoPlayEnabled;
    
    // state variables
    [SerializeField] int currentScore = 0;
    private int currentLevelIndex;

    // Start is called before the first frame update
    private void Start()
    {
        scoreText.text = currentScore.ToString();
        Debug.Log(PlayerPrefs.GetInt("levelIndex"));
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlock;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    /*public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }*/

    public void SetCurrentScore(int currentScore)
    {
        this.currentScore = currentScore;
    }

    public int GetCurrentScore()
    {
        return this.currentScore;
    }
}