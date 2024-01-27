using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public GameObject footstepParticle;
    public Transform footstepPos;
    private void footstep()
    {
        Instantiate(footstepParticle, footstepPos.position, footstepParticle.transform.rotation);
    }
}
