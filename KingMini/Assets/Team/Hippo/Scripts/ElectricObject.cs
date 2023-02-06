using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricObject : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
            collision.gameObject.GetComponentInChildren<damage_obj>().electric = true;
    }
}
