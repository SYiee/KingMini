using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Title;

    float time = 0;


    private void Start()
    {
        time = 0;
        Time.timeScale = 1f;
    }

    private void Update()
    {

        if (time < 0.7f)
        {
            Title.transform.position = Title.transform.position + new Vector3(0, 0.3f, 0);
            print(time);
        }
        else
        {
            Title.transform.position = Title.transform.position + new Vector3(0, -0.3f, 0);
            if (time > 1.4f)
            {
                time = 0;
            }
        }

        time += Time.deltaTime;
    }

    public void NewGame()  // 새로운 게임 시작
    {

        // 죽은 횟수 & Level 초기화
        GameObject.Find("death_manager").GetComponent<death_manage>().death_count = 0;
        PlayerPrefs.SetInt("Death", 0);
        PlayerPrefs.SetInt("Scene", 1);

        SceneManager.LoadScene(1);

    }

    public void Continue()  // 이어서 플레이
    {
        // 저장된 키 있으면 거기서부터 플레이 or 처음부터
        if (!PlayerPrefs.HasKey("Scene"))
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            int level = PlayerPrefs.GetInt("Scene");
            SceneManager.LoadScene(level);
        }


    }

    // Update is called once per frame
    public void QuitGame() // 게임 종료
    {
        Application.Quit();
    }
}
