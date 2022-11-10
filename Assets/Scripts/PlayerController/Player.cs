using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Player : MonoBehaviour
{
    private int levelScore = 0;
    [SerializeField] private int minScoreEncrease = 10;
    [SerializeField] private int maxScoreEncrease = 30;
    [SerializeField] private float playerGrowValue = 1.1f;
    [SerializeField] private float playerDecreaseValue = 1.1f;
    [SerializeField] private float minPlayerSize = 0.3f;

    [SerializeField] private UnityEvent DeathEvent;
    [SerializeField] private TextMeshProUGUI tmPro;
    private LevelSession levelSession;

    private void Start()
    {
        levelSession = FindObjectOfType<LevelSession>();
        levelScore = 0;
    }
    public void Grow()
    {
        Debug.Log("Grow");
        transform.localScale = new Vector3(transform.localScale.x + playerGrowValue, transform.localScale.y + playerGrowValue, transform.localScale.z + playerGrowValue);
        levelScore += UnityEngine.Random.Range(minScoreEncrease, maxScoreEncrease);
        tmPro.text = levelScore.ToString();
        levelSession.LevelComplete(levelScore);

    }

    public void Decrease()
    {
        if (transform.localScale.x <= minPlayerSize)
        {
            PlayerDie();
        }
        transform.localScale = new Vector3(transform.localScale.x - playerDecreaseValue, transform.localScale.y - playerDecreaseValue, transform.localScale.z - playerDecreaseValue);
    }

    private void PlayerDie()
    {
        FindObjectOfType<DataManager>().DisableAllBoosters();
        DeathEvent.Invoke();
    }
}
