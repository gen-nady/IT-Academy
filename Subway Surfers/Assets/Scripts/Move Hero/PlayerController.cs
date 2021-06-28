using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    InputController inputController;

    [Header("Прыжок")]
    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    LayerMask groundCheckLayer;
    [Tooltip("Rigibody Player")]
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    float forceJump;
    float groundRadius = 0.2f;
    bool isGrounded;
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
            GameManager.Instanse.DeadPlayer();
        }
        if (coll.CompareTag("Coin"))
        {
            coll.gameObject.SetActive(false);
            GameManager.Instanse.ChangeCoin();
        }
    }
}