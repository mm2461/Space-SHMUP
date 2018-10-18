﻿using System;
using System.Collections; // Required for Arrays & other Collections
using System.Collections.Generic; // Required for Lists and Dictionaries
using UnityEngine; // Required for Unity
public class Enemy : MonoBehaviour
{
    [Header("Set in Inspector: Enemy")]
    public float speed = 10f; // The speed in m/s
    public float fireRate = 0.3f; // Seconds/shot (Unused)
    public float health = 10;
    public int score = 100; // Points earned for destroying this
    private BoundsCheck bndCheck;

    // This is a Property: A method that acts like a field
    void Awake()
    { 
        bndCheck = GetComponent<BoundsCheck>();
    }
    public Vector3 pos
    { // a
        get
        {
            return (this.transform.position);
        }
        set
        {
            this.transform.position = value;
        }
    }
    void Update()
    {
        {
            Move();
            if (bndCheck != null && bndCheck.offDown)
            { // a
              // We're off the bottom, so destroy this GameObject // b
                Destroy(gameObject); // b
            }
        }
    }
            
    public virtual void Move()
    { // b
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }
}
