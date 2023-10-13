
using UnityEngine;
using Cinemachine;
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
