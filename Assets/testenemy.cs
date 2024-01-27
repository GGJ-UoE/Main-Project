using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testenemy : MonoBehaviour, IDamageable
{
    public void KillImmediately()
    {
        Debug.LogError("enemy ");
    }
    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable == null)
        {
            damageable = other.GetComponentInParent<IDamageable>();
        }
        if (damageable != null)
        {
            damageable.KillImmediately();
        }
    }
}
