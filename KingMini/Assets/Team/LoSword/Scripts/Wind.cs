using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public StarterAssets.ThirdPersonController control;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //control.GetComponent<StarterAssets.ThirdPersonController>()._verticalVelocity += 10f;
        //Debug.Log(23);

        if (other.tag == "Player")
        {
            Debug.Log(23);
            control.GetComponent<StarterAssets.ThirdPersonController>()._verticalVelocity += 30f;
        }
    }
}
