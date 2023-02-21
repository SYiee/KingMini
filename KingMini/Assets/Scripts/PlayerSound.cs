using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioClip[] footstepSounds;
    public AudioClip jumpSound;
    public AudioClip dieSound;
    public AudioClip electricSound;

    AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    public void PlayFootStep()
    {
        if(footstepSounds != null)
            source.PlayOneShot(footstepSounds[Random.Range(0, footstepSounds.Length)]);
    }

    public void PlayJumpSound()
    {
        source.PlayOneShot(jumpSound);
    }

    public void PlayDieSound()
    {
        if(dieSound != null)
        {
            source.PlayOneShot(dieSound);
            dieSound = null;
        }
            
    }

    public void PlayElectricSound()
    {
        source.PlayOneShot(electricSound);
    }
}
