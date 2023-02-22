using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] GameObject emptyCube, shootingCube;
    [SerializeField] int speed;

    public AudioClip sound;
    bool first = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            emptyCube.SetActive(true);
            shootingCube.SetActive(true);

            shootingCube.transform.position = Vector3.MoveTowards(shootingCube.transform.position, other.transform.position + Vector3.up*1.5f, Time.deltaTime * speed);

            if (first)
            {
                AudioManager.instance.GetComponent<AudioSource>().PlayOneShot(sound);
                first = false;
            }
            
        }
    }
}
