using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendMessageToGM : MonoBehaviour {
    private GameObject GM;
    public GameObject TestingGameObject;
	// Use this for initialization
	void Start () {
		GM = GameObject.FindGameObjectWithTag("GM");
        TestingGameObject.SendMessage("Message");
    }
	void SendMessageToGM_LoadGame()
    {
        GM.SendMessage("PlayGame");
    }

    //TESTING STUFF |----------------------------------------------------------------------------------------------------------------------------


}
