using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using System;
public class BulletsManager : Singleton<BulletsManager>
{
    public int countPool = 20;
    public BulletsName[] bulletsPrefab;
    Dictionary<BulletsName.nameBullets, List<BulletsName>> poolBullets = new Dictionary<BulletsName.nameBullets, List<BulletsName>>();
    private void Awake()
    {
        for (int i = 0; i < bulletsPrefab.Length; i++)
        {
            List<BulletsName> pool = new List<BulletsName>();
            for (int j = 0; j < countPool; j++)
            {
                var go = Instantiate(bulletsPrefab[i], transform.position, Quaternion.identity);
                go.transform.SetParent(transform);
                go.gameObject.SetActive(false);
                pool.Add(go);
            }
            poolBullets.Add(bulletsPrefab[i].nameBul, pool);
        }
    }

    public BulletsName GetBullets(BulletsName.nameBullets bul)
    {
        for (int i = 0; i < poolBullets[bul].Count; i++)
        {
            if (!poolBullets[bul][i].gameObject.activeInHierarchy)
            {
                poolBullets[bul][i].eventBullet += ResetBullet;
                return poolBullets[bul][i];
            }
        }

        BulletsName bullets = null;
        for (int i = 0; i < bulletsPrefab.Length; i++)
        {
            if (bulletsPrefab[i].nameBul == bul)
                bullets = bulletsPrefab[i];
        }

        BulletsName go = Instantiate(bullets, transform.position, Quaternion.identity);
        go.transform.SetParent(transform);
        go.gameObject.SetActive(false);
        poolBullets[bul].Add(go);
        return go;
    
    }
    public void ResetBullet(BulletsName gam)
    {
        gam.gameObject.SetActive(false);
        gam.eventBullet -= ResetBullet;
    }
}
