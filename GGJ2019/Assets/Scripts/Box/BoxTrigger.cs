using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigger : MonoBehaviour {
    public BoxMovement box;
    public Direction direct;
    public GameObject CounterArrow;
    private void OnTriggerEnter(Collider other)
    {   
        if (other.tag == "Player")
        {
            CounterArrow.SetActive(true);
            box.direct = direct;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CounterArrow.SetActive(false);
    }
}

public enum Direction { Left, Right, Back, Forward }
