using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    Animation anim;
    bool first = true;
    GameObject player = null;

    private Quaternion rot;

    private void Awake()
    {
        anim = GetComponent<Animation>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(first && other.gameObject.tag == "Player")
        {
            anim.Play("FlagAnim");
            first = false;
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            if (player == null)
                player = collision.gameObject;
            player.transform.parent.SetParent(transform);
            player.transform.rotation = Quaternion.Euler(new Vector3(0, player.transform.localRotation.y, 0));
        }
    }

    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            player.transform.rotation = Quaternion.Euler(new Vector3(0, player.transform.localRotation.y, 0));

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
