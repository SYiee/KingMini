using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkDetect : MonoBehaviour
{
    public GameObject Shark;
    bool isFirst = true;

    private void OnTriggerEnter(Collider other)
    {
        if (isFirst && other.transform.tag == "Player")
        {
            Shark.GetComponent<Animator>().SetTrigger("Shark3D");
            isFirst = false;
            Shark.GetComponent<ChasePlayer>().ChangeCondition(true);
            Invoke("setDeactive", 3f);
        }
    }

    void setDeactive()
    {
        Shark.GetComponent<Animator>().enabled = false;
    }


}
