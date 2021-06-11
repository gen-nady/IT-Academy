using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float speedPlatform;
    Vector3 directionPlatform;

    void Awake()
    {
        directionPlatform = new Vector3(-1f, 0f, 0f);
    }
    void Update()
    {
        transform.Translate(directionPlatform * speedPlatform * Time.deltaTime);
    }
}
