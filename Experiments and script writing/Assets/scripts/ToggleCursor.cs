using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCursor : MonoBehaviour {
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
