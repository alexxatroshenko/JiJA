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
    private bool boosterIsTaken = false;

    private void Update()
    {
        CheckForExistance();
    }

    private void CheckForExistance()
    {
        var cost = ReturnCost();
        if (FindObjectOfType<DataManager>().GameScore < cost)
        {
            GetComponent<Button>().interactable = false;
        }
    }

    public void BuyBooster()
    {
        var cost = ReturnCost();
        if (!boosterIsTaken && FindObjectOfType<DataManager>().GameScore >= cost)
        {
            CheckSelectedBooster();
            ProcessBoosterCost(cost);
            boosterIsTaken = true;
        }
    }

    private int ReturnCost()
    {
        int cost = int.Parse(textBoosterCost.text);
        return cost;
    }

    private void ProcessBoosterCost(int cost)
    {
        FindObjectOfType<DataManager>().GameScore -= cost;
        textBoosterCost.text = cost.ToString();
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
