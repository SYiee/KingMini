using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class printer3D : MonoBehaviour
{
    public GameObject player;
    public GameObject printerCover;
    public Animator animator;
    public ParticleSystem dust;
    public Transform playerSpawn;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("coverDown");
            Invoke("printer3d", 0.5f);
        }
    }

    void printer3d()
    {
        player.SetActive(false);
        dust.Play();
        player.transform.localScale = new Vector3(1, 1, 0.1f);
        Invoke("Spawnplayer", 4f);
    }

    void Spawnplayer()
    {
        dust.Stop();
        player.SetActive(true);
        player.transform.position = playerSpawn.position;

    }

}
