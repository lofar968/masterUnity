using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCursor : MonoBehaviour
{


    int Detect_input(string KeyName)
    {
        KeyName = PlayerPrefs.GetString(KeyName); // all the comments are from a find and replace, that I did to make things easier
        if (Input.GetKey(KeyCode.Q) && KeyName == "Q")
            return 1; //"Q";
        else if (Input.GetKey(KeyCode.W) && KeyName == "W")
            return 1; //"W";
        else if (Input.GetKey(KeyCode.E) && KeyName == "E")
            return 1; //"E";
        else if (Input.GetKey(KeyCode.R) && KeyName == "R")
            return 1; //"R";
        else if (Input.GetKey(KeyCode.T) && KeyName == "T")
            return 1; //"T";
        else if (Input.GetKey(KeyCode.Y) && KeyName == "Y")
            return 1; //"Y";
        else if (Input.GetKey(KeyCode.U) && KeyName == "U")
            return 1; //"U";
        else if (Input.GetKey(KeyCode.I) && KeyName == "I")
            return 1; //"I";
        else if (Input.GetKey(KeyCode.O) && KeyName == "O")
            return 1; //"O";
        else if (Input.GetKey(KeyCode.P) && KeyName == "P")
            return 1; //"P";
        else if (Input.GetKey(KeyCode.A) && KeyName == "A")
            return 1; //"A";
        else if (Input.GetKey(KeyCode.S) && KeyName == "S")
            return 1; //"S";
        else if (Input.GetKey(KeyCode.D) && KeyName == "D")
            return 1; //"D";
        else if (Input.GetKey(KeyCode.F) && KeyName == "F")
            return 1; //"F";
        else if (Input.GetKey(KeyCode.G) && KeyName == "G")
            return 1; //"G";
        else if (Input.GetKey(KeyCode.H) && KeyName == "H")
            return 1; //"H";
        else if (Input.GetKey(KeyCode.J) && KeyName == "J")
            return 1; //"J";
        else if (Input.GetKey(KeyCode.K) && KeyName == "K")
            return 1; //"K";
        else if (Input.GetKey(KeyCode.L) && KeyName == "L")
            return 1; //"L";
        else if (Input.GetKey(KeyCode.Z) && KeyName == "Z")
            return 1; //"Z";
        else if (Input.GetKey(KeyCode.X) && KeyName == "X")
            return 1; //"X";
        else if (Input.GetKey(KeyCode.C) && KeyName == "C")
            return 1; //"C";
        else if (Input.GetKey(KeyCode.V) && KeyName == "V")
            return 1; //"V";
        else if (Input.GetKey(KeyCode.B) && KeyName == "B")
            return 1; //"B";
        else if (Input.GetKey(KeyCode.N) && KeyName == "N")
            return 1; //"N";
        else if (Input.GetKey(KeyCode.M) && KeyName == "M")
            return 1; //"M";
        else if (Input.GetKey(KeyCode.Backspace) && KeyName == "Backspace")
            return 1; //"Backspace";
        else if (Input.GetKey(KeyCode.Delete) && KeyName == "Delete")
            return 1; //"Delete";
        else if (Input.GetKey(KeyCode.Tab) && KeyName == "Tab")
            return 1; //"Tab";
        else if (Input.GetKey(KeyCode.Return) && KeyName == "Return")
            return 1; //"Return";
        else if (Input.GetKey(KeyCode.Space) && KeyName == "Space")
            return 1; //"Space";
        else if (Input.GetKey(KeyCode.W) && KeyName == "W")
            return 1; //"W";
        else if (Input.GetKey(KeyCode.Keypad0) && KeyName == "Numpad0")
            return 1; //"Numpad0";
        else if (Input.GetKey(KeyCode.Keypad1) && KeyName == "Numpad1")
            return 1; //"Numpad1";
        else if (Input.GetKey(KeyCode.Keypad2) && KeyName == "Numpad2")
            return 1; //"Numpad2";
        else if (Input.GetKey(KeyCode.Keypad3) && KeyName == "Numpad3")
            return 1; //"Numpad3";
        else if (Input.GetKey(KeyCode.Keypad4) && KeyName == "Numpad4")
            return 1; //"Numpad4";
        else if (Input.GetKey(KeyCode.Keypad5) && KeyName == "Numpad5")
            return 1; //"Numpad5";
        else if (Input.GetKey(KeyCode.Keypad6) && KeyName == "Numpad6")
            return 1; //"Numpad6";
        else if (Input.GetKey(KeyCode.Keypad7) && KeyName == "Numpad7")
            return 1; //"Numpad7";
        else if (Input.GetKey(KeyCode.Keypad8) && KeyName == "Numpad8")
            return 1; //"Numpad8";
        else if (Input.GetKey(KeyCode.Keypad9) && KeyName == "Numpad9")
            return 1; //"Numpad9";
        else if (Input.GetKey(KeyCode.KeypadPeriod) && KeyName == "Numpad.")
            return 1; //"Numpad.";
        else if (Input.GetKey(KeyCode.KeypadDivide) && KeyName == "Numpad/")
            return 1; //"Numpad/";
        else if (Input.GetKey(KeyCode.KeypadMultiply) && KeyName == "Numpad*")
            return 1; //"Numpad*";
        else if (Input.GetKey(KeyCode.KeypadMinus) && KeyName == "Numpad-")
            return 1; //"Numpad-";
        else if (Input.GetKey(KeyCode.KeypadPlus) && KeyName == "Numpad+")
            return 1; //"Numpad+";
        else if (Input.GetKey(KeyCode.KeypadEnter) && KeyName == "Numpad Enter")
            return 1; //"Numpad Enter";
        else if (Input.GetKey(KeyCode.KeypadEquals) && KeyName == "Numpad=")
            return 1; //"Numpad=";
        else if (Input.GetKey(KeyCode.UpArrow) && KeyName == "↑")
            return 1; //"↑";
        else if (Input.GetKey(KeyCode.LeftArrow) && KeyName == "←")
            return 1; //"←";
        else if (Input.GetKey(KeyCode.DownArrow) && KeyName == "↓")
            return 1; //"↓";
        else if (Input.GetKey(KeyCode.RightArrow) && KeyName == "→")
            return 1; //"→";
        else if (Input.GetKey(KeyCode.Alpha0) && KeyName == "0")
            return 1; //"0";
        else if (Input.GetKey(KeyCode.Alpha1) && KeyName == "1")
            return 1; //"1";
        else if (Input.GetKey(KeyCode.Alpha2) && KeyName == "2")
            return 1; //"2";
        else if (Input.GetKey(KeyCode.Alpha3) && KeyName == "3")
            return 1; //"3";
        else if (Input.GetKey(KeyCode.Alpha4) && KeyName == "4")
            return 1; //"4";
        else if (Input.GetKey(KeyCode.Alpha5) && KeyName == "5")
            return 1; //"5";
        else if (Input.GetKey(KeyCode.Alpha6) && KeyName == "6")
            return 1; //"6";
        else if (Input.GetKey(KeyCode.Alpha7) && KeyName == "7")
            return 1; //"7";
        else if (Input.GetKey(KeyCode.Alpha8) && KeyName == "8")
            return 1; //"8";
        else if (Input.GetKey(KeyCode.Alpha9) && KeyName == "9")
            return 1; //"9";
        else if (Input.GetKey(KeyCode.Quote) && KeyName == "'")
            return 1; //"'";
        else if (Input.GetKey(KeyCode.Comma) && KeyName == ",")
            return 1; //",";
        else if (Input.GetKey(KeyCode.Minus) && KeyName == "-")
            return 1; //"-";
        else if (Input.GetKey(KeyCode.Period) && KeyName == ".")
            return 1; //".";
        else if (Input.GetKey(KeyCode.Slash) && KeyName == "/")
            return 1; //"/";
        else if (Input.GetKey(KeyCode.Semicolon) && KeyName == ";")
            return 1; //";";
        else if (Input.GetKey(KeyCode.Equals) && KeyName == "=")
            return 1; //"=";
        else if (Input.GetKey(KeyCode.LeftBracket) && KeyName == "[")
            return 1; //"[";
        else if (Input.GetKey(KeyCode.RightBracket) && KeyName == "]")
            return 1; //"]";
        else if (Input.GetKey(KeyCode.Backslash) && KeyName == "Backslash")
            return 1; //"Backslash";
        else if (Input.GetKey(KeyCode.Numlock) && KeyName == "Numlock")
            return 1; //"Numlock";
        else if (Input.GetKey(KeyCode.CapsLock) && KeyName == "CapsLock")
            return 1; //"CapsLock";
        else if (Input.GetKey(KeyCode.RightShift) && KeyName == "R Shift")
            return 1; //"R Shift";
        else if (Input.GetKey(KeyCode.LeftShift) && KeyName == "L Shift")
            return 1; //"L Shift";
        else if (Input.GetKey(KeyCode.RightControl) && KeyName == "R ctrl")
            return 1; //"R ctrl";
        else if (Input.GetKey(KeyCode.LeftControl) && KeyName == "L ctrl")
            return 1; //"L ctrl";
        else if (Input.GetKey(KeyCode.RightAlt) && KeyName == "R alt")
            return 1; //"R alt";
        else if (Input.GetKey(KeyCode.LeftAlt) && KeyName == "L alt")
            return 1; //"L alt";
        else if (Input.GetKey(KeyCode.Mouse0) && KeyName == "M1")
            return 1; //"M1";
        else if (Input.GetKey(KeyCode.Mouse1) && KeyName == "M2")
            return 1; //"M2";
        else if (Input.GetKey(KeyCode.Mouse2) && KeyName == "M3")
            return 1; //"M3";
        else if (Input.GetKey(KeyCode.Mouse3) && KeyName == "M4")
            return 1; //"M4";
        else if (Input.GetKey(KeyCode.Mouse4) && KeyName == "M5")
            return 1; //"M5";
        else if (Input.GetKey(KeyCode.Mouse5) && KeyName == "M6")
            return 1; //"M6";
        else if (Input.GetKey(KeyCode.Mouse6) && KeyName == "M7")
            return 1; //"M7";
        else
            return 0;
    }
}
