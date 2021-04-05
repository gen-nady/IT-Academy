using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour, Spawner
{

    public GameObject coin;
    bool isSpawn=false;
    public void Spawn()
    {
        if (!isSpawn)
        {
            Instantiate(coin, new Vector3(transform.position.x, transform.position.y + 1.5f, 0f), Quaternion.identity);
            isSpawn = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        Spawn();
    }
}
