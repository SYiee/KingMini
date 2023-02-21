using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Invector.vCharacterController;

public class damage_obj : MonoBehaviour
{
    public GameObject player_mesh;
    public GameObject player_ragdoll;
    public GameObject player_controller;
    public GameObject Cam;

    [Header("Electric Shock Effect")]
    public GameObject electricObject;
    public bool electric = false;


    [Header("Die on flat")]
    public bool die_on_flat = true;

    [Header("Death Manager")]
    public GameObject death_manager;
    public TextMeshProUGUI Death_UI;  // 몇 번 죽었는지 표시
    public int scene_num; // 현재 씬 넘버


    private bool is_death = false;

    private void Start()
    {
        scene_num = SceneManager.GetActiveScene().buildIndex;
    }

    private void Awake()
    {
        //death_manager = FindObjectOfType<death_manage>().gameObject;
        death_manager = GameObject.Find("death_manager");

        // death UI 할당 & 업데이트x
        Death_UI = GameObject.Find("Death_Num").GetComponent<TextMeshProUGUI>();
        Death_UI.text = death_manager.GetComponent<death_manage>().death_count.ToString();

        // Scene num (Level) 저장
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (die_on_flat == true)
        {

            if (transform.position.y < 1 && is_death == false)
            {

                Die();
            }

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Die();
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
        StartCoroutine("die");
    }

    IEnumerator die()
    {
        player_ragdoll.SetActive(true);
        player_mesh.GetComponent<SkinnedMeshRenderer>().enabled = false;
        player_controller.GetComponent<vThirdPersonController>().lockRotation = true;
        player_controller.GetComponent<vThirdPersonController>().lockMovement = true;
        player_controller.GetComponent<vThirdPersonController>().jumpHeight = 0;
        player_controller.GetComponent<vThirdPersonController>().airSpeed = 0;
        player_controller.GetComponent<CapsuleCollider>().height = 0.5f;
        //player_ragdoll.transform.SetParent(null);
        //Cam.GetComponent<vThirdPersonCamera>().SetMainTarget(player_ragdoll.transform);
        if (electric)
        {
            electricObject.SetActive(electric);
        }

        GetComponent<PlayerSound>().footstepSounds = null;
        GetComponent<PlayerSound>().PlayDieSound();

        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        death_manager.GetComponent<death_manage>().Death(); // 현재방의 death count를 업데이트
    }
}
