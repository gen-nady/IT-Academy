using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : Singleton<PlatformManager>
{
    public PlatformController[] platforms;
    Dictionary<PlatformController.lvlDifficult, List<PlatformController>> poolPlatform;
    public Transform startPositionPlatform;
    private void Awake()
    {
        poolPlatform = new Dictionary<PlatformController.lvlDifficult, List<PlatformController>>();
        List <PlatformController> platformEasy = new List<PlatformController>();
        List<PlatformController> platformMedium = new List<PlatformController>();
        List<PlatformController> platformHard = new List<PlatformController>();
        for (int i = 0; i < platforms.Length; i++)
        {
            var platf = Instantiate(platforms[i], startPositionPlatform);
            platf.gameObject.SetActive(false);
            platf.gameObject.transform.SetParent(transform);
            if (platf.lvl == PlatformController.lvlDifficult.easy)
                platformEasy.Add(platf);        
            if (platf.lvl == PlatformController.lvlDifficult.medium)
                platformMedium.Add(platf);
            if (platf.lvl == PlatformController.lvlDifficult.hard)
                platformHard.Add(platf);
        }
        poolPlatform.Add(PlatformController.lvlDifficult.easy, platformEasy);
        poolPlatform.Add(PlatformController.lvlDifficult.medium, platformMedium);
        poolPlatform.Add(PlatformController.lvlDifficult.hard, platformHard);
    }
    private void Update()
    {

    }
    public PlatformController GetPlatform(PlatformController.lvlDifficult lvl)
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
    public void EmergingPlatform(PlatformController.lvlDifficult lvl)
    {
        float startPosition = 49.8f;
        PlatformController platf = GetPlatform(lvl);
        platf.transform.position = new Vector3(startPositionPlatform.position.x + startPosition,
            startPositionPlatform.position.y, startPositionPlatform.position.z);
        platf.gameObject.SetActive(true);
    }
    public void DisablePlatform(PlatformController platf)
    {
        platf.gameObject.SetActive(false);
    }
}
