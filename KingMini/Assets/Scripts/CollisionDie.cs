using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDie : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponentInChildren<damage_obj>() ?.Die();
    }
}
