using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScriptMov : MonoBehaviour
{
    public float speedMovement = 5f;
    public float jumpSpeed = 5f;
    private bool isGrounded = false;

    private Rigidbody rb;
    private Animator animator;
    public Transform modelTrans;

    private Vector2 moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

        animator.SetBool("estaCorriendo", true);
        print(moveInput.x);

        if (moveInput.x == 0)
        {
            animator.SetBool("estaCorriendo", false);
        }
    }

    private void OnJump()
    {
        if (isGrounded == true)
        {
            if (animator != null) animator.SetTrigger("jump");
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
                animator.SetBool("estaBailando", false);
            } 
        }
    }

    private void OnDance()
    {
        if (isGrounded == true)
        {
            animator.SetBool("estaBailando", true);

        }
    }

    private void OnStop()
    {
        if (isGrounded == true)
        {
            animator.SetBool("estaBailando", false);
        }
    }

    void Update()
    {
        Vector3 newVelocity = new Vector3(0, rb.velocity.y, moveInput.x * speedMovement);
        newVelocity = transform.rotation * newVelocity;
        rb.velocity = newVelocity;


        if (moveInput.x > 0)
        {
            modelTrans.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveInput.x < 0)
        {
            modelTrans.rotation = Quaternion.Euler(0, 180, 0);
        }

        if ((moveInput.x != 0) || (moveInput.y != 0))
        {
            animator.SetBool("estaCorriendo", true);
            animator.SetBool("estaBailando", false);
        }
        else
        {
            animator.SetBool("estaCorriendo", false);
        }

        //if (Input.GetKeyDown(KeyCode.E)) 
        //{
            
        //        animator.SetBool("estaBailando", false);
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }


}
