using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JellyCountCanvas : MonoBehaviour
{
    public static JellyCountCanvas Instance { get; private set; }
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
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            gameObject.GetComponent<Canvas>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<Canvas>().enabled = true;
        }
    }
}
