using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot: MonoBehaviour
{
    public GameObject setActiveObject;
    Animation anim;
    public AudioClip potSound1;
    public AudioClip potSound2;

    private void Awake()
    {
        anim = GetComponent<Animation>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.Play("PotFall");
        }
    }

    public void ActiveObject()
    {
        setActiveObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void PlayPotSound1()
    {
        AudioManager.instance.GetComponent<AudioSource>().PlayOneShot(potSound1);
    }

    public void PlayPotSound2()
    {
        AudioManager.instance.GetComponent<AudioSource>().PlayOneShot(potSound2);
    }
}
