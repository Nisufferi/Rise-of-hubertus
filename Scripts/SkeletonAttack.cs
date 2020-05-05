using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 10f;
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void Attack()
    {
        if (target == null) return;
        target.damageTaken(damage);
    }
}
