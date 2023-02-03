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
        // Esc 키 누를 때 활성화
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            is_pause = !is_pause;

            // 게임 일시정지
            if(is_pause)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;

            // UI 켜기
            Settings.SetActive(is_pause);

        }
    }

}
