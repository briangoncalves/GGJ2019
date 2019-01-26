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
        if (IsMoving)
        {
            trans.Translate(MoveSide * Time.deltaTime * MoveSpeed);
        }
    }

    public void MoveBox(Vector3 Side)
    {
        IsMoving = true;
        MoveSide = Side;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (IsMoving)
        {
            IsMoving = false;
            trans.Translate(Vector3.zero);
        }
    }
}
