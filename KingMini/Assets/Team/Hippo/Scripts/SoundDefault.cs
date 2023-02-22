using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDefault : MonoBehaviour
{
    public AudioClip sound;
    public AudioClip sound2;
    public void PlaySound()
    {
        AudioManager.instance.GetComponent<AudioSource>().PlayOneShot(sound);
    }

    public void PlaySound2()
    {
        AudioManager.instance.GetComponent<AudioSource>().PlayOneShot(sound2);
    }
}
