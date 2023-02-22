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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
            GetComponent<Animator>().enabled = false;
    }
}
