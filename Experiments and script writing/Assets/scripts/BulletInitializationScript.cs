using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInitializationScript : MonoBehaviour {
    private Rigidbody rb;
	
    public void SetSpeed(float Speed)
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * Speed;
    }
    public void DestroyIn(int time)
    {
        Destroy(gameObject, time);
    }

}
