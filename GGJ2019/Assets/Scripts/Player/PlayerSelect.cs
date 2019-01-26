using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour {
    public enum Character { InnocentGirl, StrongMan, CrazyDude }
    public Character player = Character.InnocentGirl;
    public int CrazyRandom = 1;

    private PlayerColliderBox MoveObjectScript;
    private PlayerHide HideScript;
    private PlayerMovement PlMovement;

    public int MinTimeInCrazyMode = 5;
    public int MaxTimeInCrazyMode = 15;

    void Start () {
        MoveObjectScript = GetComponent<PlayerColliderBox>();
        HideScript = GetComponent<PlayerHide>();
        PlMovement = GetComponent<PlayerMovement>();
        if (HideScript != null)
            HideScript.enabled = true;
        if (MoveObjectScript != null)
            MoveObjectScript.enabled = false;
    }

    IEnumerator CrazyCountdown()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            TimeInCrazyMode--;
            if (TimeInCrazyMode <= 0)
            {
                PlMovement.MoveSpeed = PlMovement.MoveSpeed * -1;
                SetInnocentGirl();
                StopCoroutine("CrazyCountdown");
            }
        }
    }

    void SetInnocentGirl()
    {
        player = Character.InnocentGirl;
        // enable / disable each character ability
        if (HideScript != null)
            HideScript.enabled = true;
        if (MoveObjectScript != null)
            MoveObjectScript.enabled = false;
    }

    void SetStrongMan()
    {
        player = Character.StrongMan;
        // enable / disable each character ability
        if (HideScript != null)
            HideScript.enabled = false;
        if (MoveObjectScript != null)
            MoveObjectScript.enabled = true;
    }

    public float TimeInCrazyMode;

    void Update()
    {
        // Change player
        if (Input.GetButtonDown("Fire2"))
        {
            if (player == Character.CrazyDude)
            {
                return;
            }
            else
            {                
                CrazyRandom = Random.Range(85, 100);
                var amICrazy = Random.Range(1, 100);
                if (amICrazy >= CrazyRandom)
                {
                    TimeInCrazyMode = Random.Range(5, 15);
                    player = Character.CrazyDude;
                    if (PlMovement != null)
                        PlMovement.MoveSpeed = PlMovement.MoveSpeed * -1;
                    StartCoroutine("CrazyCountdown");
                }
                else
                {
                    // If innocent girl, change to strong man
                    if (player == Character.InnocentGirl)
                    {
                        SetStrongMan();
                    }
                    // if strong man, change to innocent girl
                    else
                    {
                        SetInnocentGirl();
                    }
                }
            }
        }
    }
}
