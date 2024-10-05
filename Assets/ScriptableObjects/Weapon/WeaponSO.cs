using UnityEngine;


public enum WeaponType 
{
    Pistol,
    Rifle,
    Shootgun
};

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class WeaponSO : ScriptableObject
{
    [Header("Weapon type")]
    [SerializeField] private WeaponType weaponType;

    [Header("Wepon ID")]
    [SerializeField] private int weaponID;

    [Header("Damage")]
    [SerializeField] private float damage;

    [Header("Range")]
    [SerializeField] private float range;

    [Header("Bullets")]
    [SerializeField] private int maxBullets = 20;

    [SerializeField] private int currentBullets = 0;

    [Header("Fire Rate")]
    [SerializeField] private float fireRate;

    [Header("Impact Force")]
    [SerializeField] private float impactForce;

    [Header("Reloading Time")]
    [SerializeField] private float reloadingTime;

    [Header("Reloading Recoil")]
    [SerializeField] private float recoil;

    public WeaponType GetWeaponType() 
    { 
        return weaponType; 
    }

    public int GetID() 
    {
        return weaponID;
    }

    public float GetDamage() 
    {
        return damage;
    }

    public float GetRange() 
    {
        return range;
    }

    public int GetMaxBullets() 
    {
        return maxBullets;
    }

    public int GetCurrentBullets()
    {
        return currentBullets;
    }

    public float GetFireRate()
    {
        return fireRate;
    }

    public float GetImpactForce()
    {
        return impactForce;
    }

    public float GetReloadingTime() 
    {
        return reloadingTime;
    }

    public float GetRecoil()
    {
        return recoil;
    }
}
