using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishLine : MonoBehaviour, IDamageable
{
    public void KillImmediately()
    {
        Debug.LogError(gameObject.name);
        // play victory anim
        // play sounds
        // complete level/
        // show complete panel
    }
}
