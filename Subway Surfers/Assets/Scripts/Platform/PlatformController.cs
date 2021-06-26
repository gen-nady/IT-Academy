using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float speedPlatform;
    Vector3 directionPlatform;
    public lvlDifficult lvl;
    public enum lvlDifficult
    {
        easy, medium, hard

    }
    void Awake()
    {
        directionPlatform = new Vector3(-1f, 0f, 0f);
    }
    void Update()
    {
        transform.Translate(directionPlatform * speedPlatform * Time.deltaTime);
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.CompareTag("StartPosition"))
        {
            PlatformManager.Instanse.EmergingPlatform();
        }
        if (coll.gameObject.CompareTag("EndPosition"))
        {
            PlatformManager.Instanse.DisablePlatform(this);
        }
    }
}
