using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] GameObject emptyCube, shootingCube;
    [SerializeField] int speed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            emptyCube.SetActive(true);
            shootingCube.SetActive(true);

            shootingCube.transform.position = Vector3.MoveTowards(shootingCube.transform.position, other.transform.position + Vector3.up*1.5f, Time.deltaTime * speed);
        }
    }
}
