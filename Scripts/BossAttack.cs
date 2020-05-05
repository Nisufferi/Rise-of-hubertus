using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAttack : MonoBehaviour
{
    PlayerHealth tar;
    [SerializeField] float damage = 20f;
    [SerializeField] Transform target;
    float distanceToTarget = Mathf.Infinity;
    NavMeshAgent navMeshAgent;
    ParticleSystem particleObject;
    GameObject part;
    BossHealth boss;
    private bool dead = false;
    private AudioSource audioSource;
    public AudioClip BossFireAttack;

    float turnSpeed = 1f;
    public bool engaged = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        tar = FindObjectOfType<PlayerHealth>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        part = GameObject.Find("/Green/Particle System");
        particleObject = part.GetComponent<ParticleSystem>();
        particleObject.Stop();
        boss = FindObjectOfType<BossHealth>();
        dead = boss.isDead;
    }

    void Update()
    {
        dead = boss.isDead;
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (!dead)
        {
            FaceTarget();
            if (engaged)
            {
                GetComponent<Animator>().SetBool("IsEngaged", true);
                EngageTarget();
            }
        }
        
    }
    private void EngageTarget()
    {
        

        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            GetComponent<Animator>().ResetTrigger("meleeAttack");
            GetComponent<Animator>().SetTrigger("fireAttack");
        }
        else if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            GetComponent<Animator>().ResetTrigger("fireAttack");
            GetComponent<Animator>().SetTrigger("meleeAttack");
        }
    }
    void Stop()
    {
        particleObject.Stop();
    }
    void Play()
    {
        particleObject.Play();
    }

    public void Attack()
    {
        if (tar == null) return;
        tar.damageTaken(damage);
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

    void FireAttackSound()
    {
        FireSound();
    }
    void FireSound()
    {
        audioSource.clip = BossFireAttack;
        audioSource.Play();
    }
}
