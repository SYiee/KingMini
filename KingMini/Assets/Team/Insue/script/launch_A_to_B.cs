using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class launch_A_to_B : MonoBehaviour
{

    public GameObject A;
    public GameObject B;

    public GameObject projectile;

    public float power = 50;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           print("dd");
           GameObject ball = Instantiate(projectile);
            ball.transform.position = A.transform.position;
           Vector3 dir = new Vector3(B.transform.position.x, B.transform.position.y + 2, B.transform.position.z) - A.transform.position;
           ball.GetComponent<Rigidbody>().AddForce(dir * power);
        }
    }
}