using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHideMesh : MonoBehaviour
{
    public GameObject meshToHide;

    public void Show()
    {
        meshToHide.SetActive(true);
    }

    public void Hide()
    {
        meshToHide.SetActive(false);
    }
}
