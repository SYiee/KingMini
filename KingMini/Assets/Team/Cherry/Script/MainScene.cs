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
    public TextMeshProUGUI txtBestTime;
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
    public GameObject soundmanager;

    int currentRoom = 0;
    float time = 0;


    private void Start()
    {
        time = 0;
        Time.timeScale = 1f;

        currentRoom = PlayerPrefs.GetInt("Level") - errornum; // ���� ���� ��������
        print(PlayerPrefs.GetInt("Level"));

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

            //bgm reset
            Destroy(AudioManager.instance);

            SceneManager.LoadScene(scene);
        }

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
            txtRoomName.text = roomList[currentRoom].name;
            txtRoomNum.text = roomList[currentRoom].num;
            txtBestTime.text = roomList[currentRoom].best_time.ToString();
            imgRoom.sprite = roomList[currentRoom].sprite;

            // BestDeath �ε�
            if (!PlayerPrefs.HasKey("BestDeath" + scene))
            {
                txtBestDeath.text = "999999";
                PlayerPrefs.SetInt("BestDeath" + scene, 999999);
            }
            else
                txtBestDeath.text = PlayerPrefs.GetInt("BestDeath" + scene).ToString();
        }
        else
        {
            txtRoomName.text = "???";
            txtRoomNum.text = roomList[currentRoom].num;
            txtBestDeath.text = "???";
            txtBestTime.text = "???";
            imgRoom.sprite = imgSecretRoom;
        }
    }

}
