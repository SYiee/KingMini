using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public AudioClip[] footstepSounds;
    public AudioClip jumpSound;

    AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    public void PlayFootStep()
    {
        source.PlayOneShot(footstepSounds[Random.Range(0, footstepSounds.Length)]);
    }

    public void PlayJumpSound()
    {
        source.PlayOneShot(jumpSound);
    }
}
