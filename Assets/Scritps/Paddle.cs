using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] float minX = -2f;
    [SerializeField] float maxX = 17f;
    [SerializeField] float screenWidthInUnits = 20f;

    // cached references
    GameStatus theGameSession;
    Ball theBall;

    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<GameStatus>();
        theBall = FindObjectOfType<Ball>();
    }
}
