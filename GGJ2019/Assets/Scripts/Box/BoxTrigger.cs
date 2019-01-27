using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigger : MonoBehaviour {
    public BoxMovement box;
    public Direction direct;
    private void OnTriggerEnter(Collider other)
    {
   
        if (other.tag == "Player")
        {
            Debug.Log("Trigger");
            box.direct = direct;
        }
    }
}

public enum Direction { Left, Right, Back, Forward }
