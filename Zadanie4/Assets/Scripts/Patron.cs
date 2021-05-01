using UnityEngine;

public class Patron : MonoBehaviour
{
    public GameObject patronEffect;

    [System.Obsolete]
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            GameObject p = Instantiate(patronEffect, transform.position, Quaternion.identity) as GameObject;  //генерация анимации
            p.GetComponent<ParticleSystem>().Play(); //вопрсоизведение анимации
            Destroy(p, p.GetComponent<ParticleSystem>().duration); //уничтожение анимации          
        }
    }
}
