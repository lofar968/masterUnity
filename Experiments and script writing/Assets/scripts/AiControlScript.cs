using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



public class AiControlScript : MonoBehaviour {

    public Transform target;
    Vector3 storeTarget;
    bool savePos;
    bool overrideTarget;

    private Transform myTransform;
    public int aiCount;
    public float rotSpeed = 5;

    public GameObject child;
    //Distances
    public float fireDist;

    //Speeds
    Vector3 acceleration;
    Vector3 velocity;
    public float maxSpeed = 5f;
    float storeMaxSpeed;
    float targetSpeed;

    Rigidbody rigidBody;
    Transform childTransform;

    public List<Vector3> EscapeDirections = new List<Vector3>();



    void Start () {

        myTransform = GetComponent<Transform>();
        storeMaxSpeed = maxSpeed;
        targetSpeed = storeMaxSpeed;

        rigidBody = GetComponent<Rigidbody>();
        childTransform = child.GetComponent<Transform>()   ;
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
        Vector3 newDir = Vector3.RotateTowards(myTransform.right * -1, playerDir, rotSpeed, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    /*void ChasePlayer()
    {
        var targetDist = (target.transform.position - myTransform.position).magnitude;

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
        }
    }*/

    Vector3 MoveTowardsTarget(Vector3 target)
    {
        Vector3 distance = target - transform.position;

        if(distance.magnitude < 25)
        {
            return distance.normalized * -maxSpeed;
        }
        else
        {
            return distance.normalized * maxSpeed;
        }
    }

    private void FixedUpdate()
    {

        Debug.DrawLine(transform.position, target.position);

        

        rigidBody.velocity = velocity;
        childTransform.position = myTransform.position;


        RotateTowardsPlayer();

    }
}
