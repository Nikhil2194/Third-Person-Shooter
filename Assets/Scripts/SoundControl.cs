using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public AudioSource source;
    public AudioClip footstep;
    public AudioClip DeathSFX;

    void footSound()
    {
        source.clip = footstep;
        source.Play();
    }

    void DeathSound()
    {
        source.clip = DeathSFX;
        source.Play();
    }
}
