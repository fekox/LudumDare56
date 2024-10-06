using System.Collections;
using UnityEngine;

public class ObjectsHealthSystem : MonoBehaviour, IHealthSystem
{
    [Header("Object health")]
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
            StartCoroutine(DestroyObject(0.5f));
        }
    }

    public void Die() 
    {
        Destroy(gameObject);
    }

    private IEnumerator DestroyObject(float time) 
    {
        //TODO: Add particles effect.

        yield return new WaitForSeconds(time);

        Die();
    }
}
