using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
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
