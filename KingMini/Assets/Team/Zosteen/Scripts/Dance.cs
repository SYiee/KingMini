using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dance : MonoBehaviour
{


    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<Animator>().SetBool("isDance", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isDance", false);

        }
    }
}
