using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAI : MonoBehaviour
{
    NavMeshAgent agent = null;

    // �ʿ� ������ wayPoint ������� ������
    [SerializeField] Transform[] wayPoints;
    public float time;
    int count = 0;

    Transform target;

    // ���� �ߴ��ϰ� _target ������ ��
    public void SetTarget(Transform _target)
    {
        CancelInvoke();
        target = _target;
    }

    // target ���ְ� �ٽ� ���� ����
    public void RemoveTarget()
    {
        target = null;
        InvokeRepeating("MoveToNextWayPoint", 0f, time);
    }
    void MoveToNextWayPoint()
    {
        if(target == null)
        {
            if (agent.velocity == Vector3.zero)
            {
                agent.SetDestination(wayPoints[count++].position);

                if (count >= wayPoints.Length)
                    count = 0;
            }

        }
        
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("MoveToNextWayPoint", 0f, time);
    }

    void Update()
    {
        if(target != null)
        {
            agent.SetDestination(target.position);
        }
    }
}
