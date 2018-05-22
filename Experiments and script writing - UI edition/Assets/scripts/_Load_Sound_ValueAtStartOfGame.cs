using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _Load_Sound_ValueAtStartOfGame : MonoBehaviour {
    private Slider Sound_Slider;
    private AudioSource AS;
	// Use this for initialization
	void Start () {
		AS = GetComponent<AudioSource>();
        Sound_Slider = GameObject.FindWithTag("Sound_Slider").GetComponent<Slider>();
        AS.volume = Sound_Slider.value;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
