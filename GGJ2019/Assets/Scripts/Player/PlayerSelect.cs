using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour {
    public enum Character { InnocentGirl, StrongMan }
    public Character player = Character.InnocentGirl;

    private PlayerColliderBox MoveObjectScript;
    private PlayerHide HideScript;

    void Start () {
        MoveObjectScript = GetComponent<PlayerColliderBox>();
        HideScript = GetComponent<PlayerHide>();
        if (HideScript != null)
            HideScript.enabled = true;
        if (MoveObjectScript != null)
            MoveObjectScript.enabled = false;
    }

    void FixedUpdate()
    {
        // Change player
        if (Input.GetButtonDown("Fire2"))
        {
            // If innocent girl, change to strong man
            if (player == Character.InnocentGirl)
            {
                player = Character.StrongMan;
                // enable / disable each character ability
                if (HideScript != null)
                    HideScript.enabled = false;
                if (MoveObjectScript != null)
                    MoveObjectScript.enabled = true;
            }
            // if strong man, change to innocent girl
            else
            {
                player = Character.InnocentGirl;
                // enable / disable each character ability
                if (HideScript != null)
                    HideScript.enabled = true;
                if (MoveObjectScript != null)
                    MoveObjectScript.enabled = false;
            }
        }
    }
}
