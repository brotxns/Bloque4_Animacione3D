using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacMovPruebas : MonoBehaviour
{
    //esto se pone al empty del personaje. hay que poner en componentes un capsule collider, un rigidbody con las constrains de rotacion y un player input
    public float speedMovement = 5f;
    //private float jumpForce = 7;
    //private bool isGrounded = true;

    private Rigidbody rb;
    private Animator animator;
    public Transform modelTransform;

    private Vector2 moveInput;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        

        
    }

    //private void OnJump()
    //{
      
    //        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
       
    //}

    // Update is called once per frame
    void Update()
    {
        Vector3 newVelocity = new Vector3(moveInput.x * speedMovement, rb.velocity.y, moveInput.y * speedMovement);
        newVelocity = transform.rotation * newVelocity;
        rb.velocity = newVelocity;

        if (moveInput.x != 0 || moveInput.y != 0)
        {
            animator.SetBool("estaCorriendo", true);
            animator.SetBool("estaBailando", false);
            animator.SetBool("estaSaltando", false);
        }
        else
        {
            animator.SetBool("estaCorriendo", false);
            animator.SetBool("estaBailando", false);
            animator.SetBool("estaSaltando", false);
        }


        //if (isGrounded == false)
        //{
        //    animator.SetBool("estaSaltando", true);
        //}
        //else
        //{
        //    animator.SetBool("estaSaltando", false);
        //}
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Ground")
    //    {
    //        isGrounded = true;
    //    }
    //}
    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Ground")
    //    {
    //        isGrounded = false;
    //    }
    //}
   

    

}
