using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _Control_Text_Control_And_Save : MonoBehaviour {

    private string assignedChar;
    private Text T;
    private bool key_is_being_selected;
    private bool runFinalCode;
    public string SaveStringAs;
    
    void Start () {
        T = GetComponent<Text>();
    }

	void change_key() {
        T.text = "press a key";
        key_is_being_selected = true;
        runFinalCode = true;
        while (key_is_being_selected)
        {
            if (Input.GetKey(KeyCode.Q))
                assignedChar = 'Q';
            else if (Input.GetKey(KeyCode.W))
                assignedChar = 'W';
            else if (Input.GetKey(KeyCode.E))
                assignedChar = 'E';
            else if (Input.GetKey(KeyCode.R))
                assignedChar = 'R';
            else if (Input.GetKey(KeyCode.T))
                assignedChar = 'T';
            else if (Input.GetKey(KeyCode.Y))
                assignedChar = 'Y';
            else if (Input.GetKey(KeyCode.U))
                assignedChar = 'U';
            else if (Input.GetKey(KeyCode.I))
                assignedChar = 'I';
            else if (Input.GetKey(KeyCode.O))
                assignedChar = 'O';
            else if (Input.GetKey(KeyCode.P))
                assignedChar = 'P';
            else if (Input.GetKey(KeyCode.A))
                assignedChar = 'A';
            else if (Input.GetKey(KeyCode.S))
                assignedChar = 'S';
            else if (Input.GetKey(KeyCode.D))
                assignedChar = 'D';
            else if (Input.GetKey(KeyCode.F))
                assignedChar = 'F';
            else if (Input.GetKey(KeyCode.G))
                assignedChar = 'G';
            else if (Input.GetKey(KeyCode.H))
                assignedChar = 'H';
            else if (Input.GetKey(KeyCode.J))
                assignedChar = 'J';
            else if (Input.GetKey(KeyCode.K))
                assignedChar = 'K';
            else if (Input.GetKey(KeyCode.L))
                assignedChar = 'L';
            else if (Input.GetKey(KeyCode.Z))
                assignedChar = 'Z';
            else if (Input.GetKey(KeyCode.X))
                assignedChar = 'X';
            else if (Input.GetKey(KeyCode.C))
                assignedChar = 'C';
            else if (Input.GetKey(KeyCode.V))
                assignedChar = 'V';
            else if (Input.GetKey(KeyCode.B))
                assignedChar = 'B';
            else if (Input.GetKey(KeyCode.N))
                assignedChar = 'N';
            else if (Input.GetKey(KeyCode.M))
                assignedChar = 'M';
            else if (Input.GetKey(KeyCode.Backspace))
                assignedChar = 'b'; /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////v
            else if (Input.GetKey(KeyCode.Delete))
                assignedChar = 'd';
            else if (Input.GetKey(KeyCode.Tab))
                assignedChar = 't';
            else if (Input.GetKey(KeyCode.Return))
                assignedChar = 'r';
            else if (Input.GetKey(KeyCode.Space))
                assignedChar = 's';
            else if (Input.GetKey(KeyCode.W))
                assignedChar = 'W';
            else if (Input.GetKey(KeyCode.Keypad0))
                assignedChar = ')';
            else if (Input.GetKey(KeyCode.Keypad1))
                assignedChar = '!';
            else if (Input.GetKey(KeyCode.Keypad2))
                assignedChar = '@';
            else if (Input.GetKey(KeyCode.Keypad3))
                assignedChar = '#';
            else if (Input.GetKey(KeyCode.Keypad4))
                assignedChar = '$';
            else if (Input.GetKey(KeyCode.Keypad5))
                assignedChar = '%';
            else if (Input.GetKey(KeyCode.Keypad6))
                assignedChar = '^';
            else if (Input.GetKey(KeyCode.Keypad7))
                assignedChar = '&';
            else if (Input.GetKey(KeyCode.Keypad8))
                assignedChar = '*';
            else if (Input.GetKey(KeyCode.Keypad9))
                assignedChar = '(';
            else if (Input.GetKey(KeyCode.KeypadPeriod))
                assignedChar = '>';
            else if (Input.GetKey(KeyCode.KeypadDivide))
                assignedChar = '?';
            else if (Input.GetKey(KeyCode.KeypadMultiply))
                assignedChar = '"';
            else if (Input.GetKey(KeyCode.KeypadMinus))
                assignedChar = '_'; ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////^
            else if (Input.GetKey(KeyCode.KeypadPlus))
                assignedChar = '+';
            else if (Input.GetKey(KeyCode.KeypadEnter))
                assignedChar = 'e'; ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////v
            else if (Input.GetKey(KeyCode.KeypadEquals))
                assignedChar = 'q';
            else if (Input.GetKey(KeyCode.UpArrow))
                assignedChar = '↑';
            else if (Input.GetKey(KeyCode.LeftArrow))
                assignedChar = '←';
            else if (Input.GetKey(KeyCode.DownArrow))
                assignedChar = '↓';
            else if (Input.GetKey(KeyCode.RightArrow))
                assignedChar = '→'; ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////^
            else if (Input.GetKey(KeyCode.Alpha0))
                assignedChar = '0';
            else if (Input.GetKey(KeyCode.Alpha1))
                assignedChar = '1';
            else if (Input.GetKey(KeyCode.Alpha2))
                assignedChar = '2';
            else if (Input.GetKey(KeyCode.Alpha3))
                assignedChar = '3';
            else if (Input.GetKey(KeyCode.Alpha4))
                assignedChar = '4';
            else if (Input.GetKey(KeyCode.Alpha5))
                assignedChar = '5';
            else if (Input.GetKey(KeyCode.Alpha6))
                assignedChar = '6';
            else if (Input.GetKey(KeyCode.Alpha7))
                assignedChar = '7';
            else if (Input.GetKey(KeyCode.Alpha8))
                assignedChar = '8';
            else if (Input.GetKey(KeyCode.Alpha9))
                assignedChar = '9';
            else if (Input.GetKey(KeyCode.Quote))
                assignedChar = 'i'; /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////|
            else if (Input.GetKey(KeyCode.Comma))
                assignedChar = ',';
            else if (Input.GetKey(KeyCode.Minus))
                assignedChar = '-';
            else if (Input.GetKey(KeyCode.Period))
                assignedChar = '.';
            else if (Input.GetKey(KeyCode.Slash))
                assignedChar = '/';
            else if (Input.GetKey(KeyCode.Semicolon))
                assignedChar = ';';
            else if (Input.GetKey(KeyCode.Equals))
                assignedChar = '=';
            else if (Input.GetKey(KeyCode.LeftBracket))
                assignedChar = '[';
            else if (Input.GetKey(KeyCode.RightBracket))
                assignedChar = ']';
            else if (Input.GetKey(KeyCode.Backslash))
                assignedChar = '|'; ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////v
            else if (Input.GetKey(KeyCode.Numlock))
                assignedChar = 'n';
            else if (Input.GetKey(KeyCode.CapsLock))
                assignedChar = 'c';
            else if (Input.GetKey(KeyCode.RightShift))
                assignedChar = 'a';
            else if (Input.GetKey(KeyCode.LeftShift))
                assignedChar = 'd';
            else if (Input.GetKey(KeyCode.RightControl))
                assignedChar = ':';
            else if (Input.GetKey(KeyCode.LeftControl))
                assignedChar = 'k';
            else if (Input.GetKey(KeyCode.RightAlt))
                assignedChar = ' ';
            else if (Input.GetKey(KeyCode.LeftAlt))
                assignedChar = 'x';
            else if (Input.GetKey(KeyCode.Mouse0))
                assignedChar = 'आ';
            else if (Input.GetKey(KeyCode.Mouse1))
                assignedChar = 'इ';
            else if (Input.GetKey(KeyCode.Mouse2))
                assignedChar = 'क';
            else if (Input.GetKey(KeyCode.Mouse3))
                assignedChar = 'ण';
            else if (Input.GetKey(KeyCode.Mouse4))
                assignedChar = 'झ';
            else if (Input.GetKey(KeyCode.Mouse5))
                assignedChar = 'ट';
            else if (Input.GetKey(KeyCode.Mouse6))
                assignedChar = 'ब'; ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////^

            if(runFinalCode)
            {
                T.text = assignedChar;

            }

            //copy, paste, change, copy, paste, change, copy, paste, change, copy, paste, change, copy, paste, change, copy, paste, change, copy, paste, change, copy, paste, change,
        }
    }
}
