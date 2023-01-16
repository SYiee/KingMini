using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocketBall_Hole : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BlackBall")
        {
            Debug.Log("»ç¸Á");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
