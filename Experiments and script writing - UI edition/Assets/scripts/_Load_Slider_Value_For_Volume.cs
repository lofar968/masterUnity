using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _Load_Slider_Value_For_Volume : MonoBehaviour {

    public string ValueToLoad;
    private AudioSource AS;

    void OnEnable()
    {
        AS = GetComponent<AudioSource>();
        AS.volume = PlayerPrefs.GetFloat(ValueToLoad,1);
    }
}
