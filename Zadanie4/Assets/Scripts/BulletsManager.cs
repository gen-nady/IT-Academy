using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class BulletsManager : Singleton<BulletsManager>
{
    public int amountPool = 20;
    public GameObject[] bullets;


    List<GameObject> poolBullets = new List<GameObject>();
    List<GameObject> poolGranate = new List<GameObject>();
    List<GameObject> poolBounce = new List<GameObject>();


    private void Awake()
    {
        for (int i = 0; i < amountPool; i++)
        {
            for (int j = 0; j < bullets.Length; j++)
            {
                var go = Instantiate(bullets[j], transform.position, Quaternion.identity);

                go.transform.SetParent(transform);
                go.SetActive(false);
                if (j == 0)                
                    poolBullets.Add(go);                           
                else if (j == 1)
                    poolGranate.Add(go);
                else if (j == 2)
                    poolBounce.Add(go);
            }
        }
    }
    public GameObject GetPoolBullet()
    {
        for (int i = 0; i < poolBullets.Count; i++)
        {
            if (!poolBullets[i].activeInHierarchy)
            {
                return poolBullets[i];
            }
        }
        return null;
    }
    public GameObject GetPoolGranate()
    {
        for (int i = 0; i < poolGranate.Count; i++)
        {
            if (!poolGranate[i].activeInHierarchy)
            {
                return poolGranate[i];
            }
        }
        return null;
    }
    public GameObject GetPoolBounce()
    {
        for (int i = 0; i < poolBounce.Count; i++)
        {
            if (!poolBounce[i].activeInHierarchy)
            {
                return poolBounce[i];
            }
        }
        return null;
    }
}
