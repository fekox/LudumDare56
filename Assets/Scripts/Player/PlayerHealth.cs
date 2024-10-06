using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerHealth : MonoBehaviour, IHealthSystem
{
    [Header("Health setup")]
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private bool isDead;
    [SerializeField] private bool isTakingDamage;

    [Header("Ants touched")]

    [SerializeField] private int currentAntsTouched;
    [SerializeField] private int maxAntsTouchedLimit;

    [SerializeField] private float damageTimer;

    [SerializeField] private List<GameObject> antsUIGameObjects;

    [SerializeField] private List<GameObject> sandwichParts;


    private float maxDamageTimer;

    private void Start()
    {
        currentHealth = maxHealth;
        currentAntsTouched = 0;

        maxDamageTimer = damageTimer;
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

    public void TakeDamageLogic()
    {
        if (!isTakingDamage)
        {
            if (currentAntsTouched >= maxAntsTouchedLimit)
            {
                isTakingDamage = true;
                currentHealth--;
                currentAntsTouched = 0;

                for (int i = 0; i < antsUIGameObjects.Count; i++)
                {
                    antsUIGameObjects[i].SetActive(false);
                }
            }

            switch (currentAntsTouched)
            {
                case 1:
                    antsUIGameObjects[0].SetActive(true);
                    break;

                case 2:
                    antsUIGameObjects[1].SetActive(true);
                    break;

                case 3:
                    antsUIGameObjects[2].SetActive(true);
                    break;

                case 4:
                    antsUIGameObjects[3].SetActive(true);
                    break;

                case 5:
                    antsUIGameObjects[4].SetActive(true);
                    break;


                case 6:
                    break;
            }

            switch (currentHealth) 
            {
                case 0:

                    sandwichParts[2].SetActive(false);
                    sandwichParts[1].SetActive(false);
                    sandwichParts[0].SetActive(false);

                    break;

                case 1:

                    sandwichParts[2].SetActive(true);
                    sandwichParts[1].SetActive(false);
                    sandwichParts[0].SetActive(false);

                    break;

                case 2:

                    sandwichParts[2].SetActive(false);
                    sandwichParts[1].SetActive(true);
                    sandwichParts[0].SetActive(false);

                    break;

                case 3:

                    sandwichParts[2].SetActive(false);
                    sandwichParts[1].SetActive(false);
                    sandwichParts[0].SetActive(true);

                    break;
            }
        }

        if (isTakingDamage) 
        {
            damageTimer -= Time.deltaTime;

            if (damageTimer <= 0)
            {
                isTakingDamage = false;
                damageTimer = maxDamageTimer;
            }
        }

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

    public void AddOneAnt()
    {
        currentAntsTouched++;
    }

    public void ResetAntsTouched()
    {
        currentAntsTouched = 0;
    }

    public void TakeDamage(float number)
    {
        currentHealth -= number;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
        }
    }

    public bool GetIsTakingDamage() 
    {
        return isTakingDamage;
    }
}
