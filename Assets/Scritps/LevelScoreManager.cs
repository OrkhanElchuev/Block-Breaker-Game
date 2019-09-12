using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] levelScore = new TextMeshProUGUI[21];
    [SerializeField] Button[] Buttons = new Button[21];
    private int[] levelExists = new int[21]; 

    private void Start()
    {
        ButtonsManagement();
    }

    private void ButtonsManagement()
    {
        // All buttons are not interactable (levels are closed)
        for(int i = 1; i < Buttons.Length; i++)
        {
            Buttons[i].interactable = false;
        }

        // All levels are checked for existence
        for(int i = 1; i < levelExists.Length; i++)
        {
            levelExists[i] = PlayerPrefs.GetInt("level" + i, -1);
        }
        
        // If level exists score is bigger or equal to 0 update the score on level
        for(int i = 1; i < levelExists.Length; i++)
        {
            if(levelExists[i] >= 0)
            {
                levelScore[i].text = levelExists[i].ToString();
                Buttons[i].interactable = true;
            }
        }
    }
}
