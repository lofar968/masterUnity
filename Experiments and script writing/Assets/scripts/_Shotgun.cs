using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Shotgun : MonoBehaviour {
    public float BulletSpeed = 10;
    public float DelayBetweenShots = 0.75f;
    private float TimeElapsed;
    private GameObject CurrentBullet;
    public GameObject Bullet;
    private Transform T;
    public int BulletLifetime;
    public float TransformOutOfGun = 10f;
    // Use this for initialization
    void Start()
    {
        Bullet = GameObject.FindWithTag("Bullet");
        TimeElapsed = DelayBetweenShots;
        T = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TimeElapsed += Time.deltaTime;
        if (TimeElapsed >= DelayBetweenShots)
        {
            for (float x = -5; x <= 5; ++x)
                for (float y = Mathf.Abs(x) - 5; y <= 5 - Mathf.Abs(x); ++y)
                {
                    CurrentBullet = Instantiate(Bullet, T.position + T.forward * TransformOutOfGun, T.rotation);
                    Vector3 newDir = Vector3.RotateTowards(CurrentBullet.transform.forward, CurrentBullet.transform.right, 0.12f * x, 1.0f);
                    CurrentBullet.transform.rotation = Quaternion.LookRotation(newDir);
                    Vector3 newDIr = Vector3.RotateTowards(CurrentBullet.transform.forward, CurrentBullet.transform.up, 0.12f * y, 1.0f);
                    CurrentBullet.transform.rotation = Quaternion.LookRotation(newDIr);
                    CurrentBullet.SendMessage("SetSpeed", BulletSpeed);
                    CurrentBullet.SendMessage("DestroyIn", BulletLifetime);
                }
                    TimeElapsed = 0.0f;
        }
    }
}
