using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    Vector2 touchOrigin;

    public enum movePlayer { left, right, up, down, nul }
    public movePlayer CheckInput()
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
                    return x > 0 ? movePlayer.right : movePlayer.left;
                }
                else
                {
                    return y > 0 ? movePlayer.up : movePlayer.down;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
            return movePlayer.up;
        if (Input.GetKeyDown(KeyCode.S))
            return movePlayer.down;
        if (Input.GetKeyDown(KeyCode.A))
            return movePlayer.left;
        if (Input.GetKeyDown(KeyCode.D))
            return movePlayer.right;
        return movePlayer.nul;
    }
}
