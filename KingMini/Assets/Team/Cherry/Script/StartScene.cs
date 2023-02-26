using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public GameObject SkipBtn;
    public GameObject FadeInUI;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("ActiveButton", 10f);
        Instantiate(FadeInUI, new Vector3(1000, 700, 0), Quaternion.identity, GameObject.Find("StartScene").transform);
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
