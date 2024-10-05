using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealthSystem
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private bool isDead;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public void SetCurrentHelath(float number)
    {
        currentHealth = number;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void SetMaxHelath(float number)
    {
        maxHealth = number;
    }

    public void TakeDamage(float number)
    {
        currentHealth -= maxHealth;

        if (currentHealth <= 0) 
        {
            currentHealth = 0;
            isDead = true; 
        }
    }

    public void Healing(float number) 
    {
        currentHealth += number;

        if (currentHealth > maxHealth) 
        {
            currentHealth = maxHealth;
        }
    }
}
