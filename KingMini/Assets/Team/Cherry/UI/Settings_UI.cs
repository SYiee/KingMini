using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Settings_UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BacktoGame()
    {
        // �ٽ� ��������
        Time.timeScale = 1;
        gameObject.SetActive(false);
        Cursor.visible = false;
    }

    public void GotoMainMenu(AudioClip clip)
    {
        // ���θ޴��� �� ��ȯ
        SceneManager.LoadScene(0);
        AudioManager.instance.transform.GetChild(0).GetComponent<AudioSource>().clip= clip;
        AudioManager.instance.transform.GetChild(0).GetComponent<AudioSource>().Play();
    }

    public void ExitGame() // ���� ����
    {
        Application.Quit();
    }
}
