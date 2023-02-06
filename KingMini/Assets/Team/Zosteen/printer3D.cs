using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class printer3D : MonoBehaviour
{

    public GameObject player;
    public ParticleSystem smoke;
    public ParticleSystem ring;
    public Transform playerSpawn;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Invoke("printer3d", 0.5f);
        }
    }

    void printer3d()
    {
        player.SetActive(false);
        smoke.Play();
        player.transform.localScale = new Vector3(1, 1, 1);
        player.GetComponent<CapsuleCollider>().enabled = true;
        player.GetComponent<BoxCollider>().enabled = false;
        Invoke("Spawnplayer", 4f);
    }

    void Spawnplayer()
    {
        smoke.Stop();
        ring.Play();
        player.SetActive(true);
        player.transform.position = playerSpawn.position;

    }
}
