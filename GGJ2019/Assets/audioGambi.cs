using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioGambi : MonoBehaviour
{
    public AudioSource ausr;
    public static audioGambi instance;
    public AudioClip[] clips;

    private void Awake()
    {
        if(instance!=null && instance!= this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        int rand = Random.Range(0, clips.Length);
        ausr.PlayOneShot(clips[rand]);
        Invoke("PlayNext", clips[rand].length);
    }

    public void PlayNext()
    {
        int rand = Random.Range(0, clips.Length);
        ausr.PlayOneShot(clips[rand]);
        Invoke("PlayNext", clips[rand].length);
    }
}
