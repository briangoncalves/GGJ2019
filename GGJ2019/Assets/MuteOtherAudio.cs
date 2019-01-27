using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MuteOtherAudio : MonoBehaviour
{
    AudioSource aud;

    // Start is called before the first frame update
    void Start()
    {
        aud = FindObjectOfType<audioGambi>().ausr;
        aud.mute = true;
    }

    void Update()
    {
       
    }

    private void OnDestroy()
    {
        aud.mute = false;
    }
}
