using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Ball : MonoBehaviour
{
    public GameObject Ball;
    public GameObject SpawnPointObj;
    private Vector3 SpawnPoint;


    private bool IsCoolTime;
    public float CoolTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        IsCoolTime = false;
        SpawnPoint = SpawnPointObj.transform.position;
    }

    float timer = 0f;
    // Update is called once per frame
    void Update()
    {
        if(!IsCoolTime)
        {
            Instantiate(Ball, SpawnPoint, Quaternion.identity);
            IsCoolTime = true;
            Debug.Log(5);
        }
        
        if(IsCoolTime)
        {
            timer += Time.deltaTime;

            if (timer >= CoolTime)
            {
                timer = 0f;
                IsCoolTime = false;
            }
        }
    }
}
