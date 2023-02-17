using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class printer3D : MonoBehaviour
{

    public GameObject player;
    public ParticleSystem smoke;
    public ParticleSystem ring;
    public Transform playerSpawn;
    public AudioClip printer3dSound;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Invoke("printer2d", 0.5f);
        }
    }

    void printer2d()
    {
        player.GetComponent<PlayerState>().StateChange(PlayerState.State.Nomal);
        player.SetActive(false);
        smoke.Play();
        GetComponent<AudioSource>().PlayOneShot(printer3dSound);
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
