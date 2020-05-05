using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    public int keyNumber;
    public GameObject healthBarUI, armorBarUI;
    public Slider slider, armorSlider;
    public PlayerHealth health;
    public PlayerHealth armor;
    public float hitPoints;
    public float maxHitPoints;
    public float armorPoints;
    public float maxArmor;
    public Text keys, instructions;


    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        instructions.text = "";
    }

    void Start()
    {
        StartCoroutine(ExecuteAfterTime(5f));
        keys.text = keyNumber.ToString();
        health = FindObjectOfType<PlayerHealth>();
        hitPoints = FindObjectOfType<PlayerHealth>().hitPoints;
        maxHitPoints = FindObjectOfType<PlayerHealth>().maxHitPoints;
        hitPoints = maxHitPoints;
        slider.value = health.CalculateHealth();


        armorPoints = FindObjectOfType<PlayerHealth>().armorPoints;
        maxArmor = FindObjectOfType<PlayerHealth>().maxArmor;
       
    }

    void Update()
    {
        keys.text = keyNumber.ToString();
        slider.value = health.CalculateHealth();
        armorSlider.value = health.CalculateArmor();
    }


}
