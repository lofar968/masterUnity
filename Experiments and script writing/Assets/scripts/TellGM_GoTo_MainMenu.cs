using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TellGM_GoTo_MainMenu : MonoBehaviour {
    private GameObject GM;
    void Start()
    {
        GM = GameObject.FindGameObjectWithTag("GM");
    }
    void Activate()
    {
        GM.SendMessage("GoToMainMenu");
    }
}
