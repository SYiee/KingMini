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

    public void GotoMainMenu()
    {
        // ���θ޴��� �� ��ȯ
        SceneManager.LoadScene(1);
    }

    public void ExitGame() // ���� ����
    {
        Application.Quit();
    }
}
