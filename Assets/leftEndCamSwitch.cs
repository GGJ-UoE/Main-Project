using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftEndCamSwitch : MonoBehaviour
{
    public cameraHandle cameraHandle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Player")
        {
            cameraHandle.switchToZoom(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            cameraHandle.switchToZoom(false);
        }
    }
}
