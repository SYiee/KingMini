using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soccer_player : MonoBehaviour
{
    [Header("X-rotation")]
    [Range(0f, 360f)]
    public float max_x = 0f;
    [Header("Rotation Speed")]
    public float rotSpeed = 100;
    [Header("Rotation Direction")]
    [Range(-1,1)]
    public int rot_dir = 1;


    [Header("X-move")]
    public float move_x = 0;
    [Header("Move Speed")]
    public float movSpeed = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private int state =0;
    //0 = up 1 = down 2 = move
    private float move_count = 0;
    private int dir = 1; 

    // Update is called once per frame
    void FixedUpdate()
    {
        shoot();
    }

    void shoot()
    {
        if(state == 0)//up
        {
            transform.Rotate(new Vector3(rotSpeed * rot_dir * Time.deltaTime, 0, 0));
        }
        if(state ==1)//down
        {
            transform.Rotate(new Vector3(rotSpeed / 2 * rot_dir * -1f * Time.deltaTime, 0, 0));
        }
        if(state ==2)//move
        {
            transform.Translate(movSpeed * Time.deltaTime*dir, 0, 0);
            move_count++;
            if (move_count >= move_x)
            {
                transform.localEulerAngles = new Vector3(1f * rot_dir, 0, 0);
                state = 0;
                move_count = move_x * -1f;//다 움직이면 다시 up
                dir = dir * -1;
            }
        }

            if (transform.rotation.x * rot_dir >= max_x / 360f)
            {
                state = 1;
            }//max각도보다 커지면 state를 1 ( down ) 으로
            if (transform.rotation.x * rot_dir < 0)
            {
                print(transform.rotation.x * rot_dir);
                state = 2;
                transform.localEulerAngles = new Vector3(0, 0, 0);
            }//원위치로 돌아오면 move}
   
    }
}
