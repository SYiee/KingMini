using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishUp : MonoBehaviour
{
    Rigidbody _rigidbody;
    public float UpHeight;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Invoke("FishPop", 5);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FishPop()
    {

        _rigidbody.AddForce(Vector3.up*UpHeight, ForceMode.Impulse);
    }
}
