using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Title;

    float time = 0;

    private void Start()
    {
        time = 0;
        Time.timeScale = 1f;
    }

    private void Update()
    {

        if (time < 0.7f)
        {
            Title.transform.position = Title.transform.position + new Vector3(0, 0.3f, 0);
            print(time);
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

    public void NewGame()
    {
        SceneManager.LoadScene(2);
    }

    // Update is called once per frame
    public void QuitGame() // 게임 종료
    {
        Application.Quit();
    }
}
