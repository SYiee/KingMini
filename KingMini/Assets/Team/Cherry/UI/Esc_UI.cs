using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Esc_UI : MonoBehaviour
{
    public GameObject Settings;
    public TextMeshProUGUI[] text_time;
    public TextMeshProUGUI text_name;
    bool is_pause = false;
    public float time = 0;
    int scenenum;

    public List<string> name = new List<string>();

    private void Start()
    {
        scenenum = SceneManager.GetActiveScene().buildIndex;
        text_name.text = name[SceneManager.GetActiveScene().buildIndex - 2];
        time = PlayerPrefs.GetFloat("Time" + scenenum);
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        // Esc Ű ���� �� Ȱ��ȭ
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            is_pause = !is_pause;
            PlayerPrefs.SetFloat("Time" + scenenum, time);

            // ���� �Ͻ����� & ���콺 Ŀ�� ���̵���
            if (is_pause)
            {   
                Time.timeScale = 0;
                Cursor.visible = true;
            }
            else
            {
                Time.timeScale = 1;
                Cursor.visible = false;
            }

            // UI �ѱ�
            Settings.SetActive(is_pause);

        }

        // Ÿ�̸�
        time += Time.deltaTime;
        text_time[0].text = ((int)time / 3600 / 10).ToString();
        text_time[1].text = (((int)time / 3600) % 10 ).ToString();
        text_time[2].text = (((int)time / 60 % 60) / 10).ToString();
        text_time[3].text = (((int)time / 60 % 60) % 10).ToString();
        text_time[4].text = (((int)time % 60) / 10).ToString();
        text_time[5].text = (((int)time % 60) % 10).ToString();
    }

    public void ChangeName(int num)
    {
        text_name.text = name[num];
    }
}
