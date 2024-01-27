using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pianoss : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip goat1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            audio.PlayOneShot(goat1);
        }
    }
}
