using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_WaitFall : MonoBehaviour
{
    public float FallSec = 0.5f;
    public float DestroySec = 2f;
    Rigidbody Board;

    void Start()
    {
        Board = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Fall");
            Invoke("BoardFall", FallSec);
            Destroy(gameObject, DestroySec);
        }
    }
    void BoardFall()
    {
        Board.isKinematic = false;
    }
}
