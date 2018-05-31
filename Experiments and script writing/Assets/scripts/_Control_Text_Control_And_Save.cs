using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _Control_Text_Control_And_Save : MonoBehaviour
{

    public string assignedString = "hello";
    public GameObject TextObj;
    public Text T;
    private bool key_is_being_selected = false;
    public string SaveStringAs;
    private bool WaitingForKeyToStartBeingSelected = false;

    void Start()
    {
        T = TextObj.GetComponent<Text>();
        assignedString = PlayerPrefs.GetString(SaveStringAs);
        T.text = assignedString;
    }

    void change_key()
    {
        WaitingForKeyToStartBeingSelected = true;
    }

    void Update()
    {
            
        assignedString = " ";
        if (WaitingForKeyToStartBeingSelected && !(Input.GetKey(KeyCode.Mouse0)))
        {
            T.text = "press a key";
            key_is_being_selected = true;
            WaitingForKeyToStartBeingSelected = false;
        }
        if (key_is_being_selected)
        {
            Debug.Log("Loop  is running");
            if (Input.GetKey(KeyCode.Q))
                assignedString = "Q";
            else if (Input.GetKey(KeyCode.W))
                assignedString = "W";
            else if (Input.GetKey(KeyCode.E))
                assignedString = "E";
            else if (Input.GetKey(KeyCode.R))
                assignedString = "R";
            else if (Input.GetKey(KeyCode.T))
                assignedString = "T";
            else if (Input.GetKey(KeyCode.Y))
                assignedString = "Y";
            else if (Input.GetKey(KeyCode.U))
                assignedString = "U";
            else if (Input.GetKey(KeyCode.I))
                assignedString = "I";
            else if (Input.GetKey(KeyCode.O))
                assignedString = "O";
            else if (Input.GetKey(KeyCode.P))
                assignedString = "P";
            else if (Input.GetKey(KeyCode.A))
                assignedString = "A";
            else if (Input.GetKey(KeyCode.S))
                assignedString = "S";
            else if (Input.GetKey(KeyCode.D))
                assignedString = "D";
            else if (Input.GetKey(KeyCode.F))
                assignedString = "F";
            else if (Input.GetKey(KeyCode.G))
                assignedString = "G";
            else if (Input.GetKey(KeyCode.H))
                assignedString = "H";
            else if (Input.GetKey(KeyCode.J))
                assignedString = "J";
            else if (Input.GetKey(KeyCode.K))
                assignedString = "K";
            else if (Input.GetKey(KeyCode.L))
                assignedString = "L";
            else if (Input.GetKey(KeyCode.Z))
                assignedString = "Z";
            else if (Input.GetKey(KeyCode.X))
                assignedString = "X";
            else if (Input.GetKey(KeyCode.C))
                assignedString = "C";
            else if (Input.GetKey(KeyCode.V))
                assignedString = "V";
            else if (Input.GetKey(KeyCode.B))
                assignedString = "B";
            else if (Input.GetKey(KeyCode.N))
                assignedString = "N";
            else if (Input.GetKey(KeyCode.M))
                assignedString = "M";
            else if (Input.GetKey(KeyCode.Backspace))
                assignedString = "Backspace";
            else if (Input.GetKey(KeyCode.Delete))
                assignedString = "Delete";
            else if (Input.GetKey(KeyCode.Tab))
                assignedString = "Tab";
            else if (Input.GetKey(KeyCode.Return))
                assignedString = "Return";
            else if (Input.GetKey(KeyCode.Space))
                assignedString = "Space";
            else if (Input.GetKey(KeyCode.W))
                assignedString = "W";
            else if (Input.GetKey(KeyCode.Keypad0))
                assignedString = "Numpad0";
            else if (Input.GetKey(KeyCode.Keypad1))
                assignedString = "Numpad1";
            else if (Input.GetKey(KeyCode.Keypad2))
                assignedString = "Numpad2";
            else if (Input.GetKey(KeyCode.Keypad3))
                assignedString = "Numpad3";
            else if (Input.GetKey(KeyCode.Keypad4))
                assignedString = "Numpad4";
            else if (Input.GetKey(KeyCode.Keypad5))
                assignedString = "Numpad5";
            else if (Input.GetKey(KeyCode.Keypad6))
                assignedString = "Numpad6";
            else if (Input.GetKey(KeyCode.Keypad7))
                assignedString = "Numpad7";
            else if (Input.GetKey(KeyCode.Keypad8))
                assignedString = "Numpad8";
            else if (Input.GetKey(KeyCode.Keypad9))
                assignedString = "Numpad9";
            else if (Input.GetKey(KeyCode.KeypadPeriod))
                assignedString = "Numpad.";
            else if (Input.GetKey(KeyCode.KeypadDivide))
                assignedString = "Numpad/";
            else if (Input.GetKey(KeyCode.KeypadMultiply))
                assignedString = "Numpad*";
            else if (Input.GetKey(KeyCode.KeypadMinus))
                assignedString = "Numpad-";
            else if (Input.GetKey(KeyCode.KeypadPlus))
                assignedString = "Numpad+";
            else if (Input.GetKey(KeyCode.KeypadEnter))
                assignedString = "Numpad Enter";
            else if (Input.GetKey(KeyCode.KeypadEquals))
                assignedString = "Numpad=";
            else if (Input.GetKey(KeyCode.UpArrow))
                assignedString = "↑";
            else if (Input.GetKey(KeyCode.LeftArrow))
                assignedString = "←";
            else if (Input.GetKey(KeyCode.DownArrow))
                assignedString = "↓";
            else if (Input.GetKey(KeyCode.RightArrow))
                assignedString = "→";
            else if (Input.GetKey(KeyCode.Alpha0))
                assignedString = "0";
            else if (Input.GetKey(KeyCode.Alpha1))
                assignedString = "1";
            else if (Input.GetKey(KeyCode.Alpha2))
                assignedString = "2";
            else if (Input.GetKey(KeyCode.Alpha3))
                assignedString = "3";
            else if (Input.GetKey(KeyCode.Alpha4))
                assignedString = "4";
            else if (Input.GetKey(KeyCode.Alpha5))
                assignedString = "5";
            else if (Input.GetKey(KeyCode.Alpha6))
                assignedString = "6";
            else if (Input.GetKey(KeyCode.Alpha7))
                assignedString = "7";
            else if (Input.GetKey(KeyCode.Alpha8))
                assignedString = "8";
            else if (Input.GetKey(KeyCode.Alpha9))
                assignedString = "9";
            else if (Input.GetKey(KeyCode.Quote))
                assignedString = "'";
            else if (Input.GetKey(KeyCode.Comma))
                assignedString = ",";
            else if (Input.GetKey(KeyCode.Minus))
                assignedString = "-";
            else if (Input.GetKey(KeyCode.Period))
                assignedString = ".";
            else if (Input.GetKey(KeyCode.Slash))
                assignedString = "/";
            else if (Input.GetKey(KeyCode.Semicolon))
                assignedString = ";";
            else if (Input.GetKey(KeyCode.Equals))
                assignedString = "=";
            else if (Input.GetKey(KeyCode.LeftBracket))
                assignedString = "[";
            else if (Input.GetKey(KeyCode.RightBracket))
                assignedString = "]";
            else if (Input.GetKey(KeyCode.Backslash))
                assignedString = "Backslash";
            else if (Input.GetKey(KeyCode.Numlock))
                assignedString = "Numlock";
            else if (Input.GetKey(KeyCode.CapsLock))
                assignedString = "CapsLock";
            else if (Input.GetKey(KeyCode.RightShift))
                assignedString = "R Shift";
            else if (Input.GetKey(KeyCode.LeftShift))
                assignedString = "L Shift";
            else if (Input.GetKey(KeyCode.RightControl))
                assignedString = "R ctrl";
            else if (Input.GetKey(KeyCode.LeftControl))
                assignedString = "L ctrl";
            else if (Input.GetKey(KeyCode.RightAlt))
                assignedString = "R alt";
            else if (Input.GetKey(KeyCode.LeftAlt))
                assignedString = "L alt";
            else if (Input.GetKey(KeyCode.Mouse0))
                assignedString = "M1";
            else if (Input.GetKey(KeyCode.Mouse1))
                assignedString = "M2";
            else if (Input.GetKey(KeyCode.Mouse2))
                assignedString = "M3";
            else if (Input.GetKey(KeyCode.Mouse3))
                assignedString = "M4";
            else if (Input.GetKey(KeyCode.Mouse4))
                assignedString = "M5";
            else if (Input.GetKey(KeyCode.Mouse5))
                assignedString = "M6";
            else if (Input.GetKey(KeyCode.Mouse6))
                assignedString = "M7";
            if (assignedString != " ")
            {
                key_is_being_selected = false;
                T.text = assignedString;
                PlayerPrefs.SetString(SaveStringAs, assignedString);
            }
        }

            //copy, paste, change, copy, paste, change, copy, paste, change, copy, paste, change, copy, paste, change, copy, paste, change, copy, paste, change, copy, paste, change,
    }
}
