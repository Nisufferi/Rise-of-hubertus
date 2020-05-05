using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip swordSwing;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GetComponent<Animator>().SetBool("Attack", false);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
             PlayerAttack();
        }
    }

    public void PlayerAttack()
    {
        GetComponent<Animator>().SetTrigger("attack");
    }

    public void PlaySwordSwing()
    {
        audioSource.clip = swordSwing;
        audioSource.Play();
    }
}
