using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private Transform player;
    private Vector3 movement;
    private float moveSpeed = 0.3f;
    public Rigidbody rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 direction = player.position - transform.position;
        movement = direction;
        direction.Normalize();

        bool IsWalking = Input.GetKey(KeyCode.W);
        animator.SetBool("IsWalking", IsWalking);

        if (Input.GetKeyDown(KeyCode.A)) 
        {
            animator.SetTrigger("Attack");
        }
    }

    private void FixedUpdate() {
        moveChar(movement);
    }

    void moveChar(Vector3 direction) {
        
        rb.MovePosition(transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}