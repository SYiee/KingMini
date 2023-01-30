using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotSpilled : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Broom")
        {
            Invoke("DisableObject", 2f);
        }
    }


    void DisableObject()
    {
        
        gameObject.SetActive(false);
    }
}
