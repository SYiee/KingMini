using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Room
{
    public string name;
    public string scene_name;
    public string num;
    public int best_score;
    public Sprite sprite;
    public bool can_try;
}

public class MainScene : MonoBehaviour
{

    [Header("Room")]
    public Room[] roomList;
    public TextMeshProUGUI txtRoomName;
    public TextMeshProUGUI txtRoomNum;
    public Image imgRoom;
    public Sprite imgSecretRoom;
    public int errornum; // 쓸모없는 씬
    public GameObject deathManager;


    [Header("UI")]
    public GameObject Title;
    public GameObject Continue_Btn;
    public GameObject MainUI;
    public GameObject ContinueUI;

    int currentRoom = 0;
    float time = 0;


    private void Start()
    {
        time = 0;
        Time.timeScale = 1f;

        currentRoom = PlayerPrefs.GetInt("Level") - errornum; // 현재 방을 메인으로

        // 처음 플레이 할 때에는 Continue 버튼 비활성화
        if (!PlayerPrefs.HasKey("FirstPlay") || PlayerPrefs.GetInt("FirstPlay") == 1)
        {
            Continue_Btn.GetComponent<Button>().interactable = false;
        }

    }

    private void Update()
    {

        if (time < 0.7f)
        {
            Title.transform.position = Title.transform.position + new Vector3(0, 0.3f, 0);
           // print(time);
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
        for(int i = 0; i<roomList.Length; i++)
        {
            int a = i + errornum; 
            PlayerPrefs.SetInt("Death" + a, 0);
        }
        PlayerPrefs.SetInt("Level", 2);
        PlayerPrefs.SetInt("BestLevel", 2);

        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("FirstPlay", 0);


    }

    public void Continue()  // 이어서 플레이
    {
        MainUI.SetActive(false);
        ContinueUI.SetActive(true);
        SettingRoom();
        // 저장된 키 있으면 거기서부터 플레이 or 처음부터
        //if (!PlayerPrefs.HasKey("Level"))
        //{
        //    SceneManager.LoadScene(1);
        //}
        //else
        //{
        //    int level = PlayerPrefs.GetInt("Level");
        //    SceneManager.LoadScene(level);

        //}
    }

    // Update is called once per frame
    public void QuitGame() // 게임 종료
    {
        Application.Quit();
    }

    public void BtnNext()
    {
        if (++currentRoom > roomList.Length - 1)
            currentRoom = 0;
        SettingRoom();
    }

    public void BtnPrior()
    {
        if (--currentRoom < 0)
            currentRoom = roomList.Length - 1;
        SettingRoom();
    }

    public void BtnStart() // 버튼을 눌러서 Play 시작
    {
        int scene = currentRoom + errornum;

        if(scene <= PlayerPrefs.GetInt("BestLevel"))
        {
            if (!PlayerPrefs.HasKey("Death" + scene))
            {
                GameObject.Find("death_manager").GetComponent<death_manage>().death_count = 0;
            }
            else
            {
                GameObject.Find("death_manager").GetComponent<death_manage>().death_count = PlayerPrefs.GetInt("Death" + scene);
                print(GameObject.Find("death_manager").GetComponent<death_manage>().death_count);
            }

            SceneManager.LoadScene(scene);
        }

    }

    public void BacktoMain()
    {
        MainUI.SetActive(true);
        ContinueUI.SetActive(false);
    }

    void SettingRoom()
    {
        int scene = currentRoom + errornum;
        print(scene);
        print(PlayerPrefs.GetInt("BestLevel"));
        if (scene <= PlayerPrefs.GetInt("BestLevel"))
        {
            txtRoomName.text = roomList[currentRoom].name;
            txtRoomNum.text = roomList[currentRoom].num;
            imgRoom.sprite = roomList[currentRoom].sprite;
        }
        else
        {
            txtRoomName.text = "???";
            txtRoomNum.text = roomList[currentRoom].num;
            imgRoom.sprite = imgSecretRoom;
        }
    }

}
