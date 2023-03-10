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
    public int best_death;
    public float best_time;
    public Sprite sprite;
    public bool can_try;
}

public class MainScene : MonoBehaviour
{

    [Header("Room")]
    public Room[] roomList;
    public TextMeshProUGUI txtRoomName;
    public TextMeshProUGUI txtRoomNum;
    public TextMeshProUGUI txtBestDeath;
    public TextMeshProUGUI[] text_time;
    public Image imgRoom;
    public Sprite imgSecretRoom;
    public int errornum; // ������� ��
    public GameObject deathManager;


    [Header("UI")]
    public GameObject Title;
    public GameObject Continue_Btn;
    public GameObject MainUI;
    public GameObject ContinueUI;


    [Header("Sound Manager")]
    private GameObject soundmanager;

    int currentRoom = 0;
    float time = 0;


    private void Start()
    {
        time = 0;
        Time.timeScale = 1f;

        currentRoom = PlayerPrefs.GetInt("Level") - errornum; // ���� ���� ��������
        print(PlayerPrefs.GetInt("Level"));
        soundmanager = AudioManager.instance.gameObject;

        // ó�� �÷��� �� ������ Continue ��ư ��Ȱ��ȭ
        if (!PlayerPrefs.HasKey("FirstPlay") || PlayerPrefs.GetInt("FirstPlay") == 1)
        {
            Continue_Btn.GetComponent<Button>().interactable = false;
        }

    }

    private void Update()
    {
        // ���� Ʈ��ŷ
        //if (time < 0.7f)
        //{
        //    Title.transform.position = Title.transform.position + new Vector3(0, 0.3f, 0);
        //   // print(time);
        //}
        //else
        //{
        //    Title.transform.position = Title.transform.position + new Vector3(0, -0.3f, 0);
        //    if (time > 1.4f)
        //    {
        //        time = 0;
        //    }
        //}

        //time += Time.deltaTime;
    }

    public void NewGame()  // ���ο� ���� ����
    {

        // ���� Ƚ�� & Level �ʱ�ȭ
        GameObject.Find("death_manager").GetComponent<death_manage>().death_count = 0;
        for(int i = 0; i<roomList.Length; i++)
        {
            int a = i + errornum; 
            PlayerPrefs.SetInt("Death" + a, 0);
            PlayerPrefs.SetInt("Time" + a, 0);
            PlayerPrefs.SetInt("BestDeath" + a, 999999);
            PlayerPrefs.SetFloat("BestTime" + a, 999999);
        }
        PlayerPrefs.SetInt("Level", 2);
        PlayerPrefs.SetInt("BestLevel", 2);
        

        //bgm reset
        Destroy(soundmanager);
        //AudioManager.instance.transform.GetChild(0).GetComponent<AudioSource>().mute = true;

        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("FirstPlay", 0);


    }

    public void Continue()  // �̾ �÷���
    {
        //bgm reset
        Destroy(soundmanager);

        MainUI.SetActive(false);
        ContinueUI.SetActive(true);
        SettingRoom();
        // ����� Ű ������ �ű⼭���� �÷��� or ó������
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
    public void QuitGame() // ���� ����
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

    public void BtnStart() // ��ư�� ������ Play ����
    {
        int scene = currentRoom + errornum;

    // �̺κ� if�� �ٽ� �־��ֱ�! ��������� ����
       // if(scene <= PlayerPrefs.GetInt("BestLevel"))
      //  {
            // death reset or get data
            if (!PlayerPrefs.HasKey("Death" + scene))
            {
                GameObject.Find("death_manager").GetComponent<death_manage>().death_count = 0;
            }
            else
            {
                GameObject.Find("death_manager").GetComponent<death_manage>().death_count = PlayerPrefs.GetInt("Death" + scene);
                print(GameObject.Find("death_manager").GetComponent<death_manage>().death_count);
            }

            // ����� time data ���� ��� reset
            if (!PlayerPrefs.HasKey("Time" + scene))
            {
                PlayerPrefs.SetFloat("Time" + scene, 0);
            }

            //bgm reset
            Destroy(soundmanager);

            SceneManager.LoadScene(scene);
       // }

    }

    public void BacktoMain()
    {
        MainUI.SetActive(true);
        ContinueUI.SetActive(false);
    }

    void SettingRoom()  // UI���� �ʱ�ȭ ���ݴϴ�
    {
        int scene = currentRoom + errornum;
        print(scene);
        print(PlayerPrefs.GetInt("BestLevel"));
        if (scene <= PlayerPrefs.GetInt("BestLevel"))
        {
            print(PlayerPrefs.GetFloat("BestTime" + scene));
            txtRoomName.text = roomList[currentRoom].name;
            txtRoomNum.text = roomList[currentRoom].num;
            imgRoom.sprite = roomList[currentRoom].sprite;

            // Best Death set
            if(PlayerPrefs.GetInt("BestDeath" + scene) == 999999)
                txtBestDeath.text = "? ? ?";
            else
                txtBestDeath.text = PlayerPrefs.GetInt("BestDeath" + scene).ToString();

            // Best Time set
            if (PlayerPrefs.GetFloat("BestTime" + scene) == 999999)
            {
                text_time[0].text = "?";
                text_time[1].text = "?";
                text_time[2].text = "?";
                text_time[3].text = "?";
                text_time[4].text = "?";
                text_time[5].text = "?";
            }
            else
            {
                float time = PlayerPrefs.GetFloat("BestTime" + scene);
                print(time);
                text_time[0].text = ((int)time / 3600 / 10).ToString();
                text_time[1].text = (((int)time / 3600) % 10).ToString();
                text_time[2].text = (((int)time / 60 % 60) / 10).ToString();
                text_time[3].text = (((int)time / 60 % 60) % 10).ToString();
                text_time[4].text = (((int)time % 60) / 10).ToString();
                text_time[5].text = (((int)time % 60) % 10).ToString();
            }

        }
        else
        {
            txtRoomName.text = "???";
            txtRoomNum.text = roomList[currentRoom].num;
            txtBestDeath.text = "? ? ?";
            text_time[0].text = "?";
            text_time[1].text = "?";
            text_time[2].text = "?";
            text_time[3].text = "?";
            text_time[4].text = "?";
            text_time[5].text = "?";
            imgRoom.sprite = imgSecretRoom;
        }
    }

}
