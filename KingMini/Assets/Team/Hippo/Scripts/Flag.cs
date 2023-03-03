using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    Animation anim;

    private Quaternion rot;

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

    GameObject player = null;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rot.x = collision.transform.localRotation.x;
            rot.y = collision.transform.localRotation.y;
            rot.z = collision.transform.localRotation.z;

            if (player == null)
                player = collision.gameObject;
            player.transform.parent.SetParent(transform);
        }
    }

    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            collision.transform.rotation = Quaternion.Euler(new Vector3(rot.x, rot.y, rot.z));
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.transform.parent.SetParent(null);
        }
    }
}
