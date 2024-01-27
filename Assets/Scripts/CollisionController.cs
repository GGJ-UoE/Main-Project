using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public cameraHandle cameraHandle;
    public GameObject fallPartilce;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="trap")
        {
            cameraHandle.normalCam.Follow = null;
            Instantiate(fallPartilce,transform.position+new Vector3(0,2,0),fallPartilce.transform.rotation);
            // fallPartilce.SetActive(false);
            Invoke("restrt",1.5f);
        }
        //IDamageable damageable = other.GetComponent<IDamageable>();
        //if (damageable == null)
        //{
        //    damageable = other.GetComponentInParent<IDamageable>();
        //}
        //if (damageable != null)
        //{
        //    damageable.KillImmediately();
        //}
    }

    void restrt()
    {
        SceneLoader.ReloadCurrentScene();
    }
}
