using UnityEngine;
using System;
using UnityEngine.Events;
public class Patron : BulletsName
{
    public delegate void OnShoot();
    public event OnShoot onShootEvent;
    public GameObject patronEffect;
    public nameBullets nameBul;
    private void OnEnable()
    {
        onShootEvent += ResetBullet;
    }
    private void OnDisable()
    {
        onShootEvent -= ResetBullet;
    }

    [Obsolete]
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {          
            GameObject p = Instantiate(patronEffect, transform.position, Quaternion.identity);  //генерация анимации
            p.GetComponent<ParticleSystem>().Play(); //вопрсоизведение анимации
            Destroy(p, p.GetComponent<ParticleSystem>().duration); //уничтожение анимации     
            onShootEvent?.Invoke();
        }
    }
    //public void ResetBullet()
    //{
    //    gameObject.SetActive(false);
    //}
}
