using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float rotationSpeed = 0.2f;

    CharacterController controller;
    Camera characterCamera;
    float rotationAngle;

    public CharacterController Controller
    { 
        get { return controller = controller ?? GetComponent<CharacterController>(); }
    }
    public Camera CharacterCamera
    { 
        get { return characterCamera = characterCamera ?? FindObjectOfType<Camera>(); }
    }

    private void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        Vector3 rotatedMovement = Quaternion.Euler(0f, CharacterCamera.transform.rotation.eulerAngles.y, 0f) * movement.normalized;

        Controller.Move(rotatedMovement * movementSpeed * Time.deltaTime);

        if (rotatedMovement)
    }
}
