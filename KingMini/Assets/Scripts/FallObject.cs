using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallObject : MonoBehaviour
{
    public enum Direction {Right, Left, Up, Down};
    public Direction direction;
    public Rigidbody fallObjRigidbody;
    public GameObject fallObject;
    public float force = 10f;

    private void Start()
    {
        fallObjRigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            fallObjRigidbody.constraints = RigidbodyConstraints.None;
            print("enter");

            if (direction == Direction.Right)
            {
                fallObjRigidbody.AddForce((Vector3.right + Vector3.down) * force, ForceMode.Impulse);
            }

            else if (direction == Direction.Left)
            {
                fallObjRigidbody.AddForce((Vector3.left + Vector3.down) * force, ForceMode.Impulse);
            }
            else if (direction == Direction.Up)
            {
                fallObjRigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);
            }
            else if (direction == Direction.Down)
            {
                fallObjRigidbody.AddForce(Vector3.down * force, ForceMode.Impulse);
            }

        }


    }

}
