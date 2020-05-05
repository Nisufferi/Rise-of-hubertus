using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonHealth : MonoBehaviour
{
    [SerializeField] 
    float hitPoints = 100f;
    float maxHitPoints = 100f;

    private AudioSource audioSource;

    public AudioClip skeletonDmg;
    public AudioClip skeletonDeath;

    bool isDead = false;
    public GameObject healthBarUI;
    public Slider slider;
    Animation anim;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        anim = gameObject.GetComponent<Animation>();
        hitPoints = maxHitPoints;
        slider.value = CalculateHealth();
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Die();
    }
    void Update()
    {
        slider.value = CalculateHealth();
        if (hitPoints < maxHitPoints)
        {
            healthBarUI.SetActive(true);
        }
        else if (hitPoints > maxHitPoints)
        {
            hitPoints = maxHitPoints;
        }
        if(hitPoints <= 0)
        {

        }
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void damageTaken(float damage)
    {
        PlayDmgSound();
        hitPoints -= damage;

        if (hitPoints <= 0)
        {
            PlayDeathSound();
            anim.Play("skeleton_dying");
            StartCoroutine(ExecuteAfterTime(1f));
        }
    }
    private void Die()
    {
        if (isDead) return;
        isDead = true;
        Destroy(gameObject);
    }

    float CalculateHealth()
    {
        return hitPoints / maxHitPoints;
    }

    public void PlayDmgSound()
    {
        if (hitPoints > 0)
        {
            audioSource.clip = skeletonDmg;
            audioSource.Play();
        }
        else return;
        
    }

    public void PlayDeathSound()
    {
        if (hitPoints == 0)
        {
            audioSource.clip = skeletonDeath;
            audioSource.Play();
        }
    }
}

