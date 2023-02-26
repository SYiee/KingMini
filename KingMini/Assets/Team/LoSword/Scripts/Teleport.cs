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

            // best_death �ʱ�ȭ
            if(present_death < best_death)
            {
                PlayerPrefs.SetInt("BestDeath" + scene_num, present_death);
            }

            //death �ʱ�ȭ
            GameObject.Find("death_manager").GetComponent<death_manage>().death_count = 0;
            PlayerPrefs.SetInt("Death"+ scene_num, 0);

            // FadeOut
            Instantiate(FadeOutUI, new Vector3(1000, 700, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            GameObject.Find("BasicUI").SetActive(false);
            Invoke("LoadNextScene", 3f);


            // �ְ� Level ����
            if (PlayerPrefs.HasKey("BestLevel"))  //  Ű���� ������ 
            {
                int best_level = PlayerPrefs.GetInt("BestLevel");
                if (best_level <= scene_num)  // �ְ��� ����
                    PlayerPrefs.SetInt("BestLevel", scene_num + 1);
            }
            else
            {
                PlayerPrefs.SetInt("BestLevel", scene_num + 1);
            }

            // Dev ����
            Player.SetActive(false);


        }
    }
    void LoadNextScene()
    {
        int present = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(present + 1);
    }
}
