using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Esc_UI : MonoBehaviour
{
    public GameObject Settings;     
    public TextMeshProUGUI Name_txt;
    bool is_pause = false;

    public List<string> name = new List<string>();

    private void Start()
    {
        Name_txt.text = name[SceneManager.GetActiveScene().buildIndex -2];
    }

    // Update is called once per frame
    void Update()
    {
        
        // Esc Ű ���� �� Ȱ��ȭ
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            is_pause = !is_pause;

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
    }

    public void ChangeName(int num)
    {
        Name_txt.text = name[num];
    }
}
