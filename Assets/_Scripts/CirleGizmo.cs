using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirleGizmo : MonoBehaviour
{
    public float radius = 0.1f;
    public Color gizmoColor = Color.red;

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
