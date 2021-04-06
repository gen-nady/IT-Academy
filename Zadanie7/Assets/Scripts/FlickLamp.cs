using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickLamp : MonoBehaviour
{

    public float totalSeconds;     
    public float maxIntensity;    
    Light myLight;     

    private void Start()
    {
        myLight = GetComponent<Light>();
    }
    private void Update()
    {
        StartCoroutine(FlashNow());
    }
    public IEnumerator FlashNow()
    {
        float waitTime = totalSeconds / 2;
        while (myLight.intensity < maxIntensity)
        {
            myLight.intensity += Time.deltaTime / waitTime;      
            yield return null;
        }
        while (myLight.intensity > 0)
        {
            myLight.intensity -= Time.deltaTime / waitTime;        
            yield return null;
        }
        yield return null;
    }
}
