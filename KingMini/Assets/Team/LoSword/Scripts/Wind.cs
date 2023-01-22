using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        rb = other.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0f, 10f, 0f), ForceMode.Impulse);
        Debug.Log(23);

        if (other.tag == "Player")
        {
            Debug.Log(23);
            rb = other.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(0f, 10f, 0f), ForceMode.Impulse);
        }
    }
}
