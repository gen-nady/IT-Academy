using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;


    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        source.PlayOneShot(clip);
    }

}
