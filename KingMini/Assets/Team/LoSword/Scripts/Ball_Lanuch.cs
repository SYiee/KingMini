using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Lanuch : MonoBehaviour
{
    public float Speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector3(0, 0, -1 * Speed));
    }
}
