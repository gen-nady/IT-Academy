using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : Singleton<PlatformManager>
{
    public PlatformController[] platforms;
    List<PlatformController> poolPlatform;
    public Transform startPositionPlatform;
    public bool isActivateNewPlatform;
    public bool isDisablePlatform;

    private void Awake()
    {
        List<PlatformController> platform = new List<PlatformController>();
        for (int i = 0; i < platforms.Length; i++)
        {
            var platf = Instantiate(platforms[i], startPositionPlatform);
            platf.gameObject.SetActive(false);
            platf.gameObject.transform.SetParent(transform);
            platform.Add(platf);
        }
        poolPlatform = platform;
    }
    private void Update()
    {
        EmergingPlatform();
    }
    public PlatformController GetPlatform()
    {
        List<PlatformController> notActivePlatform = new List<PlatformController>();
        for (int i = 0; i < poolPlatform.Count; i++)
        {
            if (!poolPlatform[i].gameObject.activeInHierarchy)
            {
                notActivePlatform.Add(poolPlatform[i]);
            }
        }
        int random = Random.Range(0, notActivePlatform.Count - 1);
        return notActivePlatform[random];
    }
    public void EmergingPlatform()
    {
        isActivateNewPlatform = false;
        PlatformController platf = GetPlatform();
        platf.transform.position = new Vector3(startPositionPlatform.position.x - 50f,
            startPositionPlatform.position.y, startPositionPlatform.position.z);
        platf.gameObject.SetActive(true);
    }
    public void DisablePlatform(PlatformController platf)
    {
        platf.gameObject.SetActive(false);


    }
}
