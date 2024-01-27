using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splash : MonoBehaviour
{
 
    void Start()
    {
        Invoke(nameof(loadMenu),1f);
    }

    void loadMenu()
    {
        SceneLoader.LoadMenuScene();
    }
}
