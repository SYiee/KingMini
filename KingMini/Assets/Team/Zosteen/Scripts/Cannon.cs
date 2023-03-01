using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [Header("Direction")]
    public bool up;
    public bool down;
    public bool left;
    public bool right;
    public bool forward;
    public bool back;

    [Header("Power")]
    public float power;

    public Transform target;

    Vector3 vec;
    GameObject player;
    Rigidbody rigid;
    bool cannonFire = false;

    private void Update()
    {
        //if(cannonFire)
        {
            //player.transform.position = Vector3.Slerp(player.transform.position, target.position, 0.01f);
            transform.position = Vector3.Slerp(transform.position, target.position, 0.005f);
            rigid.useGravity = false;

        }


    }
    private void Start()
    {

        vec = new Vector3(0, 0, 0);

        if (up) vec = Vector3.up;
        if (down) vec = Vector3.down;
        if (left) vec = Vector3.left;
        if (right) vec = Vector3.right;
        if (forward) vec = Vector3.forward;
        if (back) vec = Vector3.back;

        vec *= power;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            print("catch");
            if (player == null)
            {
                player = collision.gameObject;
                rigid = player.GetComponentInChildren<Rigidbody>();
            }

            cannonFire = true;

            //player.transform.position = Vector3.Slerp(player.transform.position, new Vector3(player.transform.position.x -1000,
            //    player.transform.position.y, player.transform.position.z), 0.003f);

            //rigid.velocity = new Vector3(rigid.velocity.x, 0, rigid.velocity.z);
            //rigid.AddForce(new Vector3(1f, 1, 0) * power, ForceMode.VelocityChange);
            //rigid.AddForce(vec, ForceMode.VelocityChange);

        }

    }
}
