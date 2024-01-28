using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class cameraHandle : MonoBehaviour
{
    public CinemachineVirtualCamera normalCam, zoomedCam, startCam;
    void Start()
    {
        startCam.Priority=0; 
        normalCam.Priority=10; 
        zoomedCam.Priority=0; 
    }


    public void switchToZoom(bool flag)
    {
        if (flag)
        {
            normalCam.Priority = 0;
            zoomedCam.Priority = 10;
        }
        else
        {
            normalCam.Priority = 10;
            zoomedCam.Priority = 0;
        }
    }
}