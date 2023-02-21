using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCollision : MonoBehaviour
{
    AudioSource source;
    public AudioClip sound;
    private void Start()
    {
        source = AudioManager.instance.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            source.PlayOneShot(sound);
    }
}
