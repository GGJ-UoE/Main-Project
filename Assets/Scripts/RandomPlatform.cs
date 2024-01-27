using System.Collections;
using UnityEngine;

public class RandomPlatform : MonoBehaviour
{
    public bool willDrop = false;
    public bool willTeleport = true;
    public bool isHorizonTeleport = true;
    public Vector3 pointA;
    public Vector3 pointB;
    public float speed = 1.0f;  // normal movement speed
    public float teleportProbability = 0.1f; 
    public float teleportDistance = 2f; 
    public float teleportVariance = 1f;
    public float teleportTime = 0.5f; 

    private Vector3 nextPosition;
    private bool isTeleporting = false; 

    void Start()
    {
        nextPosition = pointB;
    }

    void Update()
    {
        if (!isTeleporting)
        {
            // normal movement
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, nextPosition, step);

            if (Vector3.Distance(transform.position, nextPosition) < step)
            {
                nextPosition = nextPosition == pointA ? pointB : pointA;
            }

            // teleport randomly
            // the random logic could be fixed if you dont want this one
            if (willTeleport && Random.value < teleportProbability * Time.deltaTime)
            {
                StartCoroutine(Teleport());
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (willDrop && collision.collider.CompareTag("Player"))
        {
            if (!gameObject.GetComponent<Rigidbody>())
            {
                gameObject.AddComponent<Rigidbody>();
            }
        }
    }

    IEnumerator Teleport()
    {
        isTeleporting = true;

        Vector3 direction;
        if (isHorizonTeleport)
        {
            direction = (Random.value < 0.5f) ? Vector3.left : Vector3.right;
        }
        else
        {
            direction = (Random.value < 0.5f) ? Vector3.up : Vector3.down;
        }

        float randomTeleportDistance = teleportDistance + Random.Range(0f, teleportVariance);
        Vector3 targetTeleportPosition = transform.position + direction * randomTeleportDistance;

        float distanceToA = Vector3.Distance(pointA, transform.position);
        float distanceToB = Vector3.Distance(pointB, transform.position);

        if (isHorizonTeleport)
        {
            if (direction == Vector3.left && distanceToA < randomTeleportDistance)
            {
                targetTeleportPosition = pointA;
            }
            else if (direction == Vector3.right && distanceToB < randomTeleportDistance)
            {
                targetTeleportPosition = pointB;
            }
        }
        else
        {
            if (direction == Vector3.up && distanceToA < randomTeleportDistance)
            {
                targetTeleportPosition = pointA;
            }
            else if (direction == Vector3.down && distanceToB < randomTeleportDistance)
            {
                targetTeleportPosition = pointB;
            }
        }
            

        Vector3 start = transform.position;
        float elapsedTime = 0;

        while (elapsedTime < teleportTime)
        {
            transform.position = Vector3.Lerp(start, targetTeleportPosition, elapsedTime / teleportTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetTeleportPosition;
        isTeleporting = false;
    }
}
