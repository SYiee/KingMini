using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Invector.vCharacterController;
using TMPro;


public class damage_obj : MonoBehaviour
{
    public GameObject player_mesh;
    public GameObject player_ragdoll;
    public GameObject player_controller;
    public GameObject Camera;

    [Header("Electric Shock Effect")]
    public GameObject electricObject;
    public bool electric = false;

    private bool is_death = false;


    [Header("Die on flat")]
    public bool die_on_flat = true;

    [Header("Death Manager")]
    public GameObject death_manager;
    public TextMeshProUGUI Death_UI;  // 몇 번 죽었는지 표시

    private void Awake()
    {
        
        death_manager = FindObjectOfType<death_manage>().gameObject;

        // death UI 할당 & 업데이트
        Death_UI = GameObject.Find("Death_Num").GetComponent<TextMeshProUGUI>();
        Death_UI.text = death_manager.transform.GetComponent<death_manage>().death_count.ToString();  
    }

    // Update is called once per frame
    void Update()
    {
        if (die_on_flat==true)
        {
            
            if (transform.position.y < 1 && is_death == false)
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
        player_ragdoll.SetActive(true);
        player_ragdoll.transform.SetParent(null);
        player_controller.transform.SetParent(player_ragdoll.transform);
        player_mesh.SetActive(false);
        if (electric)
        {
            electricObject.SetActive(electric);
        }
        //player_controller.GetComponent<vThirdPersonInput>().enabled = false;
        //player_controller.GetComponent<vThirdPersonController>().enabled = false;
        Camera.GetComponent<vThirdPersonCamera>().SetMainTarget(player_ragdoll.transform);
    }   
}
