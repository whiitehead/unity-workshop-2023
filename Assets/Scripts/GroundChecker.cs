using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [HideInInspector]
    public bool IsGrounded;
    public Vector2 Offset;
    public float Radius;
    public LayerMask layerMask;

    private void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y) + Offset, Radius, layerMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(new Vector2(transform.position.x, transform.position.y) + Offset, Radius);
    }
}
