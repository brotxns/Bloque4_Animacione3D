using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScriptMov : MonoBehaviour
{
    private float movementSpeed = 5;
    private float jumpForce = 7;
    private bool isGrounded = false;
    private bool baile = false;

    private Rigidbody rb;
    private Animator animator;
    public Transform modelTransform;

    private Vector2 moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    private void OnJump()
    {
        if (isGrounded == true)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void OnDance()
    {
        if (isGrounded == true)
        {
            baile = !baile;
        }
    }


    void Update()
    {
        rb.velocity = new Vector3(0, rb.velocity.y, moveInput.x * movementSpeed);

        if (moveInput.x != 0)
        {
            animator.SetBool("estaCorriendo", true);
            animator.SetBool("estaBailando", false);
            animator.SetBool("estaSaltando", false);
        }
        else 
        { 
            animator.SetBool("estaCorriendo", false); 
        }


        if (moveInput.x > 0)
        {
            modelTransform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveInput.x < 0)
        {
            modelTransform.rotation = Quaternion.Euler(0, 180, 0);
        }


        if (isGrounded == false)
        {
            animator.SetBool("estaSaltando", true);
        }
        else
        {
            animator.SetBool("estaSaltando", false);
        }


        if (baile == true)
        {
            animator.SetBool("estaBailando", true);
            jumpForce = 0;
        }
        else
        {
            animator.SetBool("estaBailando", false);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
