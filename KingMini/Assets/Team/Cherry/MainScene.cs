using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    // Start is called before the first frame update
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
