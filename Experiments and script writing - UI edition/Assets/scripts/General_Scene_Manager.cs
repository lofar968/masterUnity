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
        //Load scene =============================================================================================================================================================================
        SceneManager.LoadScene("test");  //    ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||
        //Find gameobjects =======================================================================================================================================================================
        Sense_S = GameObject.FindWithTag("Sensitivity_Slider").GetComponent<Slider>();  //     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||
        Sound_S = GameObject.FindWithTag("Sound_Slider").GetComponent<Slider>();       //      ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||
        Music_S = GameObject.FindWithTag("Music_Slider").GetComponent<Slider>();      //       ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||
        //Assign gameobject sliders saved values =================================================================================================================================================
        Sense_S.value = Sensitivity;      //   ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||
        Sound_S.value = Sound_vol;       //    ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||
        Music_S.value = Music_vol;      //     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||
        //Start observing sliders, such that when they change the saved value is updated =========================================================================================================
        Sense_S.onValueChanged.AddListener(delegate { Change_sens(); });     //   ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||
        Sound_S.onValueChanged.AddListener(delegate { Change_sound(); });   //    ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||
        Music_S.onValueChanged.AddListener(delegate { Change_music(); });  //     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||     ||
        //Spawn ship "ship_num" ==================================================================================================================================================================
    }
    void Change_sens()
    {
        Sensitivity = Sense_S.value;
    }
    void Change_sound()
    {
        Sound_vol = Sound_S.value;
    }
    void Change_music()
    {
        Music_vol = Music_S.value;
    }
}
