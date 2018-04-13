using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiControl : MonoBehaviour {

    public GameObject player;
    public int[] AiCount; //Yeah, this is how you declare arrays in C#. Don't ask me why, but it is a bit annoying to remember.
    /*
    an example of an array: 
    private int[] print = new int[] { 5, 8, 3, 9 }; // yeah, C# will autofill array size if one is not explicitly given. This is normal as far as I know, but thought I'd mention it anyways.
    Debug.Log(print[#]); // # is anything between 0-3, ofc.
    */
    //Initialization
    void start () {
      Debug.Log("Ai Initialized");

      AiCount = GameObject.FindGameObjectsWithTag("Ai");
    }

    //Called once per frame
    void Update () {

    }

    public void waveFinished ()
    {
        if (AiCount == 0)
        {
            //end game/ Return to titlescreen
        }
    }

}
