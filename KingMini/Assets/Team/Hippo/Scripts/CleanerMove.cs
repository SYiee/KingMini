using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CleanerMove : MonoBehaviour
{
    Animator animator;
    Transform transform;
    NavMeshAgent agent = null;

    private void Start()
    {
        transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Debug.Log(agent.velocity);

        if (agent.velocity == Vector3.zero)
        {
            animator.SetBool("isWalk", false);
        }
        else
            animator.SetBool("isWalk", true);
    }
}
