using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBehavior : MonoBehaviour
{
    public Collider trapTriggerCollider;
    private Animation spikeAnimation;
    private bool played = false;

    void Start()
    {
        if (!gameObject.isStatic)
        {
            if (trapTriggerCollider == null)
            {
                Debug.LogError("TrapTrigger Collider is not assigned!");
                return;
            }

            // add trap trigger
            trapTriggerCollider.gameObject.AddComponent<TriggerEventForwarder>().OnTriggerEntered += OnTrapTriggerEnter;

            spikeAnimation = GetComponent<Animation>();
            if (spikeAnimation == null)
            {
                Debug.LogError("Animation component not found on the object!");
                return;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
    private void OnTrapTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && spikeAnimation != null && spikeAnimation.clip != null && !played)
        {
            played = true;
            spikeAnimation.Play();
        }
        
    }
}
public class TriggerEventForwarder : MonoBehaviour
{
    public delegate void TriggerAction(Collider other);
    public event TriggerAction OnTriggerEntered;

    void OnTriggerEnter(Collider other)
    {
        OnTriggerEntered?.Invoke(other);
    }
}
