using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

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

    public void HandleMotor()
    {
        _currentAcceleration = acceleration * Input.GetAxis("Vertical");

        frontLeft.motorTorque = _currentAcceleration;
        frontRight.motorTorque = _currentAcceleration;


        ApplyBrakes();
    }

    public void HandleSteering()
    {
        _currentTurnAngle = turnAngle * Input.GetAxis("Horizontal");

        frontLeft.steerAngle = _currentTurnAngle;
        frontRight.steerAngle = _currentTurnAngle;
    }

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

    public void UpdateWheels()
    {
        UpdateWheelPos(frontLeft, frontLeftT);
        UpdateWheelPos(frontRight, frontRightT);
        UpdateWheelPos(rearRight, rearRightT);
        UpdateWheelPos(rearLeft, rearLeftT);
    }

    public void UpdateWheelPos(WheelCollider col, Transform trans)
    {
        Vector3 pos;
        Quaternion rot;

        col.GetWorldPose(out pos, out rot);

        trans.position = pos;
        trans.rotation = rot;
    }
}
