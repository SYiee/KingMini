using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSelf : MonoBehaviour
{
    public float speed = 700f;
    void Update()
    {
        Rotating();
    }
    void Rotating()
    {
        transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
    }

}
