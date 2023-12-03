using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

// Car Movement Controller

public class WheelController : MonoBehaviour
{
    public float acceleration = 1000;
    public float breakForce = 3000;
    public float turnAngle = 30;
    public bool isBreaking = false;

    private float _currentAcceleration;
    private float _currentTurnAngle;
    private float _currentBreakForce;

    [SerializeField] private WheelCollider frontLeft, frontRight, rearLeft, rearRight;
    [SerializeField] private Transform frontLeftT, frontRightT, rearLeftT, rearRightT;

    public void FixedUpdate()
    {
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    // Motor Controls
    public void HandleMotor()
    {
        _currentAcceleration = acceleration * Input.GetAxis("Vertical");

        frontLeft.motorTorque = _currentAcceleration;
        frontRight.motorTorque = _currentAcceleration;


        ApplyBrakes();
    }

    // Steering Control
    public void HandleSteering()
    {
        _currentTurnAngle = turnAngle * Input.GetAxis("Horizontal");

        frontLeft.steerAngle = _currentTurnAngle;
        frontRight.steerAngle = _currentTurnAngle;
    }

    // Brake Controls
    public void ApplyBrakes()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _currentBreakForce = breakForce;
        }
        else
        {
            _currentBreakForce = 0f;
        }

        frontLeft.brakeTorque = _currentBreakForce;
        frontRight.brakeTorque = _currentBreakForce;
        rearLeft.brakeTorque = _currentBreakForce;
        rearRight.brakeTorque = _currentBreakForce;
    }

    // Update Visual Wheel positions
    public void UpdateWheels()
    {
        UpdateWheelPos(frontLeft, frontLeftT);
        UpdateWheelPos(frontRight, frontRightT);
        UpdateWheelPos(rearRight, rearRightT);
        UpdateWheelPos(rearLeft, rearLeftT);
    }

    // Update visual wheel positions
    public void UpdateWheelPos(WheelCollider col, Transform trans)
    {
        Vector3 pos;
        Quaternion rot;

        col.GetWorldPose(out pos, out rot);

        trans.position = pos;
        trans.rotation = rot;
    }
}
