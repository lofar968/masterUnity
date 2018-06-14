using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Activating_Script : MonoBehaviour {
    public GameObject laserPointer;
    public int TimeInFrames = 500;
	
	// Update is called once per frame
	void Update () {
        ++TimeInFrames;
        if(TimeInFrames == 600)
        {
            laserPointer.SendMessage("Activate");
            TimeInFrames = 0;
        }
	}
}
