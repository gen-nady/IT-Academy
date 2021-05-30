using UnityEngine;
using System;
using UnityEngine.Events;
public class Patron : MonoBehaviour
{
    public GameObject patronEffect;
    public BulletsManager.nameBullets nameBul;
    public static event BulletsManager.OnShoot onShootEvent;
    private void OnEnable()
    {
        onShootEvent += ResetBullet;
    }
    [Obsolete]
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {          
            GameObject p = Instantiate(patronEffect, transform.position, Quaternion.identity) as GameObject;  //генерация анимации
            p.GetComponent<ParticleSystem>().Play(); //вопрсоизведение анимации
            Destroy(p, p.GetComponent<ParticleSystem>().duration); //уничтожение анимации         
        }
    }
    public static void InvokeEvent()
    {
        onShootEvent();
    }
    private void ResetBullet()
    {
        gameObject.SetActive(false);
    }
}
