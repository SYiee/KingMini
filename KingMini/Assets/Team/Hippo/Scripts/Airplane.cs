using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    Animation anim;
    private void Awake()
    {
        anim = GetComponent<Animation>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.Play("Airplane");
        }
    }
}
