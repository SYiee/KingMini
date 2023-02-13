using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasePlayer : MonoBehaviour
{
    public Transform target;
    NavMeshAgent nav;
    public bool condition = false;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(condition)
        {
            nav.SetDestination(target.position);
        }
    }

    public void ChangeCondition(bool presentCondition)
    {
        condition = presentCondition;
    }
}
