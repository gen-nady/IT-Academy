using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public float radius = 5.0F;
    public float power = 10.0F;
    public ParticleSystem ps;
    public GameObject go;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ps.transform.position = transform.position;
            ps.Play(true);
            //go.transform.position = transform.position;
            //go.SetActive(true);
            Debug.Log("Check");
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
                    
                }
            }
        }
    }
}
