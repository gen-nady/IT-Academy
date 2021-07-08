using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Rigidbody))]
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
    Rigidbody rigibodyPlayer;
    [SerializeField]
    float forceJump;
    float groundRadius = 0.2f;
    bool isGrounded;
    [HideInInspector]
    public float factorForceJump = 1f; 
    Transform transformPlayer;
    void Awake()
    {
        inputController = GetComponent<InputController>();
        transformPlayer = GetComponent<Transform>();
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
        rigibodyPlayer.AddForce(new Vector3(0f, forceJump*factorForceJump, 0f), ForceMode.Impulse);
    }
    void Down()
    {
        rigibodyPlayer.AddForce(new Vector3(0f, -forceJump * 2, 0f), ForceMode.Impulse);
    }
    void Right()
    {
        float rightBand = -4f;
        if (transformPlayer.position.z > rightBand && !Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y,
            transform.position.z + rightBand), 0.1f))
            transformPlayer.Translate(0f, 0f, rightBand);
    }
    void Left()
    {
        float leftBand = 4f;
        if (transformPlayer.position.z < leftBand && !Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y,
            transform.position.z + leftBand), 0.1f))
            transformPlayer.Translate(0f, 0f, leftBand);
    }
    IEnumerator HighJumping()
    {
        factorForceJump = 1.6f;
        yield return new WaitForSeconds(GameManager.Instanse.activeBonusTime);
        factorForceJump = 1f;
    }
    IEnumerator Magnet()
    {
        GameManager.Instanse.isMagnet = true;
        yield return new WaitForSeconds(GameManager.Instanse.activeBonusTime);
        GameManager.Instanse.isMagnet = false;
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("GameOver"))
        {
            GameManager.Instanse.DeadPlayer();
        }
        if (coll.CompareTag("Coin"))
        {
            coll.gameObject.SetActive(false);
            AudioManager.Instanse.PickUpCoin();
            GameManager.Instanse.ChangeCoin();
        }
        if (coll.CompareTag("Score"))
        {
            StartCoroutine(GameManager.Instanse.DoubleScore());
            coll.gameObject.SetActive(false);
            AudioManager.Instanse.PickUpBuster();
        }
        if (coll.CompareTag("Jump"))
        {
            StartCoroutine(HighJumping());
            coll.gameObject.SetActive(false);
            AudioManager.Instanse.PickUpBuster();
        }
        if (coll.CompareTag("Magnet"))
        {
            StartCoroutine(Magnet());
            coll.gameObject.SetActive(false);
            AudioManager.Instanse.PickUpBuster();
        }
    }
}