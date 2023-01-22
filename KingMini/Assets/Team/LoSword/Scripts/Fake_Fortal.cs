using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fake_Fortal : MonoBehaviour
{
    public GameObject Portal;
    public float speed = 1f;

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
            Debug.Log(1);
            Portal.transform.Translate(new Vector3(0, 0, -1f) * speed);
        }
    }
}
