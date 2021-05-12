using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AudioManager : Singleton<AudioManager>
{
    public AudioSource audioSource;
    public AudioClip[] audioî;

    public void OnShoot()
    {
        audioSource.clip = audioî[0];
        audioSource.Play();
    }
    public void OnBoom()
    {
        audioSource.clip = audioî[1];
        audioSource.Play();
    }
}
