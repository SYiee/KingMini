using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public int SceneNum;
    public GameObject FadeOutUI;
    public GameObject Player;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {     
        if (other.gameObject.tag == "Player")
        {
            int scene_num = SceneManager.GetActiveScene().buildIndex;
            int best_death = PlayerPrefs.GetInt("BestDeath" + scene_num);
            int present_death = PlayerPrefs.GetInt("Death" + scene_num);
            float best_time = PlayerPrefs.GetFloat("BestTime" + scene_num);
            float present_time = PlayerPrefs.GetFloat("Time" + scene_num);

            // best_death 초기화
            if(present_death < best_death)
            {
                PlayerPrefs.SetInt("BestDeath" + scene_num, present_death);
            }

            //death 초기화
            GameObject.Find("death_manager").GetComponent<death_manage>().death_count = 0;
            PlayerPrefs.SetInt("Death"+ scene_num, 0);

            // FadeOut
            Instantiate(FadeOutUI, new Vector3(1000, 700, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            GameObject.Find("BasicUI").SetActive(false);
            Invoke("LoadNextScene", 3f);

            // Time & BestTime 초기화
            present_time = GameObject.Find("ui_manager").GetComponent<Esc_UI>().time;
            PlayerPrefs.SetFloat("Time" + scene_num, present_time);
            if (present_time <= best_time)  // 최고기록 갱신
                PlayerPrefs.SetFloat("BestTime" + scene_num, present_time);
            PlayerPrefs.SetFloat("Time" + scene_num, 0);

            // BestLevel 갱신
            int best_level = PlayerPrefs.GetInt("BestLevel");
            if (best_level <= scene_num)  // 최고기록 갱신
                PlayerPrefs.SetInt("BestLevel", scene_num + 1);


            // Dev 끄기
            Player.SetActive(false);


        }
    }
    void LoadNextScene()
    {
        int present = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(present + 1);
    }
}
