using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    //public StarterAssets.ThirdPersonController control;
    public Rigidbody rb;
    public float JumpForce = 30f;

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
            rb.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
            //control.GetComponent<StarterAssets.ThirdPersonController>()._verticalVelocity += JumpForce;
        }
    }
}
