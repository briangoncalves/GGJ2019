using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {    
    public Text CountdownUI; //UI Text Object
    void Start()
    {
        StartCoroutine("LoseTime");
        Time.timeScale = 1; //Just making sure that the timeScale is right
    }
    void Update()
    {
        CountdownUI.text = (CountdownSingleton.Instance.TimeLeft / 60 + " Minutes left"); //Showing the Score on the Canvas
        if (CountdownSingleton.Instance.TimeLeft == 0)
            SceneManager.LoadScene("GameOver");
    }
    //Simple Coroutine
    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            CountdownSingleton.Instance.TimeLeft--;
        }
    }
}
