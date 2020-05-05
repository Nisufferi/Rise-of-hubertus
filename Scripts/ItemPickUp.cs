using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public int key;
    PlayerHUD keyNumber;
    private AudioSource audioSource;
    public AudioClip pickUpSound;
    PlayerHealth health;
    float healing = 50;
    float addArmor = 50;
    bool collected = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        keyNumber = FindObjectOfType<PlayerHUD>();
        health = FindObjectOfType<PlayerHealth>();
        
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        collected = false;
    }


    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && collected == false)
        {
            collected = true;
            if(tag == "Key")
            {
                PlayPickUpSound();
                keyNumber.keyNumber += 1;
                Debug.Log(keyNumber.keyNumber);
                StartCoroutine(ExecuteAfterTime(0.2f));
            }
            if (tag == "Potion")
            {
                
                if (health.hitPoints + healing > 100f)
                {
                    PlayPickUpSound();
                    health.hitPoints = 100f;
                    Debug.Log(health.hitPoints);
                    StartCoroutine(ExecuteAfterTime(0.2f));
                }
                else
                {
                    PlayPickUpSound();
                    health.hitPoints += 50;
                    Debug.Log(health.hitPoints);
                    StartCoroutine(ExecuteAfterTime(0.2f));
                }
            }

            if (tag == "Armor")
            {

                if (health.armorPoints + addArmor > 100f)
                {
                    PlayPickUpSound();
                    health.armorPoints = 100f;
                    Debug.Log(health.armorPoints);
                    StartCoroutine(ExecuteAfterTime(0.2f));
                }
                else
                {
                    PlayPickUpSound();
                    health.armorPoints += 50;
                    Debug.Log(health.armorPoints);
                    StartCoroutine(ExecuteAfterTime(0.2f));
                }
            }

        }
    }


    public void PlayPickUpSound()
    {
        audioSource.clip = pickUpSound;
        audioSource.Play();
    }
}
