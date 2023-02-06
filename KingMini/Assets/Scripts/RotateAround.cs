using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public GameObject Planet;
    public float speed = 5.0f;
    [Header("Direction")]
    public bool reverse;
    Vector3 vec = Vector3.down;

    private void Start()
    {
        if (reverse) vec = Vector3.up;
        
    }

    void Update()
    {
        orbitAround();
    }

    void orbitAround()
    {
        transform.RotateAround(Planet.transform.position, vec, speed * Time.deltaTime);
    }
}
