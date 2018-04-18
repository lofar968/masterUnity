using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AiControlScript : MonoBehaviour {

    public int rotSpeed = 0;
    public GameObject player;
    public int AiCount;
    /*
    an example of an array: 
    private int[] print = new int[] { 5, 8, 3, 9 }; // yeah, C# will autofill array size if one is not explicitly given. This is normal as far as I know, but thought I'd mention it anyways.
    Debug.Log(print[#]); // # is anything between 0-3, ofc.
    */
    //Initialization
    void start () {
        //player = GameObject.FindWithTag("PlayerEntity");
        Debug.Log("Ai Initialized");
        Debug.Log(player);
      //AiCount = GameObject.FindGameObjectsWithTag("Ai");
    }

    //Called once per frame
    void Update () {

        /*
        if(GameObject.FindGameObjectsWithTag("Ai").Length > 0)
        {
            AiCount++;
        }*/
    }

    /*
    public void waveFinished ()
    {
        if (AiCount == 0)
        {
            //end game/ Return to titlescreen
        }
    } */

    private void FixedUpdate()
    {
        Vector3 playerDir = player.transform.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.up, playerDir, rotSpeed, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDir);
    }

}
