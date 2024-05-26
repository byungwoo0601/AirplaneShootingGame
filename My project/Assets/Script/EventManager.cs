using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public static int gold = 300000;

    public Text GoldTxt;
    public AudioClip auidoMain;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.5f;

        PlaySound(auidoMain);

    }
    private void Update()
    {
        GoldTxt.text = "Gold : " + gold.ToString() + "G";
    }


    public void PlaySound(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
    }


}
