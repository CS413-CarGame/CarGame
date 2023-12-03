using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// SpeedometerManager

public class Speedometer : MonoBehaviour {

    private const float MAX_SPEED_ANGLE = -20;
    private const float ZERO_SPEED_ANGLE = 230;
    private Transform needleTransform;
    private float speedMax;
    private float speed;

    private void Awake() {
        needleTransform = transform.Find("Needle");

        speed = 0f;
        speedMax = 200f;
    }

    private void Update() {
        speed = Car.TRUCKVEL.magnitude*5;

        needleTransform.eulerAngles = new Vector3(0, 0, GetSpeedRotation());
    }

    private float GetSpeedRotation() {
        float totalAngleSize = ZERO_SPEED_ANGLE - MAX_SPEED_ANGLE;

        float speedNormalized = speed / speedMax;

        return ZERO_SPEED_ANGLE - speedNormalized * totalAngleSize;
    }
}
