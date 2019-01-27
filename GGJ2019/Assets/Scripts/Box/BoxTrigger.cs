using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigger : MonoBehaviour {
    public BoxMovement box;
    public Direction direct;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.gameObject.layer.Equals(LayerMask.NameToLayer("Player")))
        {
            box.direct = direct;
        }
    }
}

public enum Direction { Left, Right, Back, Forward }
