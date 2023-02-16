using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public int SceneNum;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {     
        if (other.gameObject.tag == "Player")
        {
            int present = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(present + 1);

            //death √ ±‚»≠
            GameObject.Find("death_manager").GetComponent<death_manage>().death_count = 0;
            PlayerPrefs.SetInt("Death", 0);
        }
    }
}
