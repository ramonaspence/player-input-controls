using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public float maxGroundDistance = 0.3f;
    public bool isGrounded;

    void LateUpdate()
    {
        // RayCast returns true if the ray intersects with any colliders
        isGrounded = Physics.Raycast(transform.position, Vector3.down, maxGroundDistance);
    }

    void OnDrawGizmosSelected()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, maxGroundDistance))
            Debug.DrawLine(transform.position, hit.point, Color.white);
        else
            Debug.DrawLine(transform.position, transform.position + Vector3.down * maxGroundDistance, Color.red);
    }

    public static GroundCheck Create(Transform parent)
    {
        GameObject newGroundCheck = new GameObject("Ground Check");
#if UNITY_EDITOR
        UnityEditor.Undo.RegisterCreatedObjectUndo(newGroundCheck, "Created Ground Check");
#endif
        newGroundCheck.transform.parent = parent;
        newGroundCheck.transform.localPosition = Vector3.up * .01f;
        return newGroundCheck.AddComponent<GroundCheck>();
    }
}
