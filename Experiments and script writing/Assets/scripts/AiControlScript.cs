using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AiControlScript : MonoBehaviour {

    private GameObject target;
    public Transform myTransform;
    public int aiCount;
    

    //Distances
    public float fireDist;
    public int minChaseDist = 30;

    //Speeds
    public int rotSpeed = 0;
    public float maxSpeed = 50;
    public float acceleration = 1.5f;
    public float moveSpeed = 30;



    void Awake()
    {
        rotSpeed = 5;
    }

    void Start () {
        
        target = GameObject.FindGameObjectWithTag("PlayerEntity");

        //myTransform = target.transform;

        Debug.Log("Ai Initialized");
    }

    //Called once per frame
    void Update () {

    }

    /*
    public void waveFinished ()
    {
        if (AiCount == 0)
        {
            //end game/ Return to titlescreen
        }
    } */


    void BlockA()
    {
        //flow chart referrence
    }


    void RotateTowardsPlayer()
    {
        Vector3 playerDir = target.transform.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.up, playerDir, rotSpeed, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    void ChasePlayer()
    {
        var targetDist = (target.transform.position - myTransform.position).magnitude;

        if (targetDist <= minChaseDist)
        {
            myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;

            if (moveSpeed > maxSpeed)
            {
                moveSpeed = maxSpeed;
            }

            if (moveSpeed < -maxSpeed)
            {
                moveSpeed = -maxSpeed;
            }
        }
    }



    private void FixedUpdate()
    {
        myTransform = this.transform;

        ChasePlayer();
        RotateTowardsPlayer();

    }
}
