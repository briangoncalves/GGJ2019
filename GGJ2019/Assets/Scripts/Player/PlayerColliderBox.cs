using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderBox : MonoBehaviour {
    [Header("Box Properties")]
    public float CollisionTimer = 2;

    private float CollidedTimer = 0;

    private void OnCollisionEnter(Collision collision)
    {
        CollidedTimer = 0;
    }

    private void OnCollisionStay(Collision Collision)
    {
        // if the script is not enabled (not the strong man), ignore it
        if (!enabled) return;
        // Check if it is colliding with a box
        if (Collision.collider.gameObject.layer.Equals(LayerMask.NameToLayer("Box")))
        {
            var boxMovement = Collision.collider.GetComponent<BoxMovement>();
            if (boxMovement != null)
            {
                // if the box is not moving
                if (!boxMovement.IsMoving)
                {
                    // get force applied (forcing the box in a direction)
                    float moveHorizontal = Input.GetAxis("Horizontal");
                    float moveVertical = Input.GetAxis("Vertical");
                    if (moveHorizontal != 0 || moveVertical != 0)
                    {
                        CollidedTimer += Time.deltaTime;
                        if (CollidedTimer >= CollisionTimer)
                        {
                            // Get the hit direction on the box
                            var hitDirection = ReturnDirection(gameObject, Collision.collider.gameObject);
                            // depending on hit direction and if force still applied, call the move of the box
                            // on the correct direction
                            if (hitDirection == HitDirection.Left && moveHorizontal == 1)
                            {
                                if (!CheckWallAtBox(Collision.collider.gameObject, transform.right))
                                {
                                    boxMovement.MoveBox(transform.right);
                                }
                            }
                            else if (hitDirection == HitDirection.Right && moveHorizontal == -1)
                            {
                                if (!CheckWallAtBox(Collision.collider.gameObject, -transform.right))
                                {
                                    boxMovement.MoveBox(-transform.right);
                                }
                            }
                            else if (hitDirection == HitDirection.Forward && moveVertical == -1)
                            {
                                if (!CheckWallAtBox(Collision.collider.gameObject, -transform.forward))
                                {
                                    boxMovement.MoveBox(-transform.forward);
                                }
                            }
                            else if (hitDirection == HitDirection.Back && moveVertical == 1)
                            {
                                if (!CheckWallAtBox(Collision.collider.gameObject, transform.forward))
                                {
                                    boxMovement.MoveBox(transform.forward);
                                }
                            }
                        }
                    }
                    else
                    {
                        CollidedTimer = 0;
                    }
                }
            }
        }
    }

    private bool CheckWallAtBox(GameObject box, Vector3 positionToPush)
    {
        var result = false;
        Vector3 myPosition = box.transform.position;
        Vector3 rayDirection = positionToPush;
        float rayLengthMeters = 0.3f;
        RaycastHit hitInfo;

        if (Physics.Raycast(myPosition, rayDirection, out hitInfo, rayLengthMeters))
        {
            if (hitInfo.collider.gameObject.layer.Equals(LayerMask.NameToLayer("Wall")))
            {
                return true;
            }
        }
        return result;
    }

    private enum HitDirection { None, Top, Bottom, Forward, Back, Left, Right }
    private HitDirection ReturnDirection(Vector3 Object, GameObject ObjectHit)
    {
        HitDirection hitDirection = HitDirection.None;
        Vector3 HitPosition = Object - ObjectHit.transform.position;
        if (HitPosition.z > 0.3)
            hitDirection = HitDirection.Forward;
        else if (HitPosition.z < -0.3)
            hitDirection = HitDirection.Back;
        else if (HitPosition.x > 0.3)
            hitDirection = HitDirection.Right;
        else if (HitPosition.x < -0.3)
            hitDirection = HitDirection.Left;
        return hitDirection;
    }
    private HitDirection ReturnDirection(GameObject Object, GameObject ObjectHit)
    {
        return ReturnDirection(Object.transform.position, ObjectHit);
    }    
}
