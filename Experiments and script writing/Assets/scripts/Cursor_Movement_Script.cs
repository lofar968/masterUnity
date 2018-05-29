using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursor_Movement_Script : MonoBehaviour {
    
    public Vector3 OriginalPosition = new Vector3(0, 0, 0);
    public Vector3 added_transform = new Vector3(0, 0, 0);
    public Vector3 transfrom = new Vector3(0, 0, 0);
    public Slider Sens_slider;
    public float DMP = 1;
    public float multiply_DMP_by = 1;
    public float addToPrevious = 0;
    public float MultiplyAllBy = 1;
    public float ShipMaxTurnSpeed;
    private GameObject PlayerShip;

    void Start()
    {
        OriginalPosition = GetComponent<RectTransform>().anchoredPosition;
        Sens_slider.onValueChanged.AddListener(delegate { Change_sens_2(); });
        PlayerShip = GameObject.FindGameObjectWithTag("PlayerEntity");
        ShipMaxTurnSpeed = PlayerShip.GetComponent<ShipControlScript>().TurnSpeed;
    }

    void Change_sens_2()
    {
        DMP = Sens_slider.value;
    }

    void Move_Crosshair(Vector3 addedTransform)
    {
        added_transform = -addedTransform;
        transfrom = (-addedTransform / (DMP * multiply_DMP_by / ShipMaxTurnSpeed)) + OriginalPosition;
        GetComponent<RectTransform>().anchoredPosition = transfrom; //move this call for GC<RT>(); into a private variable Start() call.
    }
}
