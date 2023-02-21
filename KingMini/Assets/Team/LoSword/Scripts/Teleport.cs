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

            //death 초기화
            GameObject.Find("death_manager").GetComponent<death_manage>().death_count = 0;
            int scene_num = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("Death"+ scene_num, 0);

            // FadeOut
            Instantiate(FadeOutUI, new Vector3(1000, 700, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            GameObject.Find("BasicUI").SetActive(false);
            Invoke("LoadNextScene", 3f);

            // Dev 끄기
            Player.SetActive(false);


            // 최고 Level 갱신
            if (PlayerPrefs.HasKey("BestLevel"))  //  키값이 있으면 
            {
                int best_level = PlayerPrefs.GetInt("BestLevel");
                if (best_level <= scene_num)  // 최고기록 갱신
                    PlayerPrefs.SetInt("BestLevel", scene_num + 1);  
            }
            else
            {
                PlayerPrefs.SetInt("BestLevel", scene_num + 1);
            }

        }
    }
    void LoadNextScene()
    {
        int present = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(present + 1);
    }
}
