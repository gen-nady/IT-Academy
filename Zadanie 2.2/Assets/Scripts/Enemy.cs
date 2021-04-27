using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 moveDir = new Vector3(1f, 0f, 0f);
    float speed = 5f;
    void Update()
    {
        transform.Translate(moveDir * speed * Time.deltaTime); //движение объекта
        if (transform.position.x > 30f)
        {
            moveDir.x = -1f;
        }
        else if (transform.position.x < -30f)
        {
            moveDir.x =  1f;
        }
    }
}
