using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
{
    Animation anim;
    bool canPlay = true;

    private void Awake()
    {
        anim = GetComponentInParent<Animation>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (canPlay && collision.gameObject.tag == "Player") //여기다가, 3d플레이어일때만 조건 추가
        {
            anim.Play("CaseAnim");
            canPlay = false;
        }
    }
}
