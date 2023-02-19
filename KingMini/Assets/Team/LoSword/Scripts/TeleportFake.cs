using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportFake : MonoBehaviour
{
    public GameObject Destination;

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
            other.transform.position = Destination.transform.position;
        }
    }
}
