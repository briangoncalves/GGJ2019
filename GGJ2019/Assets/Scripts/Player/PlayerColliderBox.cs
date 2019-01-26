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
        if (Collision.collider.gameObject.layer.Equals(LayerMask.NameToLayer("Box")))
        {
            //Debug.Log("Collision Stay");
            //Debug.Log("Collision: " + gameObject.name + " Collider: " + Collision.collider.gameObject.name);
            var boxMovement = Collision.collider.GetComponent<BoxMovement>();
            if (boxMovement != null)
            {
                if (!boxMovement.IsMoving)
                {
                    float moveHorizontal = Input.GetAxis("Horizontal");
                    float moveVertical = Input.GetAxis("Vertical");
                    if (moveHorizontal != 0 || moveVertical != 0)
                    {                        
                        CollidedTimer += Time.deltaTime;
                        if (CollidedTimer >= CollisionTimer)
                        {
                            var hitDirection = ReturnDirection(gameObject, Collision.collider.gameObject);
                            Debug.Log("Hit Direction: " + hitDirection.ToString());
                            Vector3 HitPosition = gameObject.transform.position - Collision.collider.transform.position;
                            Debug.Log(HitPosition.ToString());
                            //Debug.Log(moveVertical.ToString() + " - " + moveHorizontal.ToString());
                            if (hitDirection == HitDirection.Left && moveHorizontal == 1)
                                boxMovement.MoveBox(transform.right);
                            else if (hitDirection == HitDirection.Right && moveHorizontal == -1)
                                boxMovement.MoveBox(-transform.right);
                            else if (hitDirection == HitDirection.Forward && moveVertical == -1)
                                boxMovement.MoveBox(-transform.forward);
                            else if (hitDirection == HitDirection.Back && moveVertical == 1)
                                boxMovement.MoveBox(transform.forward);
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

    private enum HitDirection { None, Top, Bottom, Forward, Back, Left, Right }
    private HitDirection ReturnDirection(GameObject Object, GameObject ObjectHit)
    {

        HitDirection hitDirection = HitDirection.None;
        Vector3 HitPosition = Object.transform.position - ObjectHit.transform.position;
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
}
