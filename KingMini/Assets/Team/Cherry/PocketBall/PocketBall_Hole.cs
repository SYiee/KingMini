using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocketBall_Hole : MonoBehaviour
{
    public GameObject PocketBall;

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "BlackBall")
        {
            Debug.Log("»ç¸Á");
            Destroy(other.gameObject);
         //   PocketBall.GetComponent<PocketBall>().ball_count -= 1;
            
        }
        if (other.tag == "RedBall")
        {
            Destroy(other.gameObject);
            PocketBall.GetComponent<PocketBall>().RedBalls.Remove(other.gameObject);
            PocketBall.GetComponent<PocketBall>().ball_count -= 1;
        }
        if(other.tag == "WhiteBall")
        {
            other.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
