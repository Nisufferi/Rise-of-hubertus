using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float hitPoints = 100f;
    public float maxHitPoints = 100f;

    [SerializeField] public float armorPoints = 100f;
    public float maxArmor = 100f;

    public float CalculateHealth()
    {
        
        return hitPoints / maxHitPoints;
    }

    public float CalculateArmor()
    {

        return armorPoints / maxArmor;
    }

    public void damageTaken(float damage)
    {
        if (armorPoints > 0)
        {
            armorPoints -= damage;
            hitPoints -= damage / 2;
        }

        else
        {
            hitPoints -= damage;
        }
        
        if(hitPoints <= 0)
        {
            Destroy(gameObject);
            Application.LoadLevel("DeathScreen");
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
