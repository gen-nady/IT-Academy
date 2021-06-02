using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletsName : MonoBehaviour
{
    public  enum nameBullets
    {
        bullets = 0, granate, bounce
    }
    public virtual void ResetBullet()
    {
        gameObject.SetActive(false);
    }
}
