using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speakerjump : MonoBehaviour
{
    public AudioClip speakersound;
    public AudioSource audio;

    public Animator animator;
    public Animation animClip;
    // Start is called before the first frame update
    void Start()
    {
        this.animClip = GetComponent<Animation>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OmTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            animClip.Play();
            audio.PlayOneShot(speakersound);
        }
    }
}
