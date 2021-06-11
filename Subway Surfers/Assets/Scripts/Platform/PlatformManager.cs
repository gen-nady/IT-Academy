using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : Singleton<PlatformManager>
{
    public PlatformController[] platforms;
    List<PlatformController> poolPlatform;
    public Transform startPositionPlatform;
    private void Awake()
    {
        for (int i = 0; i < platforms.Length; i++)
        {
            var platf = Instantiate(platforms[i], startPositionPlatform);
            platf.gameObject.SetActive(false);
            platf.gameObject.transform.SetParent(this.transform);
            poolPlatform.Add(platf);
        }
    }
    public PlatformController GetPlatform()
    {
        List<PlatformController> notActivePlatform = new List<PlatformController>();
        for (int i = 0; i < platforms.Length; i++)
        {
            if (!poolPlatform[i].gameObject.activeInHierarchy)
            {
                notActivePlatform.Add(poolPlatform[i]);
            }
        }
        int random = Random.Range(0, notActivePlatform.Count - 1);
        return notActivePlatform[random];
    }
}
