using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkUp: MonoBehaviour
{
    public GameObject shark;
    public float delay_time = 6f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Shark", delay_time);
        }
    }

    void Shark()
    {
        shark.SetActive(true);
        shark.GetComponent<Animator>().SetTrigger("SharkUp");

    }
}
