using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class go_to_A : MonoBehaviour
{
    public GameObject obj;
    public GameObject A;

    public float power = 50;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Vector3 dir = new Vector3(A.transform.position.x, A.transform.position.y + 2, A.transform.position.z) - obj.transform.position;
            obj.GetComponent<Rigidbody>().AddForce(dir * power);
        }
    }
}
