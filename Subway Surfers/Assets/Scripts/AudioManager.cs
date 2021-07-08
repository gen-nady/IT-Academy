using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField]
    AudioClip[] clips;
    [SerializeField]
    AudioSource source;
    public void PickUpCoin()
    {
        source.PlayOneShot(clips[0]);
    }
    public void PickUpBuster()
    {
        source.PlayOneShot(clips[1]);
    }
}
