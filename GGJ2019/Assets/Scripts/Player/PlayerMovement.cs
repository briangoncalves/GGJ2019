using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Header("Player Movement")]
    public float MoveSpeed = 3;
    public bool CanMove = true;
    private Rigidbody rb;
    PlayerSelect anim;
    private CharacterController ch;
	void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<PlayerSelect>();
        ch = GetComponent<CharacterController>();
        moveDirection = transform.position;
    }
    Vector3 moveDirection;

    void Update () {
        // If is hiding, can move is set to false
        if (CanMove)
        {
            //float moveHorizontal = Input.GetAxis("Horizontal");
            //float moveVertical = Input.GetAxis("Vertical");

            //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            ////rb.velocity = movement * MoveSpeed;
            //ch.Move(movement);

         
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= MoveSpeed;
            
            ch.Move(moveDirection * Time.deltaTime);

          //  ch.transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
            //transform.rotation = Quaternion.LookRotation(moveDirection);
            anim.SetCurrentavatarMove(ch.velocity.sqrMagnitude > 0);
        }


    }
}
