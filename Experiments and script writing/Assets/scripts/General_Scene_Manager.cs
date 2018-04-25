using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class General_Scene_Manager : MonoBehaviour {
    void Start()
    {
        GoToMainMenu();
    }
    void GoToMainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
    void PlayGame()
    {
        SceneManager.LoadScene("test");
    }
}
