using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToghetherTrigger: MonoBehaviour
{
    GameObject player = null;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") 
        {
            if(player == null)
                player = other.gameObject;
            player.transform.parent.SetParent(transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            player.transform.parent.SetParent(null);
        }
    }

}
