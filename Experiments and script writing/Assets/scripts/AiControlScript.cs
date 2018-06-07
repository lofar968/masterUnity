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

    //used while moving to a point
    public float movingRotSpeed;
    public float movingMaxSpeed;
    public float movingAccelleration;
    //used while aiming & firing
    public float stillRotSpeed;
    public float stillMaxSpeed;
    public float stillAccelleration;
    //Range and leeway on position's distance from player or target
    public float AI_IdealRange;
    public float AI_RangeLeeway;
    public float AI_IdealPositionLeeway;
    //"state" variables
    private bool isMoving = false;
    private bool isInBlockA = true;
    //Sigma vars
    private float DeltaDistance_SigmaAi;
    public float SigmaDistanceRange; //from idealRange
    private GameObject S_Obj;
    private Transform S_Transform;
    private float SigmaDistanceFromPlayer;
    public GameObject EmptyTransform;
    public Vector3 SigmaPosRelativeToPlayer;

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
        childTransform = child.GetComponent<Transform>();
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
        if(S_Obj == null)
        {
            S_Obj = Instantiate(EmptyTransform, target.position, Random.rotation);
            S_Transform = S_Obj.GetComponent<Transform>();
            SigmaDistanceFromPlayer = AI_IdealRange + ((Random.value - 0.5f) * SigmaDistanceRange * 2);
            S_Transform.Translate(SigmaDistanceFromPlayer * S_Transform.forward, Space.World);
        }
    }


    void s_RotateTowardsPlayer()
    {
        Vector3 playerDir = target.transform.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(myTransform.right * -1, playerDir, stillRotSpeed, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

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

        if (isInBlockA)
            BlockA();
        else
        {


            Debug.DrawLine(transform.position, target.position);



            rigidBody.velocity = velocity;
            childTransform.position = myTransform.position;


            s_RotateTowardsPlayer();
        }
    }
}
