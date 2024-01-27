using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_collision : MonoBehaviour
{
    public GameManager gm;
    public bool isRunnyCoin;
    private bool isrunning=false;
    public AudioSource Audio;
    public AudioClip CoinCollect, RunnySfx;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
            
    }

    // Update is called once per frame
    void Update()
    {
        if (isrunning)
        {
            this.transform.Translate(0,0.2f,0);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            gm.Score++;
            if(isRunnyCoin)
            {
                StartCoroutine(RunCoin());

            }
            else
                StartCoroutine(SoundnDestroy());
        }
    }

    IEnumerator RunCoin()
    {
        Rotation rot = GetComponent<Rotation>();
        if (rot != null)
        {
            Audio.PlayOneShot(RunnySfx);
            transform.eulerAngles = new Vector3(0, 0, 90);
            rot.enabled = false;
        }

        isrunning = true;
        yield return new WaitForSeconds(1);
        isRunnyCoin= false;
        isrunning= false;

        if (rot != null)
        {
            rot.enabled = true;
        }
    }

    IEnumerator SoundnDestroy()
    {
        Audio.PlayOneShot(CoinCollect);
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    }

   

}