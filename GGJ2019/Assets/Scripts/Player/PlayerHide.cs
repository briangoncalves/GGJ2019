using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHide : MonoBehaviour
{
    PlayerSelect anim;

    bool IsTouchingLayer(Vector3 center, float radius, string layer)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach(var collider in hitColliders)
        {
            if (collider.gameObject.layer.Equals(LayerMask.NameToLayer(layer))) return true;
        }
        return false;
    }

    BoxMovement IsTouchingBox(Vector3 center, float radius, string layer)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var collider in hitColliders)
        {
            if (collider.gameObject.layer.Equals(LayerMask.NameToLayer(layer))) 
                return collider.GetComponent<BoxMovement>();
        }
        return null;
    }

    public float DistanceRadius = 0.3f;

    string HideKey = "Fire1";
    PlayerMovement pm;

    private void Start()
    {
        pm = GetComponent<PlayerMovement>();
        anim = GetComponent<PlayerSelect>();
    }

    void FixedUpdate()
    {
        if (anim.player == PlayerSelect.Character.InnocentGirl)
        {
            // if action button pressed, hide
            if (Input.GetButton(HideKey))
            {
                // Check if it is touching a HideSpot layer (places that can hide)
                if (IsTouchingLayer(transform.position, DistanceRadius, "HideSpot"))
                {
                    // if on hiding spot, character stops to render
                    anim.SetCurrentAvatarHide(true);
                }
                else
                {
                    // if not on hiding spot, render
                    anim.SetCurrentAvatarHide(false);
                    pm.CanMove = true;
                }
            }
            else
            {
                // if not key pressed, render
                anim.SetCurrentAvatarHide(false);
                pm.CanMove = true;
            }
        }

        else if (anim.player == PlayerSelect.Character.StrongMan)
        {
            // if action button pressed, try push
            if (Input.GetButtonDown(HideKey))
            {
                var box = IsTouchingBox(transform.position, DistanceRadius, "Box") ;
                if ( box!=null)
                {
                    box.MoveBox();
                    anim.SetTriggerToCurrent("push");
                }
                else
                {
                    pm.CanMove = true;
                }
            }
            else
            {
                pm.CanMove = true;
            }
        }
    }
}
