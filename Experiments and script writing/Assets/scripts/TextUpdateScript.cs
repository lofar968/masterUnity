using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextUpdateScript : MonoBehaviour
{
    private float Speed = 0;
    //void UpdateSpeedText(int NewSpeed)
    //{
    //    scoreText.text = NewSpeed + "m/s";
    //}
    // Use this for initialization
    public GameObject PlayerEntity;
    Text AssignedText;
    void Start()
    {
        ShipControlScript.OnSpeedUpdate += HandleSpeedUpdate; ;
        AssignedText = GetComponent<Text>();
    }
    void HandleSpeedUpdate(float Speed2)
    {
        Speed = Speed2;
    }
    // Update is called once per frame
    void Update()
    {
        AssignedText.text = "Speed" + Speed + "m/s";
    }
}
