using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public GameObject Planet;
    public float speed = 5.0f;

    void Update()
    {
        orbitAround();
    }

    void orbitAround()
    {
        transform.RotateAround(Planet.transform.position, Vector3.down, speed * Time.deltaTime);
    }
}
