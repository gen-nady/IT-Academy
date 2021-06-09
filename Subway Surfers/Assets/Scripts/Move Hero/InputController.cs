using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private Vector2 touchOrigin;
    public int CheckInput()
    {
#if PLATFORM_ANDROID
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
                    horizontal = x > 0 ? 0 : 1;
                    return horizontal;
                }
                else
                {
                    vertical = y > 0 ? 2 : 3;
                    return vertical;
                }
                
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
            return 2;
        if (Input.GetKeyDown(KeyCode.S))
            return 3;
        
        return 0;
#endif  

    }
}
