using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public GameObject SkipBtn;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("ActiveButton", 10f);
    }

    void ActiveButton()
    {
        SkipBtn.SetActive(true);
    }

    public void SkipVideo()
    {
        int present = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(present + 1);
    }
}
