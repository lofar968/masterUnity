using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Save_or_Load_Sliders_Value : MonoBehaviour {

    public Slider ThisSlider;
    public string SaveAs;

	// Use this for initialization
	void Start () {
        ThisSlider.onValueChanged.AddListener(delegate { SaveNewValue(); });
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
