using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToFacePlayer : MonoBehaviour {

    public Transform Target;
    public Transform myTransform;

	// Use this for initialization
	void Start () {
        myTransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 playerDir = Target.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(myTransform.right, playerDir, 10000, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
