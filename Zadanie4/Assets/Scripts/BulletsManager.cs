using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsManager : Singleton<BulletsManager>
{
    public float timeout = 0.1f;
    public Transform shootPosition;
    public Rigidbody bullet, granate, ball;
    public float speedBullet;

    private float curTimeout;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            curTimeout += Time.deltaTime;
            if (curTimeout > timeout)
            {
                curTimeout = 0;
                Rigidbody cloneBullet = Instantiate(bullet, shootPosition.position, Quaternion.identity) as Rigidbody;
                cloneBullet.velocity = shootPosition.forward * speedBullet;
            }
            else
            {
                curTimeout = timeout + 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Rigidbody cloneGranate = Instantiate(granate, shootPosition.position, Quaternion.identity) as Rigidbody;
            cloneGranate.AddForce(shootPosition.forward * speedBullet, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Rigidbody cloneBall = Instantiate(ball, shootPosition.position, Quaternion.identity) as Rigidbody;
            cloneBall.velocity = shootPosition.forward * speedBullet;

        }
    }
}
