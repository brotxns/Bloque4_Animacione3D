using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScriptMov : MonoBehaviour
{
    public float speedMovement = 5f;
    private Rigidbody rb;
    private Vector2 moveInput;
    private Animator animator;
    public float jumpForce = 5f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        UpdateAnimation();
    }

    private void OnJump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        // L�gica de salto aqu�
        animator.SetTrigger("Jump");
        UpdateAnimation();
    }

    private void OnDance()
    {
        // L�gica de baile aqu�
        animator.SetTrigger("Dance");
        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        bool isRunning = Mathf.Abs(moveInput.x) > 0.1f;
        bool isJumping = false; // Agrega la l�gica para determinar si el personaje est� saltando
        bool isDancing = false; // Agrega la l�gica para determinar si el personaje est� bailando

        animator.SetBool("Run", isRunning);
        animator.SetBool("Jump", isJumping);
        animator.SetBool("Dance", isDancing);

        if (!isRunning && !isJumping && !isDancing)
        {
            animator.SetTrigger("Idle");
        }
    }

    void Update()
    {
        Vector3 newVelocity = new Vector3(moveInput.x * speedMovement, rb.velocity.y, moveInput.y * speedMovement);
        newVelocity = transform.rotation * newVelocity;
        rb.velocity = newVelocity;
    }
}
