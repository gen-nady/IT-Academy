using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
public class BulletsManager : Singleton<BulletsManager>
{
    public int amountPool = 20;
    public GameObject[] bullets;

    public delegate void OnShoot(GameObject gam);
    public static event OnShoot onShootEvent;

    Dictionary<string, List<GameObject>> poolBullet = new Dictionary<string, List<GameObject>>();

    private void Awake()
    {
        onShootEvent += ResetBullet;

        
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
            poolBullet.Add(bullets[i].name.ToString(), pool);
        }
    }
    public GameObject GetPool(string bul)
    {
        var listNumber = new List<GameObject>();
        foreach (var value in poolBullet)
        {
            foreach (var item in value.Value)
                listNumber.Add(item);
        }

        bool isActive = false;
        for (int i = 0; i < poolBullet[bul].Count; i++)
        {

            if (!poolBullet[bul][i].activeInHierarchy)
            {
               isActive = true;
               return poolBullet[bul][i];
            }
        }
        //if (!isActive)
        //{
        //    amountPool++;
        //    var go = Instantiate(bullets[poolBullet[bul].], transform.position, Quaternion.identity);
        //    go.transform.SetParent(transform);
        //    go.SetActive(false);
        //    poolBullet[bul][amountPool-1].
        //}
        return null;
    }
    public void InvokeEvent(GameObject gam)
    {
        onShootEvent(gam);
    }
    private void ResetBullet(GameObject gam)
    {
        gam.SetActive(false);
       
        Debug.Log("Hi");
    }
}
