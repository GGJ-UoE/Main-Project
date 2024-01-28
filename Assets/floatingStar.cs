using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingStar : MonoBehaviour
{
    public float maxTorque = 10f; // Maximum torque applied to the rigidbody
    public float rotationInterval = 2f; // Interval to apply a new random rotation force

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Start the coroutine to apply random rotation forces
        StartCoroutine(ApplyRandomRotation());
    }

    IEnumerator ApplyRandomRotation()
    {
        while (true)
        {
            // Wait for the specified interval
            yield return new WaitForSeconds(rotationInterval);

            // Generate a random torque vector
            Vector3 torque = Random.onUnitSphere * maxTorque;

            // Apply the random torque to the rigidbody
            rb.AddTorque(torque, ForceMode.Impulse);
        }
    }
}
