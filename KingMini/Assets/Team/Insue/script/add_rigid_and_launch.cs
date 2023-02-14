using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class add_rigid_and_launch : MonoBehaviour
{
    public GameObject obj;
    public float power = 50;

    [Header("launch children")]
    public bool child_launch;

    private void OnTriggerEnter(Collider other)
    {
        Transform[] objs = obj.GetComponentsInChildren<Transform>();
        if (other.tag == "Player")
        {
            foreach (Transform child in objs)
            {
                child.gameObject.AddComponent<Rigidbody>();
                child.gameObject.transform.tag = "Obstacle";
                if (child_launch)
                {
                    child.GetComponent<Rigidbody>().AddForce(Vector3.up * power);
                }
            }
            GetComponent<Rigidbody>().AddForce(Vector3.up * power);
        }
    }
}
