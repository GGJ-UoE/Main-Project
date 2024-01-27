using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 startpos;
    public Vector3 desPos = new Vector3(5, 0, 0);
    public float speed = 3f;
    public bool pingPong;
    [SerializeField]private Vector3 currentPos;
    public GameObject fallPartilce;
    void Start()
    {
        startpos = transform.position;
        desPos += startpos;
        currentPos = desPos;
    }

    // Update is called once per frame
    void Update()
    {
      //  transform.position = Vector3.MoveTowards(transform.position, desPos, Time.deltaTime*speed);
        if (pingPong)
        {
            if (Vector3.Distance(transform.position, desPos) <= 0.1f)
            {
                currentPos = startpos;
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);


            }
             if (Vector3.Distance(transform.position, startpos) <= 0.1f)
            {
                currentPos = desPos;
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);

            }
            transform.position = Vector3.MoveTowards(transform.position, currentPos, Time.deltaTime * speed);

            // transform.position = Vector3.MoveTowards(transform.position, startpos, Time.deltaTime * speed);
        }
        else
        transform.position = Vector3.MoveTowards(transform.position, desPos, Time.deltaTime * speed);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            Instantiate(fallPartilce, transform.position, fallPartilce.transform.rotation);
            Destroy(fallPartilce);
            // fallPartilce.SetActive(false);
        }
    }
}
