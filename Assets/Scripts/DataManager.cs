using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

public class DataManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmPro;
    [SerializeField] public static bool isSpeeded;
    [SerializeField] private UnityEvent ChangedScene;
    public static bool isMagneted;
    public static DataManager Instance { get; private set; }
    public int GameScore;
    private void Awake()
    {
        
        
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        
        DontDestroyOnLoad(gameObject);
        
    }

    private void Update()
    {
        tmPro.text = GameScore.ToString();
    }

    public void DisableAllBoosters()
    {
        isSpeeded = false;
        isMagneted = false;
    }



}
