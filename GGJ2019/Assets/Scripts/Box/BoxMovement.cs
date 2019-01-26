using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour {
    [Header("Box Properties")]
    public float MoveSpeed = 2;

    public bool IsMoving = false;
    public Vector3 MoveSide;

    private void Start()
    {
        targetPosition = transform.position;
    }

    public Vector3 targetPosition;
    //public Quaternion targetRotation; //Optional of course
    public float smoothFactor = 2;
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothFactor);
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * smoothFactor);
    }

    public void MoveBox(Vector3 Side)
    {
        // Set the move direction, called by the player
        //IsMoving = true;
        //MoveSide = Side;
        Vector3 myPosition = transform.position;
        Vector3 rayDirection = Side;
        //float rayLengthMeters = WallDistance;
        RaycastHit hitInfo;
        
        if (Physics.Raycast(myPosition, rayDirection, out hitInfo))
        {
            Debug.DrawLine(myPosition, hitInfo.collider.gameObject.transform.position);
            targetPosition = hitInfo.collider.gameObject.transform.position;
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    // if is moving and collide, it stop moving
    //    if (IsMoving)
    //    {
    //        IsMoving = false;
    //        trans.Translate(Vector3.zero);
    //    }
    //}
}
