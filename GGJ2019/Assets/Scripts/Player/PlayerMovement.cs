using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [Header("Player Movement")]
    public float MoveSpeed = 3;
    public bool CanMove = true;
    public GameObject avatares;
    PlayerSelect anim;
    private CharacterController ch;
	void Start () {
        anim = GetComponent<PlayerSelect>();
        ch = GetComponent<CharacterController>();
        moveDirection = transform.position;
    }
    Vector3 moveDirection;

    void Update () {
        // If is hiding, can move is set to false
        if (CanMove)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            //avatares.transform.rotation = Quaternion.LookRotation(moveDirection);
            if (moveDirection != Vector3.zero)
                avatares.transform.rotation = Quaternion.Slerp(avatares.transform.rotation, Quaternion.LookRotation(moveDirection.normalized), .4f);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= MoveSpeed;
            ch.Move(moveDirection * Time.deltaTime);
            anim.SetCurrentavatarMove(ch.velocity.sqrMagnitude > 0);
        }


    }
}
