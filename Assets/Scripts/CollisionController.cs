using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public cameraHandle cameraHandle;
    public GameObject fallPartilceVFX;
    public GameObject falonGroundVFX;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "trap")
        {
            cameraHandle.normalCam.Follow = null;
            Instantiate(fallPartilceVFX, transform.position + new Vector3(0, 2, 0), fallPartilceVFX.transform.rotation);
            GameManager.isOver = true;
            GameManager.instance.gameOver(deathEffectType.coffin);
            // fallPartilce.SetActive(false);
            //Invoke("restrt", 1.5f);
        }


        if (other.gameObject.tag == "carSpawner")
        {

            other.gameObject.SetActive(false);
            GameManager.instance.carSpawner.SetActive(true);
        }
        if (other.gameObject.tag == "checkPoint")
        {
            other.gameObject.SetActive(false);
            if(GameManager.instance.currentCoffinCheckPoint< GameManager.instance.cofifnSpawnPoints.Length-1)
            GameManager.instance.currentCoffinCheckPoint++;
        }
    }

    void restrt()
    {
        SceneLoader.ReloadCurrentScene();
    }
    void jumpAttack()
    {
        Instantiate(falonGroundVFX, new Vector3(transform.position.x, transform.position.y-1, transform.position.z) , falonGroundVFX.transform.rotation);
        
    }
}
