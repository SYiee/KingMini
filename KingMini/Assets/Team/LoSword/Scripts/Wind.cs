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

    private void OnTriggerEnter(Collider other)
    {
        //control.GetComponent<StarterAssets.ThirdPersonController>()._verticalVelocity += 10f;
        //Debug.Log(23);

        if (other.tag == "Player")
        {
            if (IsAudio)
            {
                theAudio.Play();
            }
            Rigidbody rigid = other.GetComponent<Rigidbody>();
            //Debug.Log(23);
            rigid.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
            //control.GetComponent<StarterAssets.ThirdPersonController>()._verticalVelocity += JumpForce;
        }
    }
}
