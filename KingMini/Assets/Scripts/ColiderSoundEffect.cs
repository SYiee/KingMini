using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColiderSoundEffect : MonoBehaviour
{
    AudioSource source;
    public AudioClip boatSound;
    public AudioClip balloonSound;
    public AudioClip windSound1;
    public AudioClip windSound2;
    public AudioClip cameraSound;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Boat")
        {
            source.PlayOneShot(boatSound);
        }
        if (collision.transform.tag == "Balloon")
        {
            source.PlayOneShot(balloonSound);
        }
        if (collision.transform.tag == "Wind1")
        {
            source.PlayOneShot(windSound1);
        }
        if (collision.transform.tag == "Wind2")
        {
            source.PlayOneShot(windSound2);
        }
        if (collision.transform.tag == "FlashCamera")
        {
            source.PlayOneShot(cameraSound);
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Boat")
        {
            source.Stop();
        }
    }
    private void OnTriggerEnter(Collider other)
    {

    }

}
