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

        //ĳ���� ȸ���� �ȵǴ� ���� ������� ������ ��� ī�޶� ���� �������δ� �߰���
        //transform.position += moveDirection.normalized * speed * Time.deltaTime;

        //ĳ���� �����ϰ� ī�޶� ������ �� �� �������� �����ϴµ� �� ��. ÷�� ���°� �� ��
        transform.LookAt(transform.position + moveVec);
        transform.position += moveVec * speed * Time.deltaTime;

        //toggleCameraRotation : true -> ������ ����
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
