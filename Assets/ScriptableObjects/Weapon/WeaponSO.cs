using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class WeaponSO : ScriptableObject
{
    [Header("Gun Setup")]
    [SerializeField] private float damage;

    [SerializeField] private float range;

    [SerializeField] private float fireRate;

    [SerializeField] private float impactForce;

    public float GetDamage() 
    {
        return damage;
    }

    public float GetRange() 
    {
        return range;
    }

    public float GetFireRate()
    {
        return fireRate;
    }

    public float GetImpactForce()
    {
        return impactForce;
    }
}
