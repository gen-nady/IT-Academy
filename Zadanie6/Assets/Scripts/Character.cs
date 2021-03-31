using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float movementSpeed = 2f;
    public float sprintSpeed = 5f;
    public float rotationSpeed = 0.2f;
    public float animationBlendSpeed = 0.2f;
    public float jumpSpeed = 7f;

    CharacterController controller;
    Camera characterCamera;
    Animator animator;
    float rotationAngle;
    float targetAnimationSpeed = 0f;
    bool isSprint = false;

    float speedY = 0f;
    float gravity = -9.8f;
    bool isJump = false;
    bool isSpawn = false;
    public CharacterController Controller
    {
        get { return controller = controller ?? GetComponent<CharacterController>(); }
    }
    public Camera CharacterCamera
    {
        get { return characterCamera = characterCamera ?? FindObjectOfType<Camera>(); }
    }
    public Animator CharacterAnimator
    {
        get { return animator = animator ?? GetComponent<Animator>(); }
    }
    private void Awake()
    {
        CharacterAnimator.Play("Spawn");
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        var anim = CharacterAnimator.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(anim.length);
        CharacterAnimator.SetTrigger("Spawn");
        isSpawn = true;
    }

    private void Update()
    {
        if (isSpawn)
        {
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");

            if (Input.GetKey(KeyCode.Space) && !isJump)
            {
                isJump = true;
                CharacterAnimator.SetTrigger("Jump");
                speedY += jumpSpeed;
            }
            if (!Controller.isGrounded)
            {
                speedY += gravity * Time.deltaTime;
            }
            else if (speedY < 0f)
            {
                speedY = 0f;
            }

            CharacterAnimator.SetFloat("SpeedY", speedY / jumpSpeed);
            if (isJump && speedY < 0f)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, Vector3.down, out hit, 2f, LayerMask.GetMask("Default")))
                {
                    isJump = false;
                    CharacterAnimator.SetTrigger("Land");
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                int rand = Random.Range(-1, 2);
                CharacterAnimator.SetFloat("Attack", rand);
                CharacterAnimator.SetTrigger("Attackk");
            }
            if (Input.GetKey(KeyCode.E) && !isJump)
            {
                CharacterAnimator.SetTrigger("Death");
            }
            isSprint = Input.GetKey(KeyCode.LeftShift);
            Vector3 movement = new Vector3(horizontal, 0f, vertical);
            Vector3 rotatedMovement = Quaternion.Euler(0f, CharacterCamera.transform.rotation.eulerAngles.y, 0f) * movement.normalized;
            Vector3 verticalMovement = Vector3.up * speedY;
            float currentSpeed = isSprint ? sprintSpeed : movementSpeed;
            //Controller.Move(((verticalMovement + rotatedMovement) * currentSpeed) * Time.deltaTime);
            Vector3 move = transform.right * horizontal + transform.forward * vertical;
            Controller.Move(movement * currentSpeed * Time.deltaTime);

            if (rotatedMovement.sqrMagnitude > 0f)
            {
                rotationAngle = Mathf.Atan2(rotatedMovement.x, rotatedMovement.z) * Mathf.Rad2Deg;
                targetAnimationSpeed = isSprint ? 1f : 0.5f;
            }
            else
            {
                targetAnimationSpeed = 0f;
            }
            CharacterAnimator.SetFloat("Speed", Mathf.Lerp(CharacterAnimator.GetFloat("Speed"), targetAnimationSpeed, animationBlendSpeed));
            Quaternion currentRotation = Controller.transform.rotation;
            Quaternion targetRotation = Quaternion.Euler(0f, rotationAngle, 0f);
            Controller.transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, rotationSpeed);
        }
    }
}
