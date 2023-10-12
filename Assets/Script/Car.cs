using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Car : MonoBehaviour
{
    // Start is called before the first frame update
    static public Vector3 POS = Vector3.zero;
    static public Vector3 TRUCKVEL = Vector3.zero;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    private void FixedUpdate()
    {
        UnityEngine.Debug.Log(rb.velocity.magnitude);
        TRUCKVEL = rb.velocity;
        Vector3 tPos = transform.position;
        POS = tPos;
    }
}
