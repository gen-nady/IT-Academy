using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InstanceBullet : MonoBehaviour
{
    public Transform shootPosition;
    public float speedBullet;
    public UnityEvent bulletEvent;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var go = BulletsManager.Instanse.GetPoolBullet();
            go.transform.position = shootPosition.position;
            go.SetActive(true);
            go.GetComponent<Rigidbody>().velocity = shootPosition.forward * speedBullet;
            bulletEvent.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            var go = BulletsManager.Instanse.GetPoolGranate();
            go.transform.position = shootPosition.position;
            go.SetActive(true);
            go.GetComponent<Rigidbody>().AddForce(shootPosition.forward * speedBullet, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            var go = BulletsManager.Instanse.GetPoolBounce();
            go.transform.position = shootPosition.position;
            go.SetActive(true);
            go.GetComponent<Rigidbody>().velocity = shootPosition.forward * speedBullet;
        }
    }
}
