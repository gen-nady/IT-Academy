using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletsName : MonoBehaviour
{
    public delegate void EventBullet(BulletsName bul);
    public event EventBullet eventBullet;
    public nameBullets nameBul;
    public  enum nameBullets
    {
        bullets = 0, granate, bounce
    }
    public virtual void ResetBullet()
    {
        gameObject.SetActive(false);
    }
    protected void CallInvoke()
    {
        eventBullet?.Invoke(this);
    }
}
