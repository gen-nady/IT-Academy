using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRobot : MonoBehaviour
{
    public CharacterController characterCon;
    public float speed = 12f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public LayerMask groundMask;

    bool isGrounded;
    float groundDistance = 0.4f;
    float gravity = -9.8f;
    Vector3 velocity;

    private void Update()
    {
        MoveChar();
    }
    void MoveChar()
    {
        CheckGround();

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterCon.Move(move * speed * Time.deltaTime);

        Jump();
        Gravity();
    }

    void CheckGround()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y == 0f)
            velocity.y = -2f;
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
    void Gravity()
    {
        velocity.y += gravity * Time.deltaTime;
        characterCon.Move(velocity * Time.deltaTime);
    }
}
