﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Header("Player Movement")]
    public float MoveSpeed = 3;
    public bool CanMove = true;
    private Rigidbody rb;
    PlayerSelect anim;
	void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<PlayerSelect>();

    }
	
	void Update () {
        // If is hiding, can move is set to false
        if (CanMove)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rb.velocity = movement * MoveSpeed;

            anim.SetCurrentavatarMove(moveVertical > 0 || moveVertical > 0 || moveVertical < 0 || moveVertical < 0);
        }
    }
}
