using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    public GameObject racket;
    public GameObject Board;
    public float speed = 1f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = racket.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            rb.isKinematic = false;
            Board.SetActive(true);
            rb.AddForce(new Vector3(0f, 0f, -1f) * speed, ForceMode.Impulse); ;
        }
    }
}
