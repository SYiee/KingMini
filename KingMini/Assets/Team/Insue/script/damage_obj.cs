using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;

public class damage_obj : MonoBehaviour
{
    public GameObject player_mesh;
    public GameObject player_ragdoll;
    public GameObject controller;

    private bool is_death = false;


    [Header("Die on flat")]
    public bool die_on_flat = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (die_on_flat==true)
        {
            /*
            if (transform.position.y < 0)
            {
                print("d");
                Die();
            }
            */
        }
        if (is_death)
        {
            if(Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        print(other.gameObject.tag);
        if (is_death == false && other.gameObject.tag == "Obstacle")
        {
            Die();
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit other)
    {
        if (is_death == false && other.gameObject.tag == "Obstacle")
        {
            Die();
        }
    }

    public void Die()
    {
        is_death = true;
        player_mesh.SetActive(false);
        player_ragdoll.SetActive(true);
        controller.GetComponent<ThirdPersonController>().MoveSpeed = 0;
        controller.GetComponent<ThirdPersonController>().JumpHeight = 0;
        controller.GetComponent<ThirdPersonController>().RotationSmoothTime = 100;
        controller.GetComponent<ThirdPersonController>().LockCameraPosition = true;
        controller.GetComponent<ThirdPersonController>().CinemachineCameraTarget = player_ragdoll;
    }

}
