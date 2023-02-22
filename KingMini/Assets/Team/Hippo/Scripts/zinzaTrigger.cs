using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zinzaTrigger : MonoBehaviour
{
    public Animator zinzaAnimator;

    private void Start()
    {
        zinzaAnimator.enabled = false;

        Invoke("zinzaAnimEnable", 0f);
    }

    void zinzaAnimEnable()
    {
        zinzaAnimator.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            zinzaAnimator.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            zinzaAnimator.enabled = false;
    }
}
