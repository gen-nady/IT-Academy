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
    public Transform tr
    {
        get
        {
            return transform;
        }
    }
    void Start()
    {
        inputController = GetComponent<InputController>();
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundCheckLayer);
        var input = inputController.CheckInput();
        switch (input)
        {
            case InputController.movePlayer.up:
                if (isGrounded)
                {
                    Jump();
                }
                break;
            case InputController.movePlayer.down:
                Down();
                break;
            case InputController.movePlayer.right:
                Right();
                break;
            case InputController.movePlayer.left:
                Left();
                break;
        }
    }
    void Jump()
    {
        rb.AddForce(new Vector3(0f, forceJump, 0f), ForceMode.Impulse);
    }
    void Down()
    {
        rb.AddForce(new Vector3(0f, -forceJump * 2, 0f), ForceMode.Impulse);
    }
    void Right()
    {
        float rightBand = -4f;
        if (tr.position.z > rightBand && !Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y,
            transform.position.z + rightBand), 0.1f))
            tr.Translate(0f, 0f, rightBand);
    }
    void Left()
    {
        float leftBand = 4f;
        if (tr.position.z < leftBand && !Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y,
            transform.position.z + leftBand), 0.1f))
            tr.Translate(0f, 0f, leftBand);
    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("GameOver"))
        {
            Application.LoadLevel(0);
        }
        if (coll.CompareTag("Coin"))
        {
            coll.gameObject.SetActive(false);
            GameManager.Instanse.ChangeCoin();
        }
    }
}