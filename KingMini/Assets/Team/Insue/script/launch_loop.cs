using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launch_loop : MonoBehaviour
{

    public GameObject start;
    public GameObject end;

    public GameObject projectile;

    public float power = 50;

    public float interval = 10;

    public float destroy_time = 1f;

    AudioSource source;
    [Header("Sound")]
    public bool is_sound = false;
    public AudioClip Sound;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private float time = 0;
    // Update is called once per frame
    void FixedUpdate()
    {
        time++;

        if (time >= interval)
        {
            time = 0;
            GameObject ball = Instantiate(projectile);
            ball.transform.position = start.transform.position;
            Vector3 dir = new Vector3(end.transform.position.x, end.transform.position.y + 2, end.transform.position.z) - start.transform.position;
            ball.GetComponent<Rigidbody>().AddForce(dir * power);
            if(is_sound)
            {
                source.PlayOneShot(Sound);
            }
            Destroy(ball, destroy_time);
        }
    }
}
