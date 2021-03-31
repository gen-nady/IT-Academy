using UnityEngine;

public class MoveCharacter : MonoBehaviour, IMove
{
    public Transform shootPoint;
    public CharacterController characterCon;

    public float speed = 12f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    public bool isGrounded;

    float velocity;
    public GameObject joystick;

    private float rotateSpeedModifier = 3f;
    
    public Transform playerBody;
    void Start()
    {
        Input.multiTouchEnabled = true;
    }
    private void Update()
    {
        RotationCharacter();
        CheckGround();
        Gravity();
    }
    public void RotationCharacter()
    {
        if (Input.touchCount > 0)
        {
            Touch[] myTouches = Input.touches;
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (myTouches[i].position.x > Screen.width / 2)
                {
                    float xRotation = 0f;
                    float touchFingX = Input.touches[i].deltaPosition.x * rotateSpeedModifier * Mathf.Deg2Rad;
                    float touchFingY = Input.touches[i].deltaPosition.y * rotateSpeedModifier * Mathf.Deg2Rad;
                    xRotation += touchFingY;
                    xRotation = Mathf.Clamp(xRotation, -90f, 90f);
                    playerBody.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
                    transform.Rotate(Vector3.up * touchFingX);
                }
                else
                {
                    joystick.SetActive(true);
                }
            }
        }
    }
    void CheckGround()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity == 0f)
            velocity = -2f;
    }
    public void Jump()
    {
        if (isGrounded)
            velocity =  Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
    void Gravity()
    {
        velocity += gravity * Time.deltaTime;
        characterCon.Move(new Vector3(0f,velocity,0f) * Time.deltaTime);
    }
    public void Move(float x, float z)
    {
        if (Input.touchCount > 0)
        {           
            Vector3 vectorMove = transform.right * x + transform.forward * z;
            characterCon.Move(vectorMove * speed * Time.deltaTime);            
        }
    }
}
