using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InstanceBullet : MonoBehaviour
{
    public Transform shootPosition;
    public float speedBullet;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject go = BulletsManager.Instanse.GetPool(BulletsManager.Instanse.bullets[0].name);
            go.transform.position = shootPosition.position;
            go.SetActive(true);
            go.GetComponent<Rigidbody>().velocity = shootPosition.forward * speedBullet;
            AudioManager.Instanse.OnShoot();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject go = BulletsManager.Instanse.GetPool(BulletsManager.Instanse.bullets[1].name);
            go.transform.position = shootPosition.position;
            go.SetActive(true);
            go.GetComponent<Rigidbody>().AddForce(shootPosition.forward * speedBullet, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            GameObject go = BulletsManager.Instanse.GetPool(BulletsManager.Instanse.bullets[2].name);
            go.transform.position = shootPosition.position;
            go.SetActive(true);
            go.GetComponent<Rigidbody>().velocity = shootPosition.forward * speedBullet;
        }
    }
}
