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
    bool canJump = true;

    GameObject player;
    Rigidbody rigid;
    public MeshCollider[] meshs;

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

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("jump!");

        if (collision.gameObject.tag == "Player")   
        {
            if (player == null)
            {
                player = collision.gameObject;
                rigid = player.GetComponentInChildren<Rigidbody>();
            }
                
            canJump = false;
            Invoke("JumpOut", 1f);

            foreach (MeshCollider mesh in meshs)
                mesh.isTrigger = true;
            
            rigid.velocity = new Vector3(rigid.velocity.x, 0, rigid.velocity.z);
            rigid.AddForce(vec, ForceMode.VelocityChange);

        }
    }

    void JumpOut()
    {
        foreach (MeshCollider mesh in meshs)
            mesh.isTrigger = false;
    }



}
