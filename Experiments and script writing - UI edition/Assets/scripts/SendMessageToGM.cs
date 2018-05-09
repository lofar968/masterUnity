using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMessageToGM : MonoBehaviour {
    private GameObject GM;
	// Use this for initialization
	void Start () {
		GM = GameObject.FindGameObjectWithTag("GM");
    }
	void SendMessageToGM_LoadGame()
    {
        GM.SendMessage("PlayGame");
    }
}
