using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePatron1 : MonoBehaviour
{
    public float timeout = 0.1f;
    private float curTimeout;
    public Transform shootPosition;
    public Rigidbody bullet, granate, ball;
    public float speedBullet;
    public float destroyBullet = 3f;
    // Start is called before the first frame update
    // Update is called once per frame
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
