using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    //public static AudioClip bombSound;
    static AudioSource audioSrc;
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public static void playSound(string soundLocation)
    {
        
        audioSrc.PlayOneShot(Resources.Load<AudioClip>(soundLocation));
        
    }
}
