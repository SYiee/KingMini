using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : MonoBehaviour
{
    [Header ("Direction")]
    public bool up;
    public bool down;
    public bool left;
    public bool right;
    public bool forward;
    public bool back;

    [Header("Power")]
    public float power;

    Vector3 vec;

    private void Start()
    {
        vec = new Vector3(0, 0, 0);

        if (up) vec += Vector3.up;
        if (down) vec += Vector3.down;
        if (left) vec += Vector3.left;
        if (right) vec += Vector3.right;
        if (forward) vec += Vector3.forward;
        if (back) vec += Vector3.back;

        vec *= power;
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        Rigidbody rigid = collision.gameObject.GetComponentInChildren<Rigidbody>();
    //        rigid.AddForce(vec, ForceMode.Impulse);
    //    }
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        Rigidbody rigid = other.gameObject.GetComponent<Rigidbody>();
    //        rigid.AddForce(vec, ForceMode.Impulse);
    //    }
    //}
    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        Rigidbody rigid = collision.gameObject.GetComponentInChildren<Rigidbody>();
    //        rigid.AddForce(vec, ForceMode.Impulse);
    //    }
    //}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Rigidbody rigid = other.gameObject.GetComponentInChildren<Rigidbody>();
            rigid.AddForce(vec, ForceMode.Impulse);
        }
    }


}
