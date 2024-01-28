using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Score;
    public GameObject carSpawner;
    public GameObject gameoverPanel, winPanel;
    public GameObject coffinObj;
    public GameObject mainCamera;
    public GameObject starEffectObj;
    public GameObject winp;
    public cameraHandle CameraHandle;
    public Animator playerAnm;
    public Transform[] cofifnSpawnPoints;
    public GameObject[] enemies;
    public static GameManager instance;
    public static bool isOver;
    GameObject cofinSpawned;
    GameObject starEfectSpawned;
    public int currentCoffinCheckPoint;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        Score= 0;
        isOver = false;
        
    }

    public void gameOver(deathEffectType deathEffect)
    {
        foreach (GameObject g in enemies)
        {
            if (g)
                g.SetActive(false);
        }
        switch (deathEffect)
        {
            case deathEffectType.coffin:
                cofinSpawned=Instantiate(coffinObj, cofifnSpawnPoints[currentCoffinCheckPoint].position, cofifnSpawnPoints[currentCoffinCheckPoint].rotation);
                mainCamera.SetActive(false);

                StartCoroutine(delayedComplete(15,cofinSpawned));
                break;
            case deathEffectType.stars:
                StartCoroutine(delayedEffect(6, starEfectSpawned));
                break;

        } 

    }
    IEnumerator delayedComplete(float wait,GameObject obj)
    {
        yield return new WaitForSeconds(wait);
        gameoverPanel.SetActive(true);
        Destroy(obj);

    }   
    IEnumerator delayedEffect(float wait,GameObject obj)
    {
        yield return new WaitForSeconds(2f);
        mainCamera.SetActive(false);

        starEfectSpawned = Instantiate(starEffectObj);
        yield return new WaitForSeconds(wait);
        gameoverPanel.SetActive(true);
        Destroy(obj);

    }
    public void win()
    {
        winp.SetActive(true);

        CameraHandle.Onfinish();
        playerAnm.SetTrigger("Dance");
    }
    public void retry()
    {
        SceneLoader.ReloadCurrentScene();
    }
    public void home()
    {
        SceneLoader.LoadMenuScene();
    }
}
public enum deathEffectType
{
    normal,
    coffin,
    stars
}