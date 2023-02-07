using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongBoat : MonoBehaviour
{
    public Animator animator;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("SharkUp",6);
        }
    }

    void SharkUp()
    {
        animator.SetTrigger("SharkUp");
    }
}
