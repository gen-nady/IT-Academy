using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour, Spawner
{
    public GameObject enemy;
    public float timeSpawn;
    void Start()
    {
        Spawn();
    }
    public void Spawn()
    {
        StartCoroutine(TimeSpawn());
    }
    IEnumerator TimeSpawn()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timeSpawn);
        Spawn();
    }
}
