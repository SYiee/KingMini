using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSoundEffect : MonoBehaviour
{
    AudioSource source;
    public AudioClip Sound;

    void Start()
    {
        source = FindObjectOfType<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            source.PlayOneShot(Sound);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            source.PlayOneShot(Sound);
        }
    }
}
