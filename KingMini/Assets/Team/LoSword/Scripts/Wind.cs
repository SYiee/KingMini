using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    //public StarterAssets.ThirdPersonController control;
    private Rigidbody rb;
    public float JumpForce = 30f;
    public bool IsAudio;

    private AudioSource theAudio;

    void Start()
    {
        if (IsAudio)
        {
            theAudio = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        //control.GetComponent<StarterAssets.ThirdPersonController>()._verticalVelocity += 10f;
        //Debug.Log(23);

        if (other.gameObject.tag == "Player")
        {
            if (IsAudio)
            {
                theAudio.Play();
            }
            rb = other.gameObject.GetComponentInChildren<Rigidbody>();
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(new Vector3(0, JumpForce, 0), ForceMode.VelocityChange);
            //control.GetComponent<StarterAssets.ThirdPersonController>()._verticalVelocity += JumpForce;
        }
    }
}
