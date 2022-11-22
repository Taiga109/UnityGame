using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    [SerializeField]
    float groundCheckRadius = 0.5f;
    [SerializeField]
    float groundCheckOffsetY = 0.5f;
    [SerializeField]
    float groundCheckDistance = 0.2f;
    [SerializeField]
    LayerMask groundLayers = 0;

    RaycastHit hit;

    bool CheckGroundStatus()
    {
        return Physics.SphereCast(transform.position + groundCheckOffsetY * Vector3.up,
            groundCheckRadius, Vector3.down, out hit, groundCheckDistance, groundLayers,
            QueryTriggerInteraction.Ignore);
    }
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
