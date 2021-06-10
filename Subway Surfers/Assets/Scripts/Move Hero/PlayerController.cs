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
        if (input == 2 && isGrounded)
        {
            Jump();
        }
        if (input == 3)
        {
            Down();
        }
        if (input == 0)
        {
            Right();
        }
        if (input == 1)
        {
            Left();
        }
    }

    void Jump()
    {
        rb.AddForce(new Vector3(0f, forceJump, 0f), ForceMode.Impulse);
    }
    void Down()
    {
        transform.localScale = new Vector3(1f, 0.5f, 1f);
    }
    void Right()
    {
        float rightBand = -4f;
        if (transform.position.z > rightBand)
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + rightBand);
    }
    void Left()
    {
        float leftBand = 4f;
        if (transform.position.z < leftBand)
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + leftBand);
    }
}