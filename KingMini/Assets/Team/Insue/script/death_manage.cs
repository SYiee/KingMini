using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death_manage : MonoBehaviour
{
    private void Awake()
    {
        var obj = FindObjectsOfType<death_manage>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public float death_count = 0;
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            print(death_count);
        }
    }
}
