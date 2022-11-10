using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Booster : MonoBehaviour
{
    enum Boosters
    {
        Lightning,
        Magnet
    };

    [SerializeField] private Boosters booster;//будет отображатся как дропдаун
    [SerializeField] private int intBoosterAmount = 0;
    [SerializeField] private TextMeshProUGUI textBoosterCost;
    [SerializeField] private TextMeshProUGUI textBoosterAmount;
    private bool boosterIsTaken = false;
    private int previousSceneIndex;

    private void Start()
    {
        textBoosterAmount.text = intBoosterAmount.ToString();
    }

    
    private void Update()
    {
        CheckForExistance();
    }

    private void CheckForExistance()
    {
        if (textBoosterAmount.text == "0")
        {
            GetComponent<Button>().interactable = false;
        }
    }

    public void BuyBooster()
    {
        int cost = int.Parse(textBoosterCost.text);
        if (!boosterIsTaken && FindObjectOfType<DataManager>().GameScore >= cost)
        {
            CheckSelectedBooster();
            ProcessBoosterCost(cost);
            boosterIsTaken = true;
        }
    }

    private void ProcessBoosterCost(int cost)
    {
        FindObjectOfType<DataManager>().GameScore -= cost;
        textBoosterCost.text = cost.ToString();
        intBoosterAmount--;
        textBoosterAmount.text = intBoosterAmount.ToString();
    }

    private void CheckSelectedBooster()
    {
        switch (booster)
        {
            case Boosters.Lightning:
                DataManager.isSpeeded = true;
                break;
            case Boosters.Magnet:
                DataManager.isMagneted = true;
                break;
        }
    }

    
}
