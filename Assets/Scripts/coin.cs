using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour, IDamageable
{
    public void KillImmediately()
    {
        Debug.LogError(gameObject.name);

        // coin++
        //play sound
        // destroy gameobject
    }
}
