using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScriptMov : MonoBehaviour
{
    public float jumpForce = 5;
    private Rigidbody rb;
    private Vector2 moveInput;
    public float movementSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void OnJump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void Update()
    {
        //rb.velocity = new Vector3(moveInput.x * movementSpeed, rb.velocity.y, moveInput.y * movementSpeed);
        Vector3 newVelocity = new Vector3(moveInput.x * movementSpeed, rb.velocity.y, moveInput.y * movementSpeed);
        newVelocity = transform.rotation * newVelocity;
        rb.velocity = newVelocity;
    }
}
