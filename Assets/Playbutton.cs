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
    // Start is called before the first frame update
    void Start()
    {
        player.SetActive(false); 
        sm=SoundManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {

                if (hit.collider.tag=="Playbutton"&&touchcounts<3)
                {
                    if(touchcounts==0)
                    {
                        sm.playSfx(SoundManager.Instance.no1);
                    }
                    else if(touchcounts==1)
                    {
                        sm.playSfx(SoundManager.Instance.no2);
                    }
                    else if(touchcounts==2)
                    {
                        sm.playSfx(SoundManager.Instance.no3);
                    }
                    newpos = new Vector3(Random.Range(-250, -220), Random.Range(50, 60),2.3f);
                    this.transform.position = Vector3.Lerp(this.transform.position, newpos, 2.3f);
                    touchcounts++;
                }
                if(touchcounts==3)
                {
                    player.SetActive(true);
                    sm.PlayDelayed(2f,SoundManager.Instance.ahshit);
                    sm.playMusic(SoundManager.Instance.bgmusic);
                    OnDestroy();
                }

            
            }
        }
      
    }

    public void OnDestroy()
    {
        Destroy(this.gameObject);
    }

}

