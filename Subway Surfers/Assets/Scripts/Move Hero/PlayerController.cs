using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    InputController inputController;
    private bool isGrounded;
    public Transform groundCheck;
    private float groundRadius = 0.2f;
    public LayerMask groundCheckLayer;
    public Rigidbody rb;
    public CapsuleCollider cpsCollider;
    public float forceJump = 375f;

    void Start()
    {
        inputController = new InputController();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundCheckLayer);
        int input = inputController.CheckInput();
        if (input == 2  && isGrounded)
        {
            Jump();
        }
        if (input == 3)
        {
            transform.localScale = new Vector3(1f, 0.5f,1f);           
        }
        if (input == 0)
        {
            if (transform.position.z > -4f)
                transform.position.z = -4f;
        }
    }
    void Jump()
    {
        rb.AddForce(new Vector3(0, forceJump, 0), ForceMode.Impulse);
    }
}