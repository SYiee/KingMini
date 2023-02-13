using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAnimPlay : MonoBehaviour
{
    private bool isFirst = true;
    public GameObject obstacle;
    Animator[] all_obstacles;
    private void OnCollisionEnter(Collision collision)
    {
        if(isFirst && collision.transform.tag == "Player")
        {
            if(obstacle.GetComponent<Animator>() == null)
            {
                all_obstacles = obstacle.GetComponentsInChildren<Animator>();
                foreach (Animator anim in all_obstacles)
                    anim.SetTrigger("AnimPlay");
            }
            else {
                obstacle.GetComponent<Animator>().SetTrigger("AnimPlay");

            }
            isFirst = false;
        }
    }
}
