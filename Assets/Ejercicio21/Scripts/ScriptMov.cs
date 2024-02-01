using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScriptMov : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 moveInput;
    public float movementSpeed;

    
    private Animator animator;
    //private bool canMove = true;  //este canMove creo que equivale a void OnMove

    public float jumpForce = 5f;
    private bool tocaSuelo = false; //isGrounded
    //isWalking = estaCorriendo
    //isJumping = estaSaltando

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    // Update is called once per frame
    void OnJump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        tocaSuelo = false;
        // Configurar el parámetro isJumping en el Animator
        animator.SetBool("estaSaltando", true);
    }

    void OnDance()
    {
        //if con ("no esta conrriendo", "no esta saltando", "esta tocando suelo") 
        animator.SetBool("estaBailando", true);
    }
    

    //private void Update()
    //{
    //    //rb.velocity = new Vector3(moveInput.x * movementSpeed, rb.velocity.y, moveInput.y * movementSpeed);
    //    Vector3 newVelocity = new Vector3(moveInput.x * movementSpeed, rb.velocity.y, moveInput.y * movementSpeed);
    //    newVelocity = transform.rotation * newVelocity;
    //    rb.velocity = newVelocity;
    //}
}
