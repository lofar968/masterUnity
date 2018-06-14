using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate_In_Time : MonoBehaviour {
    public GameObject ThisObject;
    public GameObject Emmiter;
    public int EnabledFrameCount;
    public int FramesOfBeingEnabled;
    private bool isActive = false;
	
    void OnEnable()
    {
        isActive = true;
        EnabledFrameCount = 0;
    }

	// Update is called once per frame
	void FixedUpdate () {
		if(isActive)
        {
            ++EnabledFrameCount;
            if (EnabledFrameCount > FramesOfBeingEnabled)
            {
                ThisObject.SetActive(false);
                Emmiter.SendMessage("Turn");
            }
        }
	}
}
