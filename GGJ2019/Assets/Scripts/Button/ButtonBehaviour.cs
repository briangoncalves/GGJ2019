using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public GameObject goToChange;
    bool initialState;

    private void Start()
    {
        initialState = goToChange.activeSelf;
    }

    private void OnTriggerEnter(Collider other)
    {
        goToChange.SetActive(!initialState);
    }

    private void OnTriggerExit(Collider other)
    {
        goToChange.SetActive(!initialState);
    }
}
