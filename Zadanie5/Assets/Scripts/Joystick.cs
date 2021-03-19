using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    public GameObject touchMarker;
    Vector3 targetVector;
    public MoveCharacter moveCharacter;
    Touch[] myTouches;
    void Start()
    {
        touchMarker.transform.position = transform.position;
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            myTouches = Input.touches;
            for (int i = 0; i < Input.touchCount; i++)
            {
                Vector3 touchPos = Input.touches[i].position;
                //Vector3 touchPos = new Vector3(Mathf.Clamp(Input.GetTouch(0).position.x, -7f, 7f), Mathf.Clamp(Input.GetTouch(0).position.y, -7f, 7f), 0);
                targetVector = touchPos - transform.position;
                if (targetVector.magnitude < 151)
                {
                    touchMarker.transform.position = touchPos;
                    moveCharacter.Move(targetVector.x, targetVector.y);
                }
                else
                {
                    touchMarker.transform.position = transform.position;
                    moveCharacter.Move(0, 0);
                }
            }
        }
    }
}
