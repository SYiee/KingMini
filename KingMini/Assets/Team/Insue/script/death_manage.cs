using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class death_manage : MonoBehaviour
{
    public int death_count = 0;
    public int scene;

    private void Awake()
    {
        // ����� ���� Ƚ���� Load �ؿɴϴ�
        death_count = PlayerPrefs.GetInt("Death");

        var obj = FindObjectsOfType<death_manage>();

        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    

    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            print(death_count);
        }
    }

    public void Death()
    {
        death_count++;
        print(death_count);


        // ���� Ƚ�� ����
        scene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("Death" + scene, death_count);
    }

}
