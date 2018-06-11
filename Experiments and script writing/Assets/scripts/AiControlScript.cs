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

    public float CurrentSpeed;

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
            SigmaPosRelativeToPlayer = S_Transform.position - target.position;
        }
        if(!isMoving)
        {
            if (s_RotateTowardsV3(SigmaPosRelativeToPlayer + target.position))
                isMoving = true;
        }
        else
        {
            m_MoveForwards();
            //  m_RotateTowardsV3(SigmaPosRelativeToPlayer + target.position);
            SigmaDistanceRange = (S_Transform.position - myTransform.position).magnitude;
            if ((S_Transform.position - myTransform.position).magnitude < CurrentSpeed * ((100 - acceleration) - (acceleration * (CurrentSpeed - 1) / 2)))
                m_MoveForwards(); // actually m_Decellerate. Got formula from https://www.symbolab.com/solver/series-calculator/%5Csum_%7Bn%3D0%7D%5E%7B100%7D%20100%20-%201.5n
        }
       
        Debug.DrawLine(target.position, target.position + SigmaPosRelativeToPlayer, Color.red);
    }

    
    bool s_RotateTowardsV3(Vector3 Target)
    {
        Vector3 playerDir = Target - transform.position;
        Vector3 newDir = Vector3.RotateTowards(myTransform.right * -1, playerDir, stillRotSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
        if (Vector3.Angle(myTransform.forward, SigmaPosRelativeToPlayer + target.position - myTransform.position) == 0)
            return true;
        else
            return false;
    }

   /* void ShootPlayer()
    {
        _BulletFiringScript = new BulletFiringScript();
    } */
    
    
    void m_RotateTowardsV3(Vector3 Target)
    {
        Vector3 playerDir = Target - transform.position;
        Vector3 newDir = Vector3.RotateTowards(myTransform.right * -1, playerDir, movingRotSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    void m_MoveForwards()
    {
        rigidBody.velocity = CurrentSpeed * myTransform.forward;
        CurrentSpeed += movingAccelleration;
        if (CurrentSpeed > movingMaxSpeed)
            CurrentSpeed = movingMaxSpeed;
        else if (CurrentSpeed < -movingMaxSpeed)
            CurrentSpeed = -movingMaxSpeed;
    }

    private void FixedUpdate()
    {

        if (isInBlockA)
            BlockA();
        else
        {
            Debug.DrawLine(transform.position, target.position);
            childTransform.position = myTransform.position;


            s_RotateTowardsV3(target.position);
            Debug.Log("out of block A");
        }
        
    }
}
