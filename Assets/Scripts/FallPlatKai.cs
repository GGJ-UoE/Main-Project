using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatKai : MonoBehaviour
{
    //public GameObject root;
	void OnCollisionEnter(Collision collision)
	{
        Debug.Log(collision);
        //Debug.DrawRay(contact.point, contact.normal, Color.white);
        if (collision.collider.CompareTag("Player"))
        {
            if (!transform.root.gameObject.GetComponent<Rigidbody>())
            {
                transform.root.gameObject.AddComponent<Rigidbody>();
            }
        }
    }

}
