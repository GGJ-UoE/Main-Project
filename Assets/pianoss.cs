using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pianoss : MonoBehaviour
{
    public SoundManager sm;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            if (this.gameObject.tag == "Goat1")
            {
                
                sm.playSfx(sm.Goat, 0.9f,1);
            }
            if (this.gameObject.tag == "Goat2")
            {
                
                sm.playSfx(sm.Goat, 1.05f,1);
            }
            if (this.gameObject.tag == "Goat3")
            {
                
                sm.playSfx(sm.Goat, 1.2f, 1);
            }
            if (this.gameObject.tag == "Goat4")
            {
                
                sm.playSfx(sm.Goat, 0.7f,1);
            }
          
        }
    }
}
