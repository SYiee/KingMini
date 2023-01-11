using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class damage_obj : MonoBehaviour
{
    public GameObject player_mesh;
    public GameObject player_ragdoll;
    public GameObject controller;

    private bool is_death = false;

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
        if (is_death == false&& other.gameObject.tag=="Player")
        {
            is_death = true;
            player_mesh.SetActive(false);
            player_ragdoll.SetActive(true);
            controller.GetComponent<ThirdPersonController>().enabled = false;
        }
    }
}
