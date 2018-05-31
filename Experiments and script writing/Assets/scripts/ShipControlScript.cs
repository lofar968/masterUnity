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
        if (Detect_input("Forward Thrust"))
            direction = 1;
        else if (Detect_input("Backwards Thrust"))
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
        if (Detect_input("Roll left"))
            Spin_Direction = 1;
        else if (Detect_input("Roll right"))
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

    bool Detect_input(string KeyName)
    {
        KeyName = PlayerPrefs.GetString(KeyName); // all the comments are from a find and replace, that I did to make things easier
        if (Input.GetKey(KeyCode.Q) && KeyName == "Q")
            return true; //"Q";
        else if (Input.GetKey(KeyCode.W) && KeyName == "W")
            return true; //"W";
        else if (Input.GetKey(KeyCode.E) && KeyName == "E")
            return true; //"E";
        else if (Input.GetKey(KeyCode.R) && KeyName == "R")
            return true; //"R";
        else if (Input.GetKey(KeyCode.T) && KeyName == "T")
            return true; //"T";
        else if (Input.GetKey(KeyCode.Y) && KeyName == "Y")
            return true; //"Y";
        else if (Input.GetKey(KeyCode.U) && KeyName == "U")
            return true; //"U";
        else if (Input.GetKey(KeyCode.I) && KeyName == "I")
            return true; //"I";
        else if (Input.GetKey(KeyCode.O) && KeyName == "O")
            return true; //"O";
        else if (Input.GetKey(KeyCode.P) && KeyName == "P")
            return true; //"P";
        else if (Input.GetKey(KeyCode.A) && KeyName == "A")
            return true; //"A";
        else if (Input.GetKey(KeyCode.S) && KeyName == "S")
            return true; //"S";
        else if (Input.GetKey(KeyCode.D) && KeyName == "D")
            return true; //"D";
        else if (Input.GetKey(KeyCode.F) && KeyName == "F")
            return true; //"F";
        else if (Input.GetKey(KeyCode.G) && KeyName == "G")
            return true; //"G";
        else if (Input.GetKey(KeyCode.H) && KeyName == "H")
            return true; //"H";
        else if (Input.GetKey(KeyCode.J) && KeyName == "J")
            return true; //"J";
        else if (Input.GetKey(KeyCode.K) && KeyName == "K")
            return true; //"K";
        else if (Input.GetKey(KeyCode.L) && KeyName == "L")
            return true; //"L";
        else if (Input.GetKey(KeyCode.Z) && KeyName == "Z")
            return true; //"Z";
        else if (Input.GetKey(KeyCode.X) && KeyName == "X")
            return true; //"X";
        else if (Input.GetKey(KeyCode.C) && KeyName == "C")
            return true; //"C";
        else if (Input.GetKey(KeyCode.V) && KeyName == "V")
            return true; //"V";
        else if (Input.GetKey(KeyCode.B) && KeyName == "B")
            return true; //"B";
        else if (Input.GetKey(KeyCode.N) && KeyName == "N")
            return true; //"N";
        else if (Input.GetKey(KeyCode.M) && KeyName == "M")
            return true; //"M";
        else if (Input.GetKey(KeyCode.Backspace) && KeyName == "Backspace")
            return true; //"Backspace";
        else if (Input.GetKey(KeyCode.Delete) && KeyName == "Delete")
            return true; //"Delete";
        else if (Input.GetKey(KeyCode.Tab) && KeyName == "Tab")
            return true; //"Tab";
        else if (Input.GetKey(KeyCode.Return) && KeyName == "Return")
            return true; //"Return";
        else if (Input.GetKey(KeyCode.Space) && KeyName == "Space")
            return true; //"Space";
        else if (Input.GetKey(KeyCode.W) && KeyName == "W")
            return true; //"W";
        else if (Input.GetKey(KeyCode.Keypad0) && KeyName == "Numpad0")
            return true; //"Numpadfalse";
        else if (Input.GetKey(KeyCode.Keypad1) && KeyName == "Numpad1")
            return true; //"Numpadtrue";
        else if (Input.GetKey(KeyCode.Keypad2) && KeyName == "Numpad2")
            return true; //"Numpad2";
        else if (Input.GetKey(KeyCode.Keypad3) && KeyName == "Numpad3")
            return true; //"Numpad3";
        else if (Input.GetKey(KeyCode.Keypad4) && KeyName == "Numpad4")
            return true; //"Numpad4";
        else if (Input.GetKey(KeyCode.Keypad5) && KeyName == "Numpad5")
            return true; //"Numpad5";
        else if (Input.GetKey(KeyCode.Keypad6) && KeyName == "Numpad6")
            return true; //"Numpad6";
        else if (Input.GetKey(KeyCode.Keypad7) && KeyName == "Numpad7")
            return true; //"Numpad7";
        else if (Input.GetKey(KeyCode.Keypad8) && KeyName == "Numpad8")
            return true; //"Numpad8";
        else if (Input.GetKey(KeyCode.Keypad9) && KeyName == "Numpad9")
            return true; //"Numpad9";
        else if (Input.GetKey(KeyCode.KeypadPeriod) && KeyName == "Numpad.")
            return true; //"Numpad.";
        else if (Input.GetKey(KeyCode.KeypadDivide) && KeyName == "Numpad/")
            return true; //"Numpad/";
        else if (Input.GetKey(KeyCode.KeypadMultiply) && KeyName == "Numpad*")
            return true; //"Numpad*";
        else if (Input.GetKey(KeyCode.KeypadMinus) && KeyName == "Numpad-")
            return true; //"Numpad-";
        else if (Input.GetKey(KeyCode.KeypadPlus) && KeyName == "Numpad+")
            return true; //"Numpad+";
        else if (Input.GetKey(KeyCode.KeypadEnter) && KeyName == "Numpad Enter")
            return true; //"Numpad Enter";
        else if (Input.GetKey(KeyCode.KeypadEquals) && KeyName == "Numpad=")
            return true; //"Numpad=";
        else if (Input.GetKey(KeyCode.UpArrow) && KeyName == "↑")
            return true; //"↑";
        else if (Input.GetKey(KeyCode.LeftArrow) && KeyName == "←")
            return true; //"←";
        else if (Input.GetKey(KeyCode.DownArrow) && KeyName == "↓")
            return true; //"↓";
        else if (Input.GetKey(KeyCode.RightArrow) && KeyName == "→")
            return true; //"→";
        else if (Input.GetKey(KeyCode.Alpha0) && KeyName == "0")
            return true; //"false";
        else if (Input.GetKey(KeyCode.Alpha1) && KeyName == "1")
            return true; //"true";
        else if (Input.GetKey(KeyCode.Alpha2) && KeyName == "2")
            return true; //"2";
        else if (Input.GetKey(KeyCode.Alpha3) && KeyName == "3")
            return true; //"3";
        else if (Input.GetKey(KeyCode.Alpha4) && KeyName == "4")
            return true; //"4";
        else if (Input.GetKey(KeyCode.Alpha5) && KeyName == "5")
            return true; //"5";
        else if (Input.GetKey(KeyCode.Alpha6) && KeyName == "6")
            return true; //"6";
        else if (Input.GetKey(KeyCode.Alpha7) && KeyName == "7")
            return true; //"7";
        else if (Input.GetKey(KeyCode.Alpha8) && KeyName == "8")
            return true; //"8";
        else if (Input.GetKey(KeyCode.Alpha9) && KeyName == "9")
            return true; //"9";
        else if (Input.GetKey(KeyCode.Quote) && KeyName == "'")
            return true; //"'";
        else if (Input.GetKey(KeyCode.Comma) && KeyName == ",")
            return true; //",";
        else if (Input.GetKey(KeyCode.Minus) && KeyName == "-")
            return true; //"-";
        else if (Input.GetKey(KeyCode.Period) && KeyName == ".")
            return true; //".";
        else if (Input.GetKey(KeyCode.Slash) && KeyName == "/")
            return true; //"/";
        else if (Input.GetKey(KeyCode.Semicolon) && KeyName == ";")
            return true; //";";
        else if (Input.GetKey(KeyCode.Equals) && KeyName == "=")
            return true; //"=";
        else if (Input.GetKey(KeyCode.LeftBracket) && KeyName == "[")
            return true; //"[";
        else if (Input.GetKey(KeyCode.RightBracket) && KeyName == "]")
            return true; //"]";
        else if (Input.GetKey(KeyCode.Backslash) && KeyName == "Backslash")
            return true; //"Backslash";
        else if (Input.GetKey(KeyCode.Numlock) && KeyName == "Numlock")
            return true; //"Numlock";
        else if (Input.GetKey(KeyCode.CapsLock) && KeyName == "CapsLock")
            return true; //"CapsLock";
        else if (Input.GetKey(KeyCode.RightShift) && KeyName == "R Shift")
            return true; //"R Shift";
        else if (Input.GetKey(KeyCode.LeftShift) && KeyName == "L Shift")
            return true; //"L Shift";
        else if (Input.GetKey(KeyCode.RightControl) && KeyName == "R ctrl")
            return true; //"R ctrl";
        else if (Input.GetKey(KeyCode.LeftControl) && KeyName == "L ctrl")
            return true; //"L ctrl";
        else if (Input.GetKey(KeyCode.RightAlt) && KeyName == "R alt")
            return true; //"R alt";
        else if (Input.GetKey(KeyCode.LeftAlt) && KeyName == "L alt")
            return true; //"L alt";
        else if (Input.GetKey(KeyCode.Mouse0) && KeyName == "M1")
            return true; //"Mtrue";
        else if (Input.GetKey(KeyCode.Mouse1) && KeyName == "M2")
            return true; //"M2";
        else if (Input.GetKey(KeyCode.Mouse2) && KeyName == "M3")
            return true; //"M3";
        else if (Input.GetKey(KeyCode.Mouse3) && KeyName == "M4")
            return true; //"M4";
        else if (Input.GetKey(KeyCode.Mouse4) && KeyName == "M5")
            return true; //"M5";
        else if (Input.GetKey(KeyCode.Mouse5) && KeyName == "M6")
            return true; //"M6";
        else if (Input.GetKey(KeyCode.Mouse6) && KeyName == "M7")
            return true; //"M7";
        else
            return false;
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
