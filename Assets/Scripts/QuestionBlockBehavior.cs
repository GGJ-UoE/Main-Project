using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlockBehavior : MonoBehaviour
{
    public GameObject itemPopPrefab; 
    private bool isHit = false; 

    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") && !isHit)
        {
            Debug.Log("Hit");
            isHit = true;
            PopItem();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PopItem()
    {
        if (itemPopPrefab != null)
        {
            Instantiate(itemPopPrefab, transform.position + Vector3.up, Quaternion.identity);
        }

        // pop logics here
        // maybe some anim
    }
}
