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
        if (canPlay && collision.gameObject.tag == "Player") //����ٰ�, 3d�÷��̾��϶��� ���� �߰�
        {
            anim.Play("CaseAnim");
            canPlay = false;
        }
    }
}
