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

        List<GameObject> pool = new List<GameObject>();
        for (int i = 0; i < bullets.Length; i++)
        {
            for (int j = 0; j < amountPool; j++)
            {
                var go = Instantiate(bullets[i], transform.position, Quaternion.identity);
                go.transform.SetParent(transform);
                go.SetActive(false);
                pool.Add(go);
            }
            poolBullet.Add(bullets[i].name.ToString(), pool);
            pool.Clear();
        }
    }
    public GameObject GetPool(string bul)
    {
        ////1
        //List<GameObject> listNumber = new List<GameObject>();
        //listNumber = poolBullet[bul].ToList();
        ////2
        //var all = new List<GameObject>();
        //foreach (KeyValuePair<string, List<GameObject>> kvp in poolBullet)
        //{
        //    all.AddRange(kvp.Value);
        //}
        ////3
        //var all1 = new List<GameObject>();
        //foreach (var value in poolBullet)
        //{
        //    foreach (var item in value.Value)
        //        all1.Add(item);
        //}


        //Debug.Log(bullets[0].name.ToString());
        //Debug.Log(all1.Count);
        //Debug.Log(bul);

        for (int i = 0; i < poolBullet[bul].Count; i++)
        {
            if (!poolBullet[bul][i].activeInHierarchy)
            {
               return poolBullet[bul][i];
            }
        }
        return null;
    }
    public void InvokeEvent(GameObject gam)
    {
        onShootEvent(gam);
    }
    private void ResetBullet(GameObject gam)
    {
        gam.SetActive(false);
        gam = default;
    }
}
