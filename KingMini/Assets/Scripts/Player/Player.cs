using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Camera _camera;
    Animator _animator;
    Rigidbody _rigidbody;

    //player move
    float hAxis;
    float vAxis;
    public float speed;
    public float runspeed;
    private float finalSpeed;
    public bool run;
    Vector3 moveVec;
    Vector3 moveDirection;

    //player jump
    bool jDown;
    bool isJump;
    bool isFall;
    public float jumpPower = 0.5f;
    
    
    //camera
    public bool isMove = false;
    public float smoothness = 10f;


    void Start()
    {
        _animator = this.GetComponent<Animator>();
        _camera = Camera.main;
        _rigidbody = GetComponent<Rigidbody>();
    }


    private void LateUpdate()
    {

    }

    void Update()
    {
        InputManage();

        Jump();
    }

    private void FixedUpdate()
    {
        Move();
        print(isJump);
        //idle+walk+run animation
        float percent = ((run) ? 1 : 0.5f) * moveDirection.magnitude;
        _animator.SetFloat("Speed", percent, 0.1f, Time.deltaTime);

    }

    void InputManage()
    {
        run = Input.GetKey(KeyCode.LeftShift);
        finalSpeed = (run) ? runspeed : speed;

        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        jDown = Input.GetButtonDown("Jump");
    }

    void Move()
    {
        isMove = (moveVec == Vector3.zero) ? true : false;

        //character move
        moveDirection = _camera.transform.forward * vAxis + _camera.transform.right * hAxis; //카메라가 바라보는 방향을 앞으로 설정
        moveVec = new Vector3(hAxis, 0, vAxis).normalized; // 움직임이 있는지 확인하기 위한 변수
        _rigidbody.position += moveDirection.normalized * finalSpeed * Time.deltaTime;

        //camera + Player Turn
        if (isMove == false) //움직임이 없을 때
        {
            Vector3 playerForwardRotationDir = Vector3.Scale(moveDirection, new Vector3(1, 0, 1));
            Quaternion newRotation = Quaternion.LookRotation(playerForwardRotationDir.normalized * finalSpeed * Time.deltaTime);
            _rigidbody.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * smoothness);
        }

    }

    void Jump()
    {
        if(jDown && !isJump)
        {
            _animator.SetBool("Grounded", false);
            _animator.SetBool("Jump", true);
            _rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJump = true;

        }
    }
    void Fall()
    {
        if (isFall)
        {
            //_animator.SetBool("FreeFall", true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Untagged")
        {
            isJump = false;
            _animator.SetBool("Jump", false);
            _animator.SetBool("Grounded", true);

            //isFall = false;
            _animator.SetBool("FreeFall", false);
        }

    }

    private void OnCollisionExit(Collision collision)
    {

    }

}
