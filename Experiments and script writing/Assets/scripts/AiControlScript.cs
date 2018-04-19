using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AiControlScript : MonoBehaviour {

    private Transform target;
    private Transform myTransform;
    public int AiCount;
    public GameObject target = new GameObject("target");

    //Distances
    public float fireDist;
    public int minChaseDist = 1000;


    //Speeds
    public int rotSpeed = 0;
    public float maxSpeed = 50;
    public float acceleration = 1.5f;
    public float moveSpeed = 0.0f;

    void Awake()
    {
        rotSpeed = 5;
    }
    //Initialization
    void start () {

       

        Debug.Log("Ai Initialized");
      //AiCount = GameObject.FindGameObjectsWithTag("Ai");
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

   

    private void FixedUpdate()
    {
        myTransform = this.transform;
        var targetDist = (target.position - myTransform.position).magnitude;

        

        //target = GameObject.FindGameObjectWithTag("PlayerEntity").transform;

        if (targetDist <= minChaseDist)
        {
            myTransform.position += myTransform.forward * acceleration * Time.deltaTime;

            if (moveSpeed > maxSpeed)
            {
                moveSpeed = maxSpeed;
            }

            if (moveSpeed < -maxSpeed) 
            {
                moveSpeed = -maxSpeed;
            }

            Vector3 playerDir = target.transform.position - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.up, playerDir, rotSpeed, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDir);
    }

        }

        



}
