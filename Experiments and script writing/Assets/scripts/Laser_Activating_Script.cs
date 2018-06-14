using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Activating_Script : MonoBehaviour {
    public GameObject laserPointer;
    public int TimeInFrames = 500;
    public int CycleTime = 600;
	
	void FixedUpdate () {
        ++TimeInFrames;
        if(TimeInFrames == CycleTime)
        {
            laserPointer.SendMessage("Activate");
            TimeInFrames = 0;
        }
	}
}
