using UnityEngine;
using System.Collections;

public class RandomRotationPlat : MonoBehaviour
{
    public float suddenSpinProbability;
    public float suddenSpinDuration;
    public float torqueAmount;
    public float torqueVariance;
    public float angleLimit;

    private Rigidbody rb;
    private float rotateDirection;
    private bool willSuddenSpin = false;
    private bool isSuddenSpining = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found!");
        }
    }

    void Update()
    {
        if (willSuddenSpin && !isSuddenSpining && Random.value < suddenSpinProbability * Time.deltaTime)
        {
            StartCoroutine(ApplySuddenTorque(rotateDirection));
        }
        Vector3 localEulerAngles = transform.localEulerAngles;
        float zRotation = localEulerAngles.z;
        if (zRotation > 180)
        {
            zRotation -= 360;
        }
        zRotation = Mathf.Clamp(zRotation, -angleLimit, angleLimit);
        transform.localEulerAngles = new Vector3(localEulerAngles.x, localEulerAngles.y, zRotation);
    }

    IEnumerator ApplySuddenTorque(float direction)
    {
        isSuddenSpining = true;

        float torque = (torqueAmount + Random.Range(-torqueVariance, torqueVariance)) * direction;

        //Debug.Log(direction);

        rb.AddTorque(new Vector3(0, 0, torque * rb.mass), ForceMode.Impulse);

        yield return new WaitForSeconds(suddenSpinDuration);

        isSuddenSpining = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            willSuddenSpin = true;

            // make sure that player will be thrown upward
            // not always if player move to the other side after Collision happened
            // if you can fix this, give it a try
            Vector3 collisionPoint = collision.contacts[0].point; 
            Vector3 platformCenter = transform.position; 
            rotateDirection = collisionPoint.x < platformCenter.x ? -1f : 1f;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            willSuddenSpin = false;
        }
    }
}
