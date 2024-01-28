using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffinManager : MonoBehaviour
{
    public GameObject coffinObj;
     
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        coffinObj.SetActive(true);
    }


}
