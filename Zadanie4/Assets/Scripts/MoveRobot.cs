using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRobot : MonoBehaviour
{

    public Transform shootPoint;
    Rigidbody body;
    GameObject clone;
    // Start is called before the first frame update
    public CharacterController characterCon;
    public float speed = 12f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;

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
