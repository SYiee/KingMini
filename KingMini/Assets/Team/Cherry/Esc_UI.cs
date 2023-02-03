using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esc_UI : MonoBehaviour
{
    public GameObject Settings;
    bool is_pause = false;


    // Update is called once per frame
    void Update()
    {
        // Esc Ű ���� �� Ȱ��ȭ
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            is_pause = !is_pause;

            // ���� �Ͻ�����
            if(is_pause)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;

            // UI �ѱ�
            Settings.SetActive(is_pause);

        }
    }

}
