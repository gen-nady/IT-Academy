using UnityEngine;


public class Joystick : MonoBehaviour
{
    public GameObject touchMarker;
    Vector3 targetVector, repeatVector;
    public MoveCharacter moveCharacter;

    bool isActive=false;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch[] myTouches = Input.touches;
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (myTouches[i].position.x <= Screen.width / 2)
                {
                    Vector3 touchPos = Input.touches[i].position;
                    if (!isActive)
                    {
                        transform.position = touchPos;
                        gameObject.SetActive(true);
                        isActive = true;
                    }
                    targetVector = touchPos - transform.position;
                    if (targetVector.magnitude < Screen.width / 14)
                    {
                        touchMarker.transform.position = touchPos;
                        moveCharacter.Move(targetVector.x, targetVector.y);
                        repeatVector = targetVector;
                    }
                    else
                    {
                        moveCharacter.Move(repeatVector.x, repeatVector.y);
                    }
                }
            }
        }
        else 
        {
            touchMarker.transform.position = transform.position;
            isActive = false;
            gameObject.SetActive(false);
        }
    }
}
