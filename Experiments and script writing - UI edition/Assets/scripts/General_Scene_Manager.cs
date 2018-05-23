using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class General_Scene_Manager : MonoBehaviour {
    public Slider Sound_S;
    public Slider Music_S;
    public Slider Sense_S;
    public GameObject Sound_O;
    public GameObject Music_O;
    public GameObject Sense_O;
    public GameObject pauseHandeler;
    public bool Playing_game = false;
    public bool In_MM = false;
    public byte ship_num = 0;
    public float Sensitivity = 1;
    public float Sound_vol = 1;
    public float Music_vol = 1;

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
        //Load scene ===============================================================================================================================================================================
        SceneManager.LoadScene("test");  //    ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||
        //Find gameobjects =========================================================================================================================================================================
        Sense_O = GameObject.FindWithTag("Sensitivity_Slider");      //    ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||
        Sound_O = GameObject.FindWithTag("Sound_Slider");           //     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||
        Music_O = GameObject.FindWithTag("Music_Slider");          //|     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||
        pauseHandeler = GameObject.FindWithTag("Pause_handeler"); //||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||
        Sense_S = Sense_O.GetComponent<Slider>();                // ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||
        Sound_S = Sound_O.GetComponent<Slider>();               //  ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||
        Music_S = Music_O.GetComponent<Slider>();              //   ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||
        //Do initalizing things with said GOs ======================================================================================================================================================
        Sense_S.value = Sensitivity;               // ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||
        Sound_S.value = Sound_vol;                //  ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||
        Music_S.value = Music_vol;               //   ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||
        pauseHandeler.SendMessage("Continue");  //    ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     
        //Start observing sliders, such that when they change the saved value is updated ===========================================================================================================

        //Spawn ship "ship_num" ====================================================================================================================================================================
    }
}
