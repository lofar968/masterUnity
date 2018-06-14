using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rendering_script : MonoBehaviour {
    public Renderer rend;
    public bool isActive = false;
    public int activeTimeInFrames = 0;
    public GameObject Real_Laser;
    public GameObject Emmiter;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = false;
    }

    void Activate()
    {
        isActive = true;
    }

    // Toggle the Object's visibility each second.
    void FixedUpdate()
    {
        if (isActive)
        {
            ++activeTimeInFrames;
            if (activeTimeInFrames <= 120)
                rend.enabled = (activeTimeInFrames % 60) - 30 <= 0;
            else if (activeTimeInFrames <= 180)
                rend.enabled = (activeTimeInFrames % 6) - 3 <= 0;
            else
            {
                rend.enabled = false;
                Emmiter.SendMessage("Stop_Turning");
            }
            if (activeTimeInFrames == 190)
            {
                Real_Laser.SetActive(true);
                activeTimeInFrames = 0;
                isActive = false;
            }
        }
    }
}
