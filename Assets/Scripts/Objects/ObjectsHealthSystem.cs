using System.Collections;
using UnityEngine;

public class ObjectsHealthSystem : MonoBehaviour, IHealthSystem
{
    [Header("Object health")]
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;

    public MeshRenderer meshRenderer;
    public BoxCollider boxCollider;

    private void Start()
    {
        currentHealth = maxHealth;

        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
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
            StartCoroutine(DestroyObject(1));
        }
    }

    public void Die() 
    {
        Destroy(gameObject);
    }

    private IEnumerator DestroyObject(int time) 
    {
        //TODO: Add particles effect.

        yield return new WaitForSeconds(time);

        Die();
    }
}
