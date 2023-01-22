using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esc_UI : MonoBehaviour
{
    public GameObject Settings;
    bool turn_on = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            turn_on = !turn_on;
            Settings.SetActive(turn_on);

        }
    }
}
