using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject settingPanel;
    public GameObject quitPanel;
    public AudioClip menuMusic;
    void Start()
    {
        init();
    }
    private void init()
    {

        menuPanel.SetActive(true);
        settingPanel.SetActive(false);
        quitPanel.SetActive(false);
        if(SoundManager.Instance)
        SoundManager.Instance.playMusic(menuMusic);
        
    }
    public void playGame()
    {
        SceneLoader.LoadScene(2);
    }
    public void quitGame()
    {
        Application.Quit();
    }

}
