using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

public class DataManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmPro;
    public static bool isSpeeded;
    public static bool isMagneted;
    [SerializeField] private UnityEvent ChangedScene;
    [SerializeField] public int LevelNumber = 0;
    
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
    private void Start()
    {
        SceneManager.activeSceneChanged += ChangedActiveScene;
    }
    public void ChangedActiveScene(Scene current, Scene next)
    {
        if (next.buildIndex != 0)
        {
            LevelNumber = SceneManager.GetActiveScene().buildIndex;
        }
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
