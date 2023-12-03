
using UnityEngine;
using Cinemachine;

// Change camera view during tutorial start

public class CameraMovement : MonoBehaviour
{
    public CinemachineVirtualCamera VCam;
    private void Start()
    {
        Invoke("ChangePriority", 0.1f);
    }

    void ChangePriority()
    {
        VCam.Priority = 25;
    }


}
