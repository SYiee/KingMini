using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot: MonoBehaviour
{
    public GameObject setActiveObject;
    Animation anim;

    private void Awake()
    {
        anim = GetComponent<Animation>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.Play("PotFall");
        }
    }

    public void ActiveObject()
    {
        setActiveObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
