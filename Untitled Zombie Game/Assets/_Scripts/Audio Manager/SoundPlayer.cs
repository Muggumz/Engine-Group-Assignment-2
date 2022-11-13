using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{

    [SerializeField] private AudioClip soundclip;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.soundInstance.PlaySound(soundclip);
    }

    
}
