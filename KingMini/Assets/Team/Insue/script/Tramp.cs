using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tramp : MonoBehaviour
{
    public GameObject player;
    public float height;
    public float speed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !is_up)
        {
            player = other.gameObject;
            is_up = true;
        }
    }

    private void FixedUpdate()
    {
        if (is_up)
        {
            UP(player);
        }
    }

    private bool is_up= false;
    private float time = 0;
   private void UP(GameObject obj)
   {
        print("jmmp");
        if (obj.transform.position.y < transform.position.y + height)
        {
            obj.transform.Translate(Vector3.up);
        }
        else { is_up = false; }
   }
}
