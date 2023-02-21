using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaplerSound : MonoBehaviour
{
    AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    public void PlayStayplerSound()
    {
        source.Play();
    }
}
