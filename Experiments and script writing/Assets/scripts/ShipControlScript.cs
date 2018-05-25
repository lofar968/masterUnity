using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShipControlScript : MonoBehaviour {
    //||-----------||-----------||-----------||-----------||-----------||-----------||-----------||-----------||-----------||-----------||-----------||-----------||-----------||-----------||-----------||
    public int facesX = 0;
    public int facesY = 0;
    public int facesZ = 0;
    public char UpwardsAxisIs_xyz = 'y';
    public int SidewaysAxisIs_posNeg = 1;
    public int UpwardsAxisIs_posNeg = 1;
    public char Answer_Faces_Vars = ' ';
    public float RotateSpeed = 1;
    public float TurnSpeed = 1;
    private Rigidbody rb = new Rigidbody();
    public float MaxSpeed = 0;
    public float Accelleration = 0;
    public float CurrentSpeed = 0;
    //private float oldSpeed = 0;
    //private Vector3 tempvelocity = Vector3.zero;
    public float Mouse_X_Distance = 0;
    public float Mouse_Y_Distance = 0;
    public float Delta_Mouse_Position = 1;
    private float Spin_Direction = 0;
    private float noseElevation_Direction = 0;
    private float Turn_Direction = 0;
    private bool Was0 = true;

    private Vector3 Mouse_Vector3_Distance = new Vector3();

    public Slider Sens_slider;

    public GameObject crosshair;

    public delegate void SpeedUpdate(float Speed2);
    public static event SpeedUpdate OnSpeedUpdate;

    //||-----------||-----------||-----------||-----------||-----------||-----------||-----------||-----------||-----------||-----------||-----------||-----------||-----------||-----------||-----------||
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Sens_slider.onValueChanged.AddListener(delegate { Change_sens(); }); // NEW NEW NEW NEW NEW NEW NEW NEW NEW NEW NEW NEW NEW NEW NEW NEW NEW NEW NEW NEW NEW NEW NEW NEW NEW NEW NEW NEW 
    }
    void Change_sens()
    {
        Delta_Mouse_Position = Sens_slider.value;
    } // NO LONGER NEW | NO LONGER NEW | NO LONGER NEW | NO LONGER NEW | NO LONGER NEW | NO LONGER NEW | NO LONGER NEW | NO LONGER NEW | NO LONGER NEW | NO LONGER NEW | NO LONGER NEW | NO LONGER NEW
    void GetMouseInput()
    {
        Mouse_X_Distance += Input.GetAxis("Mouse X");
        Mouse_Y_Distance += Input.GetAxis("Mouse Y");

        if(Mouse_X_Distance <= -Delta_Mouse_Position)
        {
            Turn_Direction = -1;
            Mouse_X_Distance += Delta_Mouse_Position;
        }
        else if(Mouse_X_Distance < Delta_Mouse_Position) //so -ΔMouse < MouseX < ΔMouse
        {
            Turn_Direction = Mouse_X_Distance / Delta_Mouse_Position; //returns pos if MouseX is pos, neg if MouseX is neg.
            Mouse_X_Distance = 0;
        }
        else //so ΔMouse < MouseX
        {
            Turn_Direction = 1;
            Mouse_X_Distance -= Delta_Mouse_Position;
        }
        //Now it is all the same for handeling MouseY ||-------||-------||-------||-------||-------||-------||-------||-------||-------||-------||-------||-------||-------||-------||-------||
        if (Mouse_Y_Distance <= -Delta_Mouse_Position)
        {
            noseElevation_Direction = -1;
            Mouse_Y_Distance += Delta_Mouse_Position;
        }
        else if (Mouse_Y_Distance < Delta_Mouse_Position) //so -ΔMouse < MouseX < ΔMouse
        {
            noseElevation_Direction = Mouse_Y_Distance / Delta_Mouse_Position; //returns pos if MouseX is pos, neg if MouseX is neg.
            Mouse_Y_Distance = 0;
        }
        else //so ΔMouse < MouseX
        {
            noseElevation_Direction = 1;
            Mouse_Y_Distance -= Delta_Mouse_Position;
        }
        //||-------||-------||-------||-------||-------||-------||-------||-------||-------||-------||-------||-------||-------||-------||-------||-------||-------||-------||-------||-------||
    }
    float castToRadians(float deg) // DEGREES TO RAD DEGREES TO RAD DEGREES TO RAD DEGREES TO RAD DEGREES TO RAD DEGREES TO RAD DEGREES TO RAD DEGREES TO RAD DEGREES TO RAD DEGREES TO RAD DEGREES TO RAD
    {
        float rad = deg * Mathf.PI / 180;
        return rad;
    }
    float castToDegrees(float rad) // RAD TO DEGREES RAD TO DEGREES RAD TO DEGREES RAD TO DEGREES RAD TO DEGREES RAD TO DEGREES RAD TO DEGREES RAD TO DEGREES RAD TO DEGREES RAD TO DEGREES RAD TO DEGREES
    {
        float deg = rad * 180 / Mathf.PI;
        return deg;
    } 

    void SetShipVelocity() //VELOCITY VELOCITY VELOCITY VELOCITY VELOCITY VELOCITY VELOCITY VELOCITY VELOCITY VELOCITY VELOCITY VELOCITY VELOCITY VELOCITY VELOCITY VELOCITY VELOCITY VELOCITY VELOCITY 
    {
        int direction = 0;
        if (Input.GetKey(KeyCode.W))
            direction = 1;
        else if (Input.GetKey(KeyCode.S))
            direction = -1;
        else if (!Was0 && CurrentSpeed > -17 && CurrentSpeed < 17)
        {
            CurrentSpeed = 0;
            Was0 = true;
        }
        else if (CurrentSpeed < -17 || CurrentSpeed > 17)
            Was0 = false;
        CurrentSpeed += direction * Accelleration;

        if (CurrentSpeed > MaxSpeed)
            CurrentSpeed = MaxSpeed;
        if (CurrentSpeed < -MaxSpeed)
            CurrentSpeed = -MaxSpeed;

        if (facesZ == 1)
            rb.velocity = transform.forward * CurrentSpeed;
        if (facesZ == -1)
            rb.velocity = transform.forward * CurrentSpeed * -1;
        if (facesX == 1)
            rb.velocity = transform.right * CurrentSpeed;
        if (facesX == -1)
            rb.velocity = transform.right * CurrentSpeed * -1;
        if (facesY == 1)
            rb.velocity = transform.up * CurrentSpeed;
        if (facesY == -1)
            rb.velocity = transform.up * CurrentSpeed * -1;
    }
    void SetShipSpin() //SPIN SPIN SPIN SPIN SPIN SPIN SPIN SPIN SPIN SPIN SPIN SPIN SPIN SPIN SPIN SPIN SPIN SPIN SPIN SPIN SPIN SPIN SPIN SPIN SPIN SPIN SPIN SPIN SPIN SPIN SPIN SPIN SPIN SPIN SPIN
    {

        Spin_Direction = 0;
        if (Input.GetKey(KeyCode.Q))
            Spin_Direction = 1;
        else if (Input.GetKey(KeyCode.E))
            Spin_Direction = -1;

       /* 
        if (Input.GetKey(KeyCode.D))
            noseElevation_Direction = 1;
        else if (Input.GetKey(KeyCode.A))
            noseElevation_Direction = -1;

            if (Input.GetKey(KeyCode.C))
            Turn_Direction = 1;
        else if (Input.GetKey(KeyCode.Z))
            Turn_Direction = -1;
            */ //this is just backup code in case mouse input fails

        float XrotForce = 0;
        float YrotForce = 0;
        float ZrotForce = 0;
        { //block edits XYZ rot forces dependent on FacesT and UaxisIs vars
            if (facesX == 1 || facesX == -1)
            {
                XrotForce = Spin_Direction * RotateSpeed * facesX;
                if (UpwardsAxisIs_xyz == 'z') //IN THIS PART, THE DIRECTION SOMETHING IS FACING IMPLIES THE OPPOSITE AXIS ROTATION NEEDS TO BE APPLIED. ||-----||-----||-----||-----||-----||
                {   //sideways axis is y
                    ZrotForce = Turn_Direction * TurnSpeed * SidewaysAxisIs_posNeg;
                    //upwards axis is z
                    YrotForce = UpwardsAxisIs_posNeg * TurnSpeed * noseElevation_Direction;
                }
                else
                {   //Sideways axis is z
                    YrotForce = Turn_Direction * TurnSpeed * SidewaysAxisIs_posNeg;
                    //upwards axis is y
                    ZrotForce = UpwardsAxisIs_posNeg * TurnSpeed * noseElevation_Direction;
                }
            }
            else if (facesY == 1 || facesY == -1)
            {
                YrotForce = Spin_Direction * RotateSpeed * facesY;
                if (UpwardsAxisIs_xyz == 'x') //basically the same as above set ||-----||-----||-----||-----||-----||-----||-----||-----||-----||-----||-----||-----||-----||-----||-----||
                {
                    ZrotForce = Turn_Direction * TurnSpeed * SidewaysAxisIs_posNeg;
                    XrotForce = UpwardsAxisIs_posNeg * TurnSpeed * noseElevation_Direction;
                }
                else
                {
                    XrotForce = Turn_Direction * TurnSpeed * SidewaysAxisIs_posNeg;
                    ZrotForce = UpwardsAxisIs_posNeg * TurnSpeed * noseElevation_Direction;
                }
            }
            else //facesZ == 1 || -1
            {
                ZrotForce = Spin_Direction * RotateSpeed * facesZ;
                YrotForce = Spin_Direction * RotateSpeed * facesY;
                if (UpwardsAxisIs_xyz == 'x') //basically the same as above set ||-----||-----||-----||-----||-----||-----||-----||-----||-----||-----||-----||-----||-----||-----||-----||
                {
                    ZrotForce = Turn_Direction * TurnSpeed * SidewaysAxisIs_posNeg;
                    XrotForce = UpwardsAxisIs_posNeg * TurnSpeed * noseElevation_Direction;
                }
                else
                {
                    XrotForce = Turn_Direction * TurnSpeed * SidewaysAxisIs_posNeg;
                    ZrotForce = UpwardsAxisIs_posNeg * TurnSpeed * noseElevation_Direction;
                }
            }
        } //||--------------------------BLOCK END --------------------------||-------------------------- BLOCK END --------------------------||-------------------------- BLOCK END ---------------------||

        Vector3 RotationalForce = new Vector3(XrotForce, YrotForce, ZrotForce);
        rb.angularVelocity = new Vector3(0, 0, 0);
        rb.AddRelativeTorque(RotationalForce);//and here we have our relative spin proportions!

        float FinalRotSpeedX = rb.angularVelocity.x;
        float FinalRotSpeedY = rb.angularVelocity.y;
        float FinalRotSpeedZ = rb.angularVelocity.z;
        { //figure out FRS for each axis, dependant on FacesT vars
            if (facesX == 1 || facesX == -1)
            {
                FinalRotSpeedX *= RotateSpeed;
                FinalRotSpeedY *= TurnSpeed;
                FinalRotSpeedZ *= TurnSpeed;
            }
            if (facesY == 1 || facesY == -1)
            {
                FinalRotSpeedY *= RotateSpeed;
                FinalRotSpeedX *= TurnSpeed;
                FinalRotSpeedZ *= TurnSpeed;
            }
            if (facesZ == 1 || facesZ == -1)
            {
                FinalRotSpeedZ *= RotateSpeed;
                FinalRotSpeedY *= TurnSpeed;
                FinalRotSpeedX *= TurnSpeed;
            }
        }
        Vector3 FinalRotation = new Vector3(FinalRotSpeedX, FinalRotSpeedY, FinalRotSpeedZ);
        rb.angularVelocity = FinalRotation; // here is our final rotation
    }
    void SendSpeed()
    {
        if (OnSpeedUpdate != null)
            OnSpeedUpdate(CurrentSpeed);
    }
    
    
    // FixedUpdate is called once per physics frame
    void FixedUpdate() {
        SetShipVelocity();

        GetMouseInput();

        SetShipSpin();

        SendSpeed();

        Mouse_Vector3_Distance.x = Mouse_X_Distance;
        Mouse_Vector3_Distance.y = Mouse_Y_Distance;
        crosshair.SendMessage("Move_Crosshair",Mouse_Vector3_Distance);
        //mouse input = Input.GetAxis("Mouse X"). This is it! (int X = Input.GetAxis("Mouse X"); if X > 0 {/*turn*/; X -= /*some other number*/;} and same for Y!
    }
}
//you will need https://social.msdn.microsoft.com/Forums/vstudio/en-US/c14fd846-19b9-4e8a-ba6c-0b885b424439/is-c-working-with-degrees-or-radians?forum=netfxbcl to do sin/cos/tan etc. properly

/*
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursorvisiblitytoggle : MonoBehaviour
{
bool CursorIsVisible = true;
// Use this for initialization
void Start()
{

}

// Update is called once per frame
void Update()
{
    if (Input.GetKeyDown(KeyCode.Space))
    {
        if (CursorIsVisible)
        {
            Cursor.visible = false;
            CursorIsVisible = false;
        }
        else
        {
            Cursor.visible = true;
            CursorIsVisible = true;
        }
    }
}
}
 */
