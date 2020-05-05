using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    [SerializeField]
    public float hitPoints = 1000f;
    public float maxHitPoints = 1000f;

    private AudioSource audioSource;

    public AudioClip bossDmg;
    public AudioClip bossDeath;

    public bool isDead = false;
    public GameObject healthBarUI;
    public Slider slider;
    Animation anim;
    ParticleSystem particleObject;
    GameObject part;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        hitPoints = maxHitPoints;
        slider.value = CalculateHealth();
        part = GameObject.Find("/Green/Particle System");
        particleObject = part.GetComponent<ParticleSystem>();
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Victory");
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
        if (hitPoints <= 0 && isDead == false)
        {
            isDead = true;
            particleObject.Stop();
            GetComponent<Animator>().SetTrigger("dead");
            StartCoroutine(ExecuteAfterTime(5f));
            
        }
    }


    

    public void damageTaken(float damage)
    {
        PlayDmgSound();
        hitPoints -= damage;

        if (hitPoints <= 0)
        {
            PlayDeathSound();
        }
    }
    private void Die()
    {
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
            
            audioSource.clip = bossDmg;
            audioSource.Play();
            
        }
        else return;

    }

    public void PlayDeathSound()
    {
        if (hitPoints == 0)
        {
            audioSource.clip = bossDeath;
            audioSource.Play();
        }
    }
    
}

