using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStep : MonoBehaviour
{
    [SerializeField] AudioClip[] footstepSounds;

    AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    public void PlayFootStep()
    {
        source.PlayOneShot(footstepSounds[Random.Range(0, footstepSounds.Length)]);
    }
}
