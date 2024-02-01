using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacMovPruebas : MonoBehaviour
{
    //esto se pone al empty del personaje. hay que poner en componentes un capsule collider, un rigidbody con las constrains de rotacion y un player input
    public float speedMovement = 5f;
    private Rigidbody rb;
    private Vector2 moveInput;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newVelocity = new Vector3(moveInput.x * speedMovement, rb.velocity.y, moveInput.y * speedMovement);
        newVelocity = transform.rotation * newVelocity;
        rb.velocity = newVelocity;
    }
}
