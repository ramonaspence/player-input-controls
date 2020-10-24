using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAction : MonoBehaviour
{
    [SerializeField]
    GroundCheck groundCheck;
    Rigidbody rigidbody;
    public float jumpStrength = 2;
    public event System.Action Jumped;

    
    void Reset()
    {
        groundCheck = GetComponentInChildren<GroundCheck>();
        if (!groundCheck)
            groundCheck = GroundCheck.Create(transform);
    }

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        if (Input.GetButtonDown("Jump") && groundCheck.isGrounded)
        {
            rigidbody.AddForce(Vector3.up * 100 * jumpStrength);
            Jumped?.Invoke();
        }
        // Trying to make a double jump happen but with this logic the problem is
        // I can press Jump more than twice before the transform.position.y >= 1.5
        // which will then affect the full heighth of the jump.
        if (Input.GetButtonDown("Jump") && !groundCheck.isGrounded && transform.position.y <= 1.5)
        {
            rigidbody.AddForce(new Vector3(0,1,0) * 100 * jumpStrength);

        }
    }
}
