using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _MachineGun : MonoBehaviour {
    public float BulletSpeed = 10;
    public float DelayBetweenShots = 0.1f;
    public float angle_range_in_rad;
    public float TimeElapsed;
    private GameObject CurrentBullet;
    public GameObject Bullet;
    private Transform T;
    public int BulletLifetime;
    public float TransformOutOfGun = 10f;
    private float x;
    private float y;
    void Start()
    {
        TimeElapsed = DelayBetweenShots;
        T = GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        TimeElapsed += Time.deltaTime;
        if (TimeElapsed >= DelayBetweenShots)
        {
            CurrentBullet = Instantiate(Bullet, T.position + T.forward * TransformOutOfGun, T.rotation);
            TimeElapsed = 0.0f;
            x = (Random.value - 0.5f) * angle_range_in_rad * 2;
            y = (Random.value - 0.5f) * angle_range_in_rad * 2;
            Vector3 newDir = Vector3.RotateTowards(CurrentBullet.transform.forward, CurrentBullet.transform.right, x , 1.0f);
            CurrentBullet.transform.rotation = Quaternion.LookRotation(newDir);
            Vector3 newDIr = Vector3.RotateTowards(CurrentBullet.transform.forward, CurrentBullet.transform.up, y , 1.0f);
            CurrentBullet.transform.rotation = Quaternion.LookRotation(newDIr);
            CurrentBullet.SendMessage("SetSpeed", BulletSpeed);
            CurrentBullet.SendMessage("DestroyIn", BulletLifetime);
        }
    }
}
