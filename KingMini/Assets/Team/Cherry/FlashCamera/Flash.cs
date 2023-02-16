using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flash : MonoBehaviour
{
    public GameObject Flash_obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            //Flash_obj.SetActive(true);
            //Color color = Flash_obj.GetComponent<Image>().color;
            //color.a = 1f;

            Instantiate(Flash_obj, new Vector3(1000, 700, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
        }
    }
}
