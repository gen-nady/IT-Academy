using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    
    private Vector2 touchOrigin;
    public int CheckInput()
    {
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
                    return  x > 0 ? 0 : 1; 
                }
                else
                {
                    return y > 0 ? 2 : 3; 
                }            
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
            return 2;
        if (Input.GetKeyDown(KeyCode.S))
            return 3;
        if (Input.GetKeyDown(KeyCode.A))
            return 1;
        if (Input.GetKeyDown(KeyCode.D))
            return 0;
        return 5;
    }
}
