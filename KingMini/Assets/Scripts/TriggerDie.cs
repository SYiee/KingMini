using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDie : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponentInChildren<damage_obj>()?.Die();
    }
}
