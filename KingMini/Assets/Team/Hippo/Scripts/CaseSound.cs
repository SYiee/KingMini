using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseSound : MonoBehaviour
{
    public AudioClip caseSound;
    public void PlayCaseSound()
    {
        AudioManager.instance.GetComponent<AudioSource>().PlayOneShot(caseSound);
    }
}
