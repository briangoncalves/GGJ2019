using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameManager : Singleton<NewGameManager>
{

    int index = -1;
    public string[] sceneNames;


    void Start()
    {
        DontDestroyOnLoad(gameObject);
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
            SceneManager.LoadScene(sceneNames[index]);
        }
    }
}
