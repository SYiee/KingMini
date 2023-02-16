using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Obstacle_WaitFall : MonoBehaviour
{
    public float FallSec = 0.5f;

    public bool canDestroy = true;


    public float DestroySec = 2f;
    
    Rigidbody Board;

    void Start()
    {
        Board = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Fall");
            Invoke("BoardFall", FallSec);

            if(canDestroy)
                Destroy(gameObject, DestroySec);
        }
    }
    void BoardFall()
    {
        Board.isKinematic = false;
    }
}