using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToghether : MonoBehaviour
{
    GameObject player = null;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player") 
        {
            if(player == null)
                player = collision.gameObject;
            player.transform.parent.SetParent(transform);
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
