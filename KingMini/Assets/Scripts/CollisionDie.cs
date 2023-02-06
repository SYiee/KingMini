using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDie : MonoBehaviour
{
    public bool isEloctronic;
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponentInChildren<damage_obj>() ?.Electric(isEloctronic);
        collision.gameObject.GetComponentInChildren<damage_obj>() ?.Die();
    }
}
