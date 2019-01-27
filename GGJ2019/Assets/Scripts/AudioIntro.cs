using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioIntro : MonoBehaviour
{

    public GameObject img;
    public PlayerMovement player;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(clip);
        Invoke("GoNext", clip.length);
    }

    public void GoNext()
    {
        img.SetActive(false);
        player.enabled = true;
    }
}
