﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _BulletFiringScript : MonoBehaviour {
    public float BulletSpeed = 10;
    public float DelayBetweenShots = 0.75f;
    private float TimeElapsed;
    private GameObject CurrentBullet;
    public GameObject Bullet;
    private Transform T;
    public int BulletLifetime;
    public float TransformOutOfGun = 10f;
	// Use this for initialization
	void Start () {
        TimeElapsed = DelayBetweenShots;
        T = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        TimeElapsed += Time.deltaTime;
        if (TimeElapsed >= DelayBetweenShots)
        {
            CurrentBullet = Instantiate(Bullet, T.position + T.forward * TransformOutOfGun, T.rotation);
            TimeElapsed = 0.0f;
            CurrentBullet.SendMessage("SetSpeed", BulletSpeed);
            CurrentBullet.SendMessage("DestroyIn", BulletLifetime);
        }
	}
}
