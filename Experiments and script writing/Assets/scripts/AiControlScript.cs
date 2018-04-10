using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiControl : MonoBehaviour {

    public GameObject player;
    public GameObject AiCount[];

    //Initialization
    void start () {

      Debug.Log("Ai Initialized");

      AiCount = GameObject.FindGameObjectsWithTag("Ai");
    }

    //Called once per frame
    void Update () {

    }

}
