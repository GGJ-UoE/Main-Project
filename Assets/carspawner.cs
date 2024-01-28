using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carspawner : MonoBehaviour
{
    public float spawnRepeatTime = 2f;
    public int carAllowedAtaTime = 4;
    public static int spawnCount;
    public GameObject[] carModels;
    public Transform[] spawnpoints;
    void Start()
    {
        InvokeRepeating("spawn", 2f, spawnRepeatTime);
    }

    void spawn()
    {
        if (spawnCount == carAllowedAtaTime) return;
        var obj = carModels[Random.Range(0,carModels.Length)];
        var pos = spawnpoints[Random.Range(0,carModels.Length)];

        Instantiate(obj, pos);
        spawnCount++;
    }
}
