using System.Collections;
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

    void Start()
    {
        m_RawImage = GetComponent<RawImage>(); //assigns mRI whatever RI object this is placed on
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
            }
            else
            {
                Time.timeScale = 0.0f;
                m_RawImage.texture = paused_texture; //makes image visible
                gameIsPaused = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}