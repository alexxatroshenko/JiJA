using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class LevelSession : MonoBehaviour
{
    [SerializeField] private UnityEvent levelCompleted;
    [SerializeField] private TextMeshProUGUI levelCompletedScoreCount;
    private int levelScore;
    private DataManager dataManager;

    private void Start()
    {
        dataManager = FindObjectOfType<DataManager>();
    }
    public void LevelComplete(int Score)
    {
        levelScore = Score;
        if (FindObjectsOfType<Jelly>().Length == 1)
        {
            FindObjectOfType<DataManager>().GameScore += Score;
            dataManager.DisableAllBoosters(); 
            StartCoroutine(InvokeLevelCompletedEvent(0.5f));

        }
    }

    private IEnumerator InvokeLevelCompletedEvent(float delay)
    {
        yield return new WaitForSeconds(delay);
        levelCompleted.Invoke();
        for(int i = 0; i < levelScore+1; i++)
        {
            yield return new WaitForSeconds(0.1f);
            i += levelScore / 10;
            if (i > levelScore)
                i = levelScore;
            levelCompletedScoreCount.text = "JELLIES: " + i.ToString();
        }
    }
}
