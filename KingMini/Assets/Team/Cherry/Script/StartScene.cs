using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public GameObject SkipBtn;
    public GameObject FadeInUI;
    public GameObject BlackUI;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("ActiveButton", 10f);
        Cursor.visible = false;
        GameObject fade = Instantiate(BlackUI, new Vector3(1000, 700, 0), Quaternion.identity, GameObject.Find("StartScene").transform);
        Destroy(fade, 2f);
    }

    void ActiveButton()
    {
        SkipBtn.SetActive(true);
        Cursor.visible = true;
    }

    public void SkipVideo()
    {
        int present = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(present + 1);
    }
}
