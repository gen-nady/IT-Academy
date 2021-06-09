using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 touchOrigin;

    private bool isGrounded = true;
    public Transform groundCheck;
    private float groundRadius = 0.2f;
    public LayerMask groundCheckLayer;
    public Rigidbody rb;
    public float forceJump = 375f;

    void Start()
    {
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundCheckLayer);
        int horizontal = 0;
        int vertical = 0;
        if (Input.touchCount > 0)
        {
            Touch myTouch = Input.touches[0];
            if (myTouch.phase == TouchPhase.Began)
            {
                touchOrigin = myTouch.position;
            }
            else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0)
            {
                Vector2 touchEnd = myTouch.position;
                float x = touchEnd.x - touchOrigin.x;
                float y = touchEnd.y - touchOrigin.y;
                touchOrigin.x = -1;
                if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    horizontal = x > 0 ? 1 : -1;
                }
                else
                {
                    vertical = y > 0 ? 1 : -1;
                }
            }
        }

        if (vertical > 0  && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(new Vector3(0, forceJump, 0), ForceMode.Impulse);
    }
}