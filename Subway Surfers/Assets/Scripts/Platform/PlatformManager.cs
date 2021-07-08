using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : Singleton<PlatformManager>
{
    [Tooltip("Platforms")]
    [SerializeField]
    PlatformController[] platforms;

    Dictionary<PlatformController.lvlDifficult, List<PlatformController>> poolPlatform;

    [Tooltip("Start position platform")]
    [SerializeField]
    Transform startPositionPlatform;

    [Tooltip("Speed platform")]
    public int speedPlatform = 10;

    int countGetPlatform = 2;

    private void Awake()
    {
        poolPlatform = new Dictionary<PlatformController.lvlDifficult, List<PlatformController>>();
        for (int i = 0; i < platforms.Length; i++)
        {
            var platf = Instantiate(platforms[i], startPositionPlatform);
            platf.gameObject.SetActive(false);
            platf.gameObject.transform.SetParent(transform);
            if (!poolPlatform.ContainsKey(platf.lvl))
                poolPlatform.Add(platf.lvl, new List<PlatformController>());
            poolPlatform[platf.lvl].Add(platf);
        }
    }

    PlatformController GetPlatform(PlatformController.lvlDifficult lvl)
    {
        List<PlatformController> notActivePlatform = new List<PlatformController>();
        for (int i = 0; i < poolPlatform[lvl].Count; i++)
        {
            if (!poolPlatform[lvl][i].gameObject.activeInHierarchy)
            {
                notActivePlatform.Add(poolPlatform[lvl][i]);
            }
        }
        int random = Random.Range(0, notActivePlatform.Count);
        return notActivePlatform[random];
    }
    void ChangePlatformSpeed()
    {
        countGetPlatform--;
        if (countGetPlatform == 0)
        {
            countGetPlatform = 2;
            int factor = 1;
            speedPlatform += factor;
        }
    }
    public void ReloadPlatform()
    {
        speedPlatform = 10;
        countGetPlatform = 2;
        GameManager.Instanse.startPlatform.gameObject.SetActive(false); //временное решение со стартовой плаформой. ѕотом будет обычна€ сразу со старта
        for (PlatformController.lvlDifficult lvl = PlatformController.lvlDifficult.easy;
            lvl <= PlatformController.lvlDifficult.hard; lvl++)
        {
            for (int i = 0; i < poolPlatform[lvl].Count; i++)
            {
                if (poolPlatform[lvl][i].gameObject.activeInHierarchy)
                {
                    poolPlatform[lvl][i].gameObject.SetActive(false);
                }
            }
        }
    }
    public void EmergingPlatform()
    {
        ChangePlatformSpeed();
        PlatformController.lvlDifficult lvl = (PlatformController.lvlDifficult)Random.Range(0, 2);
        float startPosition = 49.8f;
        PlatformController platf = GetPlatform(lvl);
        platf.transform.position = new Vector3(startPositionPlatform.position.x + startPosition,
            startPositionPlatform.position.y, startPositionPlatform.position.z);
        for (int i = 0; i < platf.gameObject.transform.childCount; i++)
        {
            platf.gameObject.transform.GetChild(i).gameObject.SetActive(true);
        }
        platf.gameObject.SetActive(true);
    }
    public void DisablePlatform(PlatformController platf)
    {
        platf.gameObject.SetActive(false);
    }
}
