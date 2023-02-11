using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Ball_Lanuch : MonoBehaviour
{
    public float Speed = 1f;

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        gameObject.transform.Translate(new Vector3(0, 0, -1f) *  Speed);
    }
}
