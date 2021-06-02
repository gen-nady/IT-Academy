using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using System;
public class BulletsManager : Singleton<BulletsManager>
{
    public int amountPool = 3;
    public GameObject[] bullets;
    

    Dictionary<BulletsName.nameBullets, List<GameObject>> poolBullet = new Dictionary<BulletsName.nameBullets, List<GameObject>>();


    private void Awake()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            List<GameObject> pool = new List<GameObject>();
            for (int j = 0; j < amountPool; j++)
            {
                var go = Instantiate(bullets[i], transform.position, Quaternion.identity);
               
                go.transform.SetParent(transform);
                go.SetActive(false);
                pool.Add(go);
            }
            poolBullet.Add((BulletsName.nameBullets)i, pool);
        }
    }


    public GameObject GetPool(BulletsName.nameBullets bul)
    {
        bool isActive = false;
        for (int i = 0; i < poolBullet[bul].Count; i++)
        {
            if (!poolBullet[bul][i].activeInHierarchy)
            {
                isActive = true;

                return poolBullet[bul][i];
            }
        }
        if (!isActive)
        {
            var go = Instantiate(bullets[(int)bul], transform.position, Quaternion.identity);
            go.transform.SetParent(transform);
            go.SetActive(false);
            poolBullet[bul].Add(go);
            return go;
        }
        var goo = Instantiate(bullets[0], transform.position, Quaternion.identity);
        goo.transform.SetParent(transform);
        goo.SetActive(false);
        return goo;

    }

}
