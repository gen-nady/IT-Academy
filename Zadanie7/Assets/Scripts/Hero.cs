using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
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
    bool isBox=false;

    Vector3 velocity;

    public GameObject boxOne, boxTwo;
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

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Box1") && !isBox)
        {
            boxTwo.transform.position = new Vector3(boxTwo.transform.position.x, boxTwo.transform.position.y + 112, boxTwo.transform.position.z);
            isBox = true;
        }
        if (coll.CompareTag("Box2") && isBox)
        {
            boxOne.transform.position = new Vector3(boxOne.transform.position.x, boxOne.transform.position.y + 112, boxOne.transform.position.z);
            isBox = false;
        }
    }
}

