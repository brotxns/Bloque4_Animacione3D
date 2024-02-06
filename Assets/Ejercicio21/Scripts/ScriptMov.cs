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
    private bool isGrounded = false;
    public Transform modelTrans;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

        animator.SetBool("estaCorriendo", true);
        //UpdateAnimation();
    }

    private void OnJump()
    {
        if (isGrounded == true)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnDance()
    {
        //animator.SetBool("estaBailando", true); 
    }

    //void UpdateAnimation()
    //{
    //    bool isRunning = Mathf.Abs(moveInput.x) > 0.1f;
    //    bool isJumping = false; // Agrega la lógica para determinar si el personaje está saltando
    //    bool isDancing = false; // Agrega la lógica para determinar si el personaje está bailando

    //    animator.SetBool("Run", isRunning);
    //    animator.SetBool("Jump", isJumping);
    //    animator.SetBool("Dance", isDancing);

    //    if (!isRunning && !isJumping && !isDancing)
    //    {
    //        animator.SetTrigger("Idle");
    //    }
    //}

    void Update()
    {
        Vector3 newVelocity = new Vector3(moveInput.x * speedMovement, rb.velocity.y, moveInput.y * speedMovement);
        newVelocity = transform.rotation * newVelocity;
        rb.velocity = newVelocity;

        if (moveInput.x != 0)
        {
            animator.SetBool("estaCorriendo", true);
            animator.SetBool("estaBailando", false);
        }
        else
        {
            animator.SetBool("estaCorriendo", false);
        }

        if (moveInput.x > 0)
        {
            modelTrans.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveInput.x < 0)
        {
            modelTrans.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (isGrounded == false)
        {
            animator.SetBool("estaSaltando", true);
        }
        else
        {
            //animator.SetBool("estaSaltando," false);
        }
    }
}
