﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement; // for Time.Timescale
using UnityEngine.UI; // for RawImage and Texture

public class PauseMenuControl : MonoBehaviour {
    // Update is called once per frame
    private bool gameIsPaused = false;

    RawImage m_RawImage;
    public Texture blank_texture;
    public Texture paused_texture;
    public GameObject[] pauseButton = new GameObject[3]; // if there wind up being more than 3 bts, CHANGE THIS #. Seems I may be able to in Unity.
    
    void Start()
    {
        m_RawImage = GetComponent<RawImage>(); //assigns mRI whatever RI object this is placed on
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        foreach (GameObject element in pauseButton)
        {
            element.SetActive(false);
        }
    }
    public void Continue()
    {
        Time.timeScale = 1.0f;
        m_RawImage.texture = blank_texture; //makes image invisible
        gameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        foreach (GameObject element in pauseButton)
        {
            element.SetActive(false);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused) 
            {
                Time.timeScale = 1.0f;
                m_RawImage.texture = blank_texture; //makes image invisible
                gameIsPaused = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;

                foreach (GameObject element in pauseButton)
                {
                    element.SetActive(false);
                }
            }
            else
            {
                Time.timeScale = 0.0f;
                m_RawImage.texture = paused_texture; //makes image visible
                gameIsPaused = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                foreach (GameObject element in pauseButton)
                {
                    element.SetActive(true);
                }
            }
        }
    }
}