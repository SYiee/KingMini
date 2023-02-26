using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScene : MonoBehaviour
{

    public GameObject FadeInUI;

    void Start()
    {
        Instantiate(FadeInUI, new Vector3(1000, 700, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
