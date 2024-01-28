using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playbutton : MonoBehaviour
{
    public int touchcounts=0;
    public GameObject player;
    public bool ismoving;
    public Vector3 newpos;
    private SoundManager sm;
    public cameraHandle camhandle;
    private bool gotPos;
    // Start is called before the first frame update
    void Start()
    {
        player.SetActive(false); 
        sm=SoundManager.Instance;
    }

    

    // Update is called once per frame
    void Update()
    {
        if (!gotPos)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //newpos = new Vector3(Random.Range(-250, -220), Random.Range(50, 60), 2.3f);
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.tag == "Playbutton")

                   newpos = new Vector3(Random.Range(-250, -210), Random.Range(70, 40), 0);
                gotPos = true;

            }



        }


        if (gotPos)
        {
            if (touchcounts < 3)
            {
                sm.playSfx(SoundManager.Instance.no1);
                this.transform.position = Vector3.MoveTowards(this.transform.position, newpos, 2);
                if (Vector3.Distance(this.transform.position, newpos) <= 1)
                {

                    touchcounts++;
                    gotPos = false;
                }

            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    player.SetActive(true);
                    camhandle.enableCamera();
                    sm.PlayDelayed(2f, SoundManager.Instance.ahshit);
                    Destroy(gameObject);
                    
                }
            }
        }

    }
    

    public void OnDestroy()
    {
    }

}

