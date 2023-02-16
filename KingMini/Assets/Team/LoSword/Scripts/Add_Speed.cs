using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add_Speed : MonoBehaviour
{

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
        if (other.gameObject.tag == "Obstacle")
        {
            other.GetComponent<Ball_Lanuch>().Speed += 0.1f;
        }
    }
}
