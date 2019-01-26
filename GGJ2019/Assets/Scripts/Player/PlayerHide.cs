using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHide : MonoBehaviour {

    bool IsTouchingLayer(Vector3 center, float radius, string layer)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach(var collider in hitColliders)
        {
            if (collider.gameObject.layer.Equals(LayerMask.NameToLayer(layer))) return true;
        }
        return false;
    }
    public float DistanceRadius = 0.3f;

    string HideKey = "Fire1";
    PlayerMovement pm;

    private void Start()
    {
        pm = GetComponent<PlayerMovement>();
    }

    void FixedUpdate()
    {
        // if action button pressed, hide
        if (Input.GetButton(HideKey))
        {
            // Check if it is touching a HideSpot layer (places that can hide)
            if (IsTouchingLayer(transform.position, DistanceRadius, "HideSpot"))
            {
                // if on hiding spot, character stops to render
                GetComponent<MeshRenderer>().enabled = false;
                pm.CanMove = false;
            }
            else
            {
                // if not on hiding spot, render
                GetComponent<MeshRenderer>().enabled = true;
                pm.CanMove = true;
            }
        }
        else
        {
            // if not key pressed, render
            GetComponent<MeshRenderer>().enabled = true;
            pm.CanMove = true;
        }
    }    
}
