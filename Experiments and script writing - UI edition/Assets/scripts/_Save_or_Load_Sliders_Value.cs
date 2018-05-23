using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _Save_or_Load_Sliders_Value : MonoBehaviour {

    public Slider ThisSlider;
    public string SaveAs;
    public float DefaultLoadedValue;
    public GameObject Slider_related_object;
    public string SendTo_SRO_ToUpdate;
    public float SendTo_SRO_argument = 0;
    public bool SendArgument = false;
	// Use this for initialization
	void Start () {
        ThisSlider.onValueChanged.AddListener(delegate { SaveNewValue(); });
        ThisSlider.value = PlayerPrefs.GetFloat(SaveAs,DefaultLoadedValue);

        if (Slider_related_object != null)
        {
            if(!SendArgument)
                Slider_related_object.SendMessage(SendTo_SRO_ToUpdate);
            else
                Slider_related_object.SendMessage(SendTo_SRO_ToUpdate,SendTo_SRO_argument);
        }
    }
    void awake()
    {
        ThisSlider.value = PlayerPrefs.GetFloat(SaveAs, DefaultLoadedValue);
    }

    void SaveNewValue()
    {
        PlayerPrefs.SetFloat(SaveAs,ThisSlider.value);
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
