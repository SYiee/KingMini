using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class typingSound : MonoBehaviour
{
    AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            source.Play();
    }
}
