using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToFacePlayer : MonoBehaviour {

    public Transform Target;
    public Transform myTransform;
    public char FacesChar = 'f';
    public int FacesInt = 1;
    private bool isTurning = true;

	// Use this for initialization
	void Start () {
        myTransform = GetComponent<Transform>();
	}

    void Stop_Turning()
    {
        isTurning = false;
    }
    void Turn()
    {
        isTurning = true;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (isTurning)
        {
            Vector3 playerDir = Target.position - transform.position;
            Vector3 newDir = Vector3.zero;
            if (FacesChar == 'f')
                newDir = Vector3.RotateTowards(myTransform.forward * FacesInt, playerDir, 10000, 0.0f);
            else if (FacesChar == 'r')
                newDir = Vector3.RotateTowards(myTransform.right * FacesInt, playerDir, 10000, 0.0f);
            else if (FacesChar == 'u')
                newDir = Vector3.RotateTowards(myTransform.up * FacesInt, playerDir, 10000, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);
        }   
    }
}
