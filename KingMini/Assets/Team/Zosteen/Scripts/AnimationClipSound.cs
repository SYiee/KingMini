using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationClipSound : MonoBehaviour
{
    public AudioClip sound;
    public void PlayAnimSound()
    {
        GetComponent<AudioSource>().PlayOneShot(sound);
    }
    
}
