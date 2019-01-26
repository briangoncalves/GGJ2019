using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour {
    [Header("Box Properties")]
    public float MoveSpeed = 2;

    public bool IsMoving = false;
    public Vector3 MoveSide;

    Transform trans;

    private void Start()
    {
        trans = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        // when moving is set, translate to the set direction
        if (IsMoving)
        {
            trans.Translate(MoveSide * Time.deltaTime * MoveSpeed);
        }
    }

    public void MoveBox(Vector3 Side)
    {
        // Set the move direction, called by the player
        IsMoving = true;
        MoveSide = Side;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if is moving and collide, it stop moving
        if (IsMoving)
        {
            IsMoving = false;
            trans.Translate(Vector3.zero);
        }
    }
}
