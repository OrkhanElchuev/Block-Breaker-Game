 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPaddle : MonoBehaviour
{
    [SerializeField] float moveSpeed = 300;
    [SerializeField] GameObject character;

    // variables
    private Rigidbody2D characterBody;
    private float ScreenWidth;

    // Start is called before the first frame update
    void Start()
    {
        ScreenWidth = Screen.width;
        characterBody = character.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        DetermineDirectionAndMove();
    }

    public void DetermineDirectionAndMove()
    {
        int i = 0;
        while (i < Input.touchCount)
        {   
            // Buttons are covering half of the screen
            // Move to the right if right button is pressed
            if (Input.GetTouch(i).position.x > ScreenWidth / 2)
            {
                MovePaddle(1.0f);
            }
            // Move to the left if left button is pressed
            if (Input.GetTouch(i).position.x < ScreenWidth / 2)
            {
                MovePaddle(-1.0f);
            }
            ++i;
        }
    }

    // For being able to test the game on engine by using left and right arrows
    void FixedUpdate()
    {
    #if UNITY_EDITOR
        MovePaddle(Input.GetAxis("Horizontal"));
    #endif
    }

    // Moving paddle
    private void MovePaddle(float horizontalInput)
    {
        characterBody.AddForce(new Vector2(horizontalInput * moveSpeed * Time.deltaTime, 0));
    }
}
