using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using System;
public class BulletsManager : Singleton<BulletsManager>
{
    public int amountPool = 20;
    public GameObject[] bullets;
    public delegate void OnShoot();

    public enum nameBullets
    {
        bullets = 0, granate, bounce
    }
    Dictionary<nameBullets, List<GameObject>> poolBullet = new Dictionary<nameBullets, List<GameObject>>();


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
            poolBullet.Add((nameBullets)i, pool);
        }
    }


    public GameObject GetPool(nameBullets bul)
    {
        //bool isActive = false;
        for (int i = 0; i < poolBullet[bul].Count; i++)
        {
            if (!poolBullet[bul][i].activeInHierarchy)
            {
                //isActive = true;

                return poolBullet[bul][i];
            }
        }
        //if (!isActive)
        //{
        //    amountPool++;
        //    var go = Instantiate(bullets[poolBullet[bul].], transform.position, Quaternion.identity);
        //    go.transform.SetParent(transform);
        //    go.SetActive(false);
        //    poolBullet[bul][amountPool - 1].
        //}
        return null;
    }

}
