﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPaddle : MonoBehaviour
{
    [SerializeField] float moveSpeed = 300;
    [SerializeField] GameObject character;
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
        int i = 0;
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > ScreenWidth / 2)
            {
                MovePaddle(1.0f);
            }
            if (Input.GetTouch(i).position.x < ScreenWidth / 2)
            {
                MovePaddle(-1.0f);
            }
            ++i;
        }
    }

    void FixedUpdate()
    {
    #if UNITY_EDITOR
        MovePaddle(Input.GetAxis("Horizontal"));
    #endif
    }

    private void MovePaddle(float horizontalInput)
    {
        characterBody.AddForce(new Vector2(horizontalInput * moveSpeed * Time.deltaTime, 0));
    }
}
