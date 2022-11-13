using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager soundInstance;

    [SerializeField] private AudioSource musicPlayer;
    [SerializeField] private AudioSource effectPlayer;

    private void Awake()
    {
        if (!soundInstance)
        {
            soundInstance = this;
        }
    }

    public void PlaySound(AudioClip clip)
    {
        effectPlayer.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        musicPlayer.PlayOneShot(clip);
    }
}
