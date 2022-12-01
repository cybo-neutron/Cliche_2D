using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] float raycastLength;
    [SerializeField] Transform[] legs;


    public bool isGrounded(){
        foreach(var leg in legs){
            RaycastHit2D hit = Physics2D.Raycast(leg.transform.position, Vector2.down, raycastLength,whatIsGround);
            Debug.DrawRay(leg.position, Vector2.down * raycastLength, Color.blue);
            if(hit)
            {
                return true;
            }
        }

        return false;
    }
}
