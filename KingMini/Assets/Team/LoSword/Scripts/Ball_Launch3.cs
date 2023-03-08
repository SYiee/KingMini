using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Launch3 : MonoBehaviour
{
    public float Speed = 1f;

    void Start()
    {
        Destroy(gameObject, 2f);
    }

    void Update()
    {
        gameObject.transform.Translate(new Vector3(-1f, 0, 0) * Time.deltaTime * 100 * Speed);
    }
}
