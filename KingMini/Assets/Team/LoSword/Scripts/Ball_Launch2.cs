using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Launch2 : MonoBehaviour
{
    public float Speed = 1f;

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        gameObject.transform.Translate(new Vector3(-1f, 0, 0) * Speed);
    }
}
