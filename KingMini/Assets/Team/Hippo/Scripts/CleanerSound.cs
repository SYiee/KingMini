using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanerSound : MonoBehaviour
{
    AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    public void PlaySound()
    {
        source.Play();
    }

    public void StopSound()
    {
        source.Stop();
    }
}
