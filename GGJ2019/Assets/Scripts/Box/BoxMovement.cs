using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour {
    [Header("Box Properties")]
    public float MoveSpeed = 2;

    public bool IsMoving = false;
    public Vector3 MoveSide;
    public Direction direct;

    private void Start()
    {
        targetPosition = transform.position;
    }

    public Vector3 targetPosition;
    public Vector3 originalPos;
    public float smoothFactor = 2;
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smoothFactor);
        Debug.DrawLine(originalPos, targetPosition);
    }

    public void MoveBox()
    {
        if (direct == Direction.None) return;
        Vector3 myPosition = transform.position;
        Vector3 rayDirection = direct == Direction.Back ? transform.forward
            : direct == Direction.Forward ? -transform.forward
            : direct == Direction.Left ? transform.right
            : -transform.right;
        RaycastHit hitInfo;
        if (Physics.Raycast(myPosition, rayDirection, out hitInfo))
        {
            targetPosition = hitInfo.point;
            Vector3 bound = GetComponent<Renderer>().bounds.extents;
            Vector3 r = new Vector3();
            r.x = bound.x * rayDirection.x;
            r.y = bound.y * rayDirection.y;
            r.z = bound.z * rayDirection.z;
            targetPosition -= r;
        }
        originalPos = transform.position;
    }
}
