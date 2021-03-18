using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour, IMove
{
    public Transform shootPoint;
    public CharacterController characterCon;

    public float speed = 12f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;

    Vector3 velocity;

    float xRotation = 0f;

    private float rotateSpeedModifier = 3f;
    Touch touch;
    public Transform playerBody;

    private void Update()
    {
        Move();
    }
    public void RotationCharacter()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            float touchFingX = touch.deltaPosition.x * rotateSpeedModifier * Mathf.Deg2Rad;
            float touchFingY = touch.deltaPosition.y * rotateSpeedModifier * Mathf.Deg2Rad;
            xRotation += touchFingY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            playerBody.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * touchFingX);
        }
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

    public void Move()
    {
        CheckGround();

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterCon.Move(move * speed * Time.deltaTime);

        Jump();
        Gravity();
    }
}
