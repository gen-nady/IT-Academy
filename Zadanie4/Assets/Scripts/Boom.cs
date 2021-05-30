using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public float radius = 5.0F;
    public float power = 10.0F;
    public GameObject boomEffect;
    [System.Obsolete]
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            GameObject p = Instantiate(boomEffect, transform.position, Quaternion.identity) as GameObject;  //генерация анимации
            p.GetComponent<ParticleSystem>().Play(); //вопрсоизведение анимации
            Destroy(p, p.GetComponent<ParticleSystem>().duration); //уничтожение анимации
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
                    AudioManager.Instanse.OnBoom();
                }
            }
            //BulletsManager.Instanse.InvokeEvent(gameObject);
        }
    }
}
