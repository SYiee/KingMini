using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatDown : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<MeshCollider>().isTrigger = true;
            collision.gameObject.GetComponent<CapsuleCollider>().isTrigger = true;

        }
    }
}
