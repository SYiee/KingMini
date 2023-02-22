using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyCollisionSound : MonoBehaviour
{
    AudioSource source;
    public AudioClip Sound;

    void Start()
    {
        source = AudioManager.instance.GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        source.PlayOneShot(Sound);
    }
}
