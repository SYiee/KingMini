using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class printer2D : MonoBehaviour
{
    public GameObject player;
    public GameObject printerCover;
    public Animator animator;
    public ParticleSystem dust;
    public Transform playerSpawn;

    public GameObject player2;
    public GameObject player1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetTrigger("coverDown");
            Invoke("printer3d", 0.3f);
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        animator.SetTrigger("coverDown");
    //        Invoke("printer3d", 0.3f);
    //    }
    //}

    void printer3d()
    {
        player.SetActive(false);
        dust.Play();
        player.transform.localScale = new Vector3(1, 1, 0.1f);
        //player.GetComponent<BoxCollider>().enabled = true;
        //player.GetComponent<CapsuleCollider>().enabled = false;
        Invoke("Spawnplayer", 4f);

    }

    void Spawnplayer()
    {
        player2.SetActive(true);
        player1.SetActive(false);
        dust.Stop();
        //player.SetActive(true);
        //player.transform.position = playerSpawn.position;

    }
}
