using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocketBall_SoundTrigger : MonoBehaviour
{
    public GameObject PocketBall;
    public bool sound_in;

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            PocketBall.GetComponent<PocketBall>().sound_start = true;
        }

    }
}
