using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Camera _camera;
    Animator _animator;

    //player
    float hAxis;
    float vAxis;
    public float speed;
    public float runspeed;
    public bool run;
    Vector3 moveVec;
    public Transform Dir;


    //camera
    public bool toggleCameraRotation = false;
    public float smoothness = 10f;


    void Start()
    {
        _animator = this.GetComponent<Animator>();
        _camera = Camera.main;
    }
    private void LateUpdate()
    {
        //camera + player rotate

        if (toggleCameraRotation == false)
        {
            Vector3 playerRotate = Vector3.Scale(_camera.transform.forward, new Vector3(1, 0, 1));
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerRotate), Time.deltaTime * smoothness);
        }

    }

    void Update()
    {
        InputManage();
        toggleCameraRotation = (moveVec == Vector3.zero) ? true : false;



        //character move
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        Vector3 moveDirection = forward * vAxis + right * hAxis;
        Vector3 mmove = new Vector3(forward.x * vAxis, 0, right.z * hAxis).normalized;

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        //캐릭터 회전이 안되는 버전 뒤통수만 봐야함 대신 카메라 보는 방향으로는 잘감ㅁ
        //transform.position += moveDirection.normalized * speed * Time.deltaTime;

        //캐릭터 정지하고 카메라 돌렸을 때 그 방향으로 가야하는데 안 감. 첨에 가는건 잘 감
        transform.LookAt(transform.position + moveVec);
        transform.position += moveVec * speed * Time.deltaTime;

        //toggleCameraRotation : true -> 움직임 없음
        //if (toggleCameraRotation)
        //{
        //    transform.position += moveDirection.normalized * speed * Time.deltaTime;
        //}
        //else
        //{
        //    transform.LookAt(transform.position + moveVec);
        //    transform.position += moveVec * speed * Time.deltaTime;

        //}



        //animation
        float percent = ((run) ? 1 : 0.5f) * moveDirection.magnitude;
        _animator.SetFloat("Speed", percent, 0.1f, Time.deltaTime);


    }

    void InputManage()
    {
        run = Input.GetKey(KeyCode.LeftShift);

        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
    }
}
