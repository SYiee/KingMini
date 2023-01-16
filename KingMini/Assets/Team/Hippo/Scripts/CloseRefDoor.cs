using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseRefDoor : MonoBehaviour
{
    public GameObject closeDoor;
    public MeshCollider meshcollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            closeDoor.GetComponent<Animation>().Play("CloseDoor");
            meshcollider.isTrigger = true;

        }
            
    }
}
