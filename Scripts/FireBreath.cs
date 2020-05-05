using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FireBreath : MonoBehaviour
{
    [SerializeField] float damage = 0.2f;
    [SerializeField] PlayerHealth target;
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

    void Start()
    {
        
        target = FindObjectOfType<PlayerHealth>();
    }

    void Update()
    {
       
    }

    [System.Obsolete]
    void OnParticleCollision(GameObject collider) {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("TULI");
            if (target == null) return;
            target.damageTaken(damage);
        }
     }
    

}