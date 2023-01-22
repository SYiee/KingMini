using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator _animator;
    Camera _camera;
    CharacterController _controller;

    public float speed = 5f;
    public float runspeed = 8f;
    public float smoothness = 10f;
    public float finalSpeed;
    public bool toggleCameraRotation= false;
    public bool run;


    void Start()
    {
        _animator = this.GetComponent<Animator>();
        _camera = Camera.main;
        _controller = this.GetComponent<CharacterController>();
    }

    void Update()
    {
        toggleCameraRotation = Input.GetKey(KeyCode.LeftAlt) ? true : false;
        InputManage();
        Move();
    }

    private void LateUpdate()
    {
        
        if(toggleCameraRotation != true)
        {
            Vector3 playerRotate = Vector3.Scale(_camera.transform.forward, new Vector3(1, 0, 1));
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerRotate), Time.deltaTime * smoothness);
        }
        
    }

    void InputManage()
    {
        run = Input.GetKey(KeyCode.LeftShift);
    }
    void Move()
    {
        finalSpeed = (run) ? runspeed : speed;
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        Vector3 moveDirection = forward * Input.GetAxisRaw("Vertical") + right * Input.GetAxis("Horizontal");
        Vector3 moveVec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        transform.LookAt(transform.position + moveVec);


        _controller.Move(moveDirection.normalized * finalSpeed * Time.deltaTime);

        float percent = ((run) ? 1 : 0.5f) * moveDirection.magnitude;
        _animator.SetFloat("Speed", percent, 0.1f, Time.deltaTime);
    }
}
