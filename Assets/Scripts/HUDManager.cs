using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//@TODO: 
// - Once Sigleton class change to correct name change it here
// - Add special particle effects when adding or removing coins
public class HUDManager : SingeltonBase<HUDManager>
{
    [Header("UI fields")]
    [SerializeField] private Transform topPanel;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text coinsText;

    [Header("Gameplay logic")]
    [SerializeField] private float startingTime = 200;
    private int coins = 0;
    private float remainingTime;

    void Start()
    {
        InitHUDManager();
    }

    void Update()
    {
        if (remainingTime >= 0)
        {
            remainingTime -= Time.deltaTime;
            timeText.text = "" + (int)remainingTime;
        }
    }

    public void InitHUDManager()
    {
        remainingTime = startingTime;
        coins = 0;
        coinsText.text = "" + coins;
    }

    public void InitHUDManager(float customTime, int customCoins)
    {
        remainingTime = customTime;
        coins = customCoins;
        coinsText.text = "" + coins;
    }

    public void ShowTopPanel(bool show)
    {
        topPanel.gameObject.SetActive(show);
    }

    public void AddCoins(int coinsToAdd)
    {
        coins+=coinsToAdd;
        coinsText.text = "" + coins;
    }

    public void RemoveCoins(int coinsToRemove)
    {
        coins-=coinsToRemove;
        coinsText.text = "" + coins;
    }
}
