using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform Target;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(1);
        other.transform.position = Target.position;
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(2);
            other.transform.position = Target.position;
        }
    }
}
