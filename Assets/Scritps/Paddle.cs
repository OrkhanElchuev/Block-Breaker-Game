using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] float normalizedPositionLeftX = 1.0f;
    [SerializeField] float normalizedPositionRightX = 14.7f;
    [SerializeField] float normalizedPositionY = 0.28f;
    [SerializeField] float minX = 0.5f;
    [SerializeField] float maxX = 15.0f;

    // Variables
    GameStatus theGameSession;
    Ball theBall;
    GameObject paddlePos;

    // Start is called before the first frame update
    void Start()
    {
        theGameSession = FindObjectOfType<GameStatus>();
        theBall = FindObjectOfType<Ball>();
    }

    // To avoid paddle from getting stuck in the walls
    void Update()
    {
        // if position is out of boundaries then bring the paddle back to the play board
       if(transform.position.x < minX)
        {
          transform.position = new Vector2(normalizedPositionLeftX, normalizedPositionY);
        }
       
       if(transform.position.x > maxX)
        {
            transform.position = new Vector2(normalizedPositionRightX, normalizedPositionY);
        }
    }
}
