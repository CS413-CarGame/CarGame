using System;
using UnityEngine;

// Rotate and Bob powerups

public class PowerUpRotate : MonoBehaviour
{
    public float rotationsPerSecond = 0.1f;
    public float speed = 5f;
    public float height = 0.5f;
    private Vector3 pos;

    private void Start()
    {
        pos = transform.position;
    }

    private void FixedUpdate()
    {
        float rY = -(rotationsPerSecond * Time.time * 360) % 360f;
        
        float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
        
        transform.position = new Vector3(pos.x, newY, pos.z);
        
        transform.rotation = Quaternion.Euler(0, rY, 0);
    }
}
