using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonAI : MonoBehaviour
{
    [SerializeField] float aggrorange = 35f;
    [SerializeField] float chaserange = 70f;
    [SerializeField] Transform target;
    [SerializeField] float turnSpeed = 5f;
    bool isProvoked = false;
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    SkeletonAttack attack;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
        {
            EngageTarget();
        }
        else if(distanceToTarget <= aggrorange)
        {
            isProvoked = true;
        }
        
    }

    private void EngageTarget()
    {
        FaceTarget();
        if (distanceToTarget >= navMeshAgent.stoppingDistance && distanceToTarget < chaserange)
        {
            ChaseTarget();
        }

        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
        IsIdle();
    }

    private void IsIdle()
    {
        if (distanceToTarget > chaserange)
        {
            isProvoked = false;
            navMeshAgent.ResetPath();
            GetComponent<Animator>().SetBool("Attack", false);
            GetComponent<Animator>().SetBool("IsWalking", false);

        }
    }

    private void ChaseTarget()
    {

        GetComponent<Animator>().SetBool("Attack", false);
        GetComponent<Animator>().SetBool("IsWalking", true);
        GetComponent<Animator>().SetTrigger("Walk");
        navMeshAgent.SetDestination(target.position);
    }

    public void AttackTarget()
    {
        GetComponent<Animator>().SetBool("IsWalking", false);
        GetComponent<Animator>().SetBool("Attack", true);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }
}
