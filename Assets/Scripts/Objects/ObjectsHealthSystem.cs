using UnityEngine;

public class ObjectsHealthSystem : MonoBehaviour, IHealthSystem
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;

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
        currentHealth -= number;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    public void Die() 
    {
        Destroy(gameObject);
    }
}
