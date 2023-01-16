using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Popout : MonoBehaviour
{
    Vector3 Cur_pos;
    public float Pop_Range = 2.0f;
    public float Pop_speed = 3.0f;

    void Start()
    {
        Cur_pos = transform.position;
    }

    void Update()
    {
        Vector3 Changing_pos = Cur_pos;
        Changing_pos.y += Pop_Range * Mathf.Sin(Time.time * Pop_speed);
        transform.position = Changing_pos;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Pop");
            // Ragdoll
        }
    }
}
