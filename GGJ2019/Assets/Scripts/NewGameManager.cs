﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameManager : MonoBehaviour
{
    public static NewGameManager Instance;
    int index = -1;
    public string[] sceneNames;
    public bool reloaded;

    private void Awake()
    {
        if(Instance != null && Instance !=this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }


    public void LoadNextScene()
    {
        index++;
        if (index >= sceneNames.Length)
        {
            SceneManager.LoadScene("EndGame");
        }
        else
        {
            reloaded = false;
            SceneManager.LoadScene(sceneNames[index]);

        }
    }

    public void Reload()
    {
        reloaded = true;
        SceneManager.LoadScene(sceneNames[index]);
    }
}
