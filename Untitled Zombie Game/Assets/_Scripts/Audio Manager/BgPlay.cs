using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgPlay : MonoBehaviour
{
    [SerializeField] private AudioClip musicClip;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.soundInstance.PlayMusic(musicClip);
    }
}
