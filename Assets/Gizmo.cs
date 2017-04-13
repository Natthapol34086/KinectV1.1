using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour {

    public float gizmoSize = 0.75f;
    public Color gizomColor = Color.yellow;

    void DrDrawGizmo()
    {
        Gizmos.color = gizomColor;
        Gizmos.DrawWireSphere(transform.position, gizmoSize);
    }
}
