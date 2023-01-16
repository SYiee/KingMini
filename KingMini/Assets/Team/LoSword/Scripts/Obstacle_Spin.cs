using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Spin : MonoBehaviour
{

    public float SpinSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, SpinSpeed * Time.deltaTime, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Spin");
            // Ragdoll
        }
    }
}
