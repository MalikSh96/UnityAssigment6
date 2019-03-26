using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public Vector3 jump;
    public float jumpForce = 2.0f;

    public bool isGrounded = true;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        Debug.Log(isGrounded);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Update()
    {

        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
