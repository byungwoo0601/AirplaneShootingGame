using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioStrpt : MonoBehaviour
{

    public AudioClip auidoMain;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.5f;

        PlaySound(auidoMain);

    }


    public void PlaySound(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
    }
}
