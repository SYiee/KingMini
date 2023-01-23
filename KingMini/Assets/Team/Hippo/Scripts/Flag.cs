using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    Animation anim;
    private void Awake()
    {
        anim = GetComponent<Animation>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            anim.Play("FlagAnim");
        }
    }
}
