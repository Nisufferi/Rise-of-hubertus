using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    [SerializeField] Transform target;
    float turnSpeed = 1f;
    NavMeshAgent navMeshAgent;
    bool engaged = true;
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
        //distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (engaged)
        {
            EngageTarget();
        }
        
    }

    private void EngageTarget()
    {
        GetComponent<Animator>().SetBool("IsEngaged", true);
        FaceTarget();
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
