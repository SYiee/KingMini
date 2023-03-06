using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioClip[] footstepSounds;
    public AudioClip[] dieSounds;

    public AudioClip jumpSound;
    public AudioClip electricSound;

    bool isDie;

    AudioSource source;

    private void Awake()
    {
        isDie = false;
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
        if(!isDie && dieSounds != null)
        {
            source.PlayOneShot(footstepSounds[Random.Range(0, dieSounds.Length)]);
            isDie = true;
        }
            
    }

    public void PlayElectricSound()
    {
        source.PlayOneShot(electricSound);
    }
}
