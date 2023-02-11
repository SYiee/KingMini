using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using StarterAssets;

public class damage_obj : MonoBehaviour
{
    public GameObject player_mesh;
    public GameObject player_ragdoll;
    public GameObject Camera;

    [Header("Electric Shock Effect")]
    public GameObject electricObject;
    public bool electric = false;

    private bool is_death = false;


    [Header("Die on flat")]
    public bool die_on_flat = true;

    [Header("Death Manager")]
    public GameObject death_manager;

    private void Awake()
    {
       death_manager = FindObjectOfType<death_manage>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (die_on_flat==true)
        {
            
            if (transform.position.y < 1)
            {
               
                Die();
            }
            
        }
        if (is_death)
        {
            if(Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                death_manager.transform.GetComponent<death_manage>().death_count++;
                is_death = false;
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

    public void Electric(bool elec)
    {
        electric = elec;
    }
    public void Die()
    {
        is_death = true;
        player_mesh.SetActive(false);
        player_ragdoll.SetActive(true);
        if (electric)
        {
            electricObject.SetActive(electric);
        }
        //Camera.GetComponent<CameraMovement>().objectToFollow = player_ragdoll.transform;
        //controller.GetComponent<ThirdPersonController>().MoveSpeed = 0;
        //controller.GetComponent<ThirdPersonController>().JumpHeight = 0;
        //controller.GetComponent<ThirdPersonController>().RotationSmoothTime = 100;
        //controller.GetComponent<ThirdPersonController>().LockCameraPosition = true;
        //controller.GetComponent<ThirdPersonController>().CinemachineCameraTarget = player_ragdoll;
    }

}
