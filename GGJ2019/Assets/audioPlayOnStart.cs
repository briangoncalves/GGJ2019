using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioPlayOnStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!NewGameManager.Instance.reloaded)
            GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
