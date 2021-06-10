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
            BulletsName go = BulletsManager.Instanse.GetBullets(BulletsName.nameBullets.bullets);
            go.transform.position = shootPosition.position;
            go.gameObject.SetActive(true);
            go.GetComponent<Rigidbody>().velocity = shootPosition.forward * speedBullet;
            AudioManager.Instanse.OnShoot();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            BulletsName go = BulletsManager.Instanse.GetBullets(BulletsName.nameBullets.granate);
            go.transform.position = shootPosition.position;
            go.gameObject.SetActive(true);
            go.GetComponent<Rigidbody>().AddForce(shootPosition.forward * speedBullet, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            BulletsName go = BulletsManager.Instanse.GetBullets(BulletsName.nameBullets.bounce);
            go.transform.position = shootPosition.position;
            go.gameObject.SetActive(true);
            go.GetComponent<Rigidbody>().velocity = shootPosition.forward * speedBullet;
        }
    }
}
