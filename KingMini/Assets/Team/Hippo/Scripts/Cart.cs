using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    GameObject player;
    public int power;
    float dir;


    public void plusVelocity()
    {
        if (player != null)
        {
            dir = 1;

            Debug.Log("Plus");
        }
    }

    public void minusVelocity()
    {
        if (player != null)
        {
            dir = -1;

            Debug.Log("Minus");
        }
    }

    private void Update()
    {
        if(player != null)
        {
            player.GetComponent<Rigidbody>().velocity = new Vector3(dir * power, player.GetComponent<Rigidbody>().velocity.y, player.GetComponent<Rigidbody>().velocity.z);
            //player.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(dir * power, 0, 0), ForceMode.Force);
            Debug.Log(player.GetComponent<Rigidbody>().velocity);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player = other.gameObject;
            Debug.Log("Player Enter");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            player.GetComponentInChildren<Rigidbody>().velocity = new Vector3(0, 0, 0);
            player = null;
            Debug.Log("Player Out");
        }
    }
}
