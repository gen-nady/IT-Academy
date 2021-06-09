using UnityEngine;
using System;
using UnityEngine.Events;
public class Bullet : BulletsName
{
    public GameObject patronEffect;
    [Obsolete]
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            GameObject p = Instantiate(patronEffect, transform.position, Quaternion.identity);  //генерация анимации
            p.GetComponent<ParticleSystem>().Play(); //вопрсоизведение анимации
            Destroy(p, p.GetComponent<ParticleSystem>().duration); //уничтожение анимации     
            CallInvoke();
        }
    }
}
